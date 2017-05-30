using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FerramentaCadastroModelo.Models
{
    public class MetaEspecificaModel
    {
        [Key]
        public int? IDMetaEspecifica { get; set; }


        [Required]
        public string Sigla { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }


        public int IDAreaProcesso { get; set; }

        [ForeignKey("IDAreaProcesso")]
        public virtual AreaProcessoModel AreaProcesso { get; set; }


        public virtual ICollection<PraticaEspecificaModel> PraticasEspecificas { get; set; }
    }
}