using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerramentaCadastroModelo.Dominio
{
    public class MetaEspecifica
    {

        [Key]
        public int? IDMetaEspecifica { get; set; }


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


        public int? IDAreaProcesso { get; set; }
        [ForeignKey("IDAreaProcesso")]
        public virtual AreaProcesso AreaProcesso { get; set; }


        public virtual ICollection<PraticaEspecifica> PraticasEspecificas { get; set; }

        public MetaEspecifica()
        {

        }
    }
}
