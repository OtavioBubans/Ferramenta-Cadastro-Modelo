using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerramentaCadastroModelo.Dominio
{
    public class NivelCapacidade
    {

        [Key]
        public int? IDNivelCapacidade { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(10)]
      //  [Index(IsUnique = true)]
        public string SiglaNivelCapacidade { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Descricao { get; set; }


        public virtual ICollection<MetaGenerica> MetaGenerica { get; set; }


    }
}
