using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FerramentaCadastroModelo.Models
{
    public class ProdutoTrabalhoModel
    {

        [Key]
        public int? IDProdutoTrabalho { get; set; }

        [Required]
        public string Nome { get; set; }



    }
}