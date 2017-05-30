using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerramentaCadastroModelo.Dominio
{
    public class ProdutoTrabalho
    {

        [Key]
        public int? IDProdutoTrabalho { get; set; }

        [Required]
        public string Nome { get; set; }

        public ProdutoTrabalho()
        {

        }



    }
}
