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
    
    public partial class JOGADOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JOGADOR()
        {
            this.ELENCO = new HashSet<ELENCO>();
            this.PARTIDA = new HashSet<PARTIDA>();
        }
    
        public int JogadorId { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Foto { get; set; }
        public string Nivel { get; set; }
        public string IdSocial { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ELENCO> ELENCO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PARTIDA> PARTIDA { get; set; }
    }
}