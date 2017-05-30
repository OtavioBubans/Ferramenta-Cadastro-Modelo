using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FerramentaCadastroModelo.Models
{
    public class ModeloModel
    {
        [Key]
        public int? IDModel { get; set;}

        [Required]
        public string Sigla { get; set; }

        [Required]
        public string Nome { get; set;}

        [Required]
        public string Descricao { get; set;}

        [Required]
        public virtual ICollection<AreaProcessoModel> AreaProcessoModel { get; set; }


        public ModeloModel()
        {

        }
    }
}