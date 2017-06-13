using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Nome { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string NomeArquivo { get; set; }


        [Column(TypeName = "varbinary(max)")]
        public byte[] Tamplate { get; set; }

       // public virtual ICollection<PraticaEspecifica> PraticaEspecifica { get; set; }

        public virtual ICollection<ProdutoTrabalhoXPraticaEspecifica> ProdutoTrabalhoXPraticaEspecifica { get; set; }



        public ProdutoTrabalho()
        {

        }



    }
}
