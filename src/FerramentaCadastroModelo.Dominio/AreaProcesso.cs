using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerramentaCadastroModelo.Dominio
{
    public class AreaProcesso
    {

        [Key]
        public int? IDAreaProcesso { get; set; }

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


        public int IDModelo { get; set; }

        [ForeignKey("IDModelo")]
        public virtual Modelo Modelo { get; set; }

        public int IDNivelMaturidade { get; set; }

        [ForeignKey("IDNivelMaturidade")]
        public virtual NivelMaturidade NivelMaturidade { get; set; }

        public int IDCategoria { get; set; }

        [ForeignKey("IDCategoria")]
        public virtual Categoria Categoria { get; set; }


        public virtual ICollection<MetaEspecifica> MetasEspecificas { get; set; }

        public AreaProcesso()
        {

        }
    }
}
