using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FerramentaCadastroModelo.Models
{
    public class PraticaEspecificaModel
    {
        [Key]
        public int? IDPraticaEspecifica { get; set; }

        [Required]
        public string Sigla { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }


        public int IDMetaEspecifica { get; set; }

        [ForeignKey("IDMetaEspecifica")]
        public virtual MetaEspecificaModel MetaEspecifica { get; set; }

        public virtual ICollection<ProdutoTrabalhoModel> ProdutoTrabalhoModel { get; set; }



    }
}