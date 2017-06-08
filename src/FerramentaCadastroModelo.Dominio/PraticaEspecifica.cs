using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerramentaCadastroModelo.Dominio
{
    public class PraticaEspecifica
    {
        [Key]
        public int? IDPraticaEspecifica { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(10)]
        public string Sigla { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Descricao { get; set; }

        
        public int? IDMetaEspecifica { get; set; }
        [ForeignKey("IDMetaEspecifica")]
        public virtual MetaEspecifica MetaEspecifica { get; set; }

        public PraticaEspecifica()
        {

        }

    }
}
