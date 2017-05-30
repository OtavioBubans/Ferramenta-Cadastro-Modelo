using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FerramentaCadastroModelo.Models
{
    public class NivelMaturidadeModel
    {

        [Key]
        public int? IDNivelMaturidDade { get; set; }

        [Required]
        public string Sigla { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }

        public virtual ICollection<AreaProcessoModel> AreasProcessos { get; set; }




    }
}