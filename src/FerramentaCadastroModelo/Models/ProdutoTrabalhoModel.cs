using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string NomeArquivo { get; set; }

        [Column(TypeName = "varbinary(max)")]
        public byte[] Tamplate { get; set; }


        public int? IDPraticaEspecifica { get; set; }
        [ForeignKey("IDPraticaEspecifica")]
        public virtual PraticaEspecificaModel PraticaEspecificaModel { get; set; }

    }
}