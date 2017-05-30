using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerramentaCadastroModelo.Dominio
{
    public class Modelo
    {
        [Key]
        public int? IDModelo { get; set; }

        [Required]
        public string Sigla { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public virtual ICollection<AreaProcesso> AreaProcesso { get; set; }


        public Modelo()
        {

        }
    }
}
