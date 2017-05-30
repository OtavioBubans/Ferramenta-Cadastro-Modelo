using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FerramentaCadastroModelo.Models
{
    public class ModeloModel
    {
        
        public int? Id { get; set;}

        [Required]
        public string Sigla { get; set; }

        [Required]
        public string Nome { get; set;}

        [Required]
        public string Descricao { get; set;}


        public ModeloModel()
        {

        }
    }
}