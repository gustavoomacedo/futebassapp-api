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
    public class JogadorController : ApiController
    {
        Entities db = new Entities();

        [Route("jogador/{id}")]
        public HttpResponseMessage getJogador(string id)
        {
            var result = db.JOGADOR.Where(x => x.IdSocial == id).SingleOrDefault();
            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                return Request.CreateResponse(
                HttpStatusCode.OK, result);
            }
        }

        [HttpPost]
        [Route("jogador")]
        public HttpResponseMessage PostJogador(JOGADOR jogador)
        {
            if (jogador == null)
                return Request.CreateResponse(HttpStatusCode.NoContent);

            try
            {
                db.JOGADOR.Add(jogador);
                db.SaveChanges();

                var result = jogador;
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro ao incluir novo jogador.");
            }
        }
    }
}
