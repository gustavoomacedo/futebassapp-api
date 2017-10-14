using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using web_api_futebass_app.Models;

namespace web_api_futebass_app.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api")]
    public class PartidaController : ApiController
    {
        Entities db = new Entities();

        [Route("partida")]
        public HttpResponseMessage getPartidas()
        {
            var result = db.PARTIDA.ToList();
            return Request.CreateResponse(
                HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("partida")]
        public HttpResponseMessage PostPartida(PARTIDA partida)
        {
            if (partida == null)
                return Request.CreateResponse(HttpStatusCode.NoContent);

            try
            {
                db.PARTIDA.Add(partida);
                db.SaveChanges();

                var result = partida;
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro ao incluir nova partida.");
            }
        }
        
        [Route("partida/jogadores/{id}")]
        public HttpResponseMessage getJogadores(int id)
        {
            if(id == null || id == 0)
                return Request.CreateResponse(HttpStatusCode.NoContent);
            
            List<JOGADOR> jogadores = new List<JOGADOR>();

            var _partidas = (from p in db.PARTIDA where p.PartidaId == id select p).ToList();

            foreach (var item in _partidas)
            {
                var j = new JOGADOR();
                j.JogadorId = item.JogadorId;
                j.Nome = item.JOGADOR.Nome;
                j.Foto = item.JOGADOR.Foto;
                j.Cidade = item.JOGADOR.Foto;
                j.Nivel = item.JOGADOR.Nivel;
                j.IdSocial = item.JOGADOR.IdSocial;
                jogadores.Add(j);
            }

            return Request.CreateResponse(
                HttpStatusCode.OK, jogadores);
        }

        [Route("partida/elenco/{id}")]
        public HttpResponseMessage getPartidas(int id)
        {
            if (id == null || id == 0)
                return Request.CreateResponse(HttpStatusCode.NoContent);

            var _partidas = (from p in db.PARTIDA where p.JogadorId == id select p).ToList();

            return Request.CreateResponse(
                HttpStatusCode.OK, _partidas);
        }

        [HttpPost]
        [Route("partida/elenco")]
        public HttpResponseMessage PostJogar(ELENCO elenco)
        {
            if (elenco == null)
                return Request.CreateResponse(HttpStatusCode.NoContent);

            try
            {
                db.ELENCO.Add(elenco);
                db.SaveChanges();

                var result = elenco;
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro ao incluir novo jogador na partida.");
            }
        }
    }
}
