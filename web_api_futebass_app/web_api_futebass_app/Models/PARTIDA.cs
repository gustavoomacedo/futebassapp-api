//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace web_api_futebass_app.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PARTIDA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PARTIDA()
        {
            this.ELENCO = new HashSet<ELENCO>();
        }
    
        public int PartidaId { get; set; }
        public int JogadorId { get; set; }
        public string Observacao { get; set; }
        public int Preco { get; set; }
        public string Tipo { get; set; }
        public string Local { get; set; }
        public string Dia { get; set; }
        public string Hora { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ELENCO> ELENCO { get; set; }
        public virtual JOGADOR JOGADOR { get; set; }
    }
}
