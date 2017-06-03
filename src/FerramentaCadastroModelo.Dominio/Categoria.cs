using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerramentaCadastroModelo.Dominio
{
    public class Categoria
    {
        [Key]
        public int? IDCategoria { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Nome { get; set; }


        public virtual ICollection<AreaProcesso> AreasProcessos { get; set; }


        public Categoria()
        {

        }



    }
}
