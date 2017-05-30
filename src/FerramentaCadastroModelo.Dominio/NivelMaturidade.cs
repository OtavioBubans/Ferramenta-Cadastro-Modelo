using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerramentaCadastroModelo.Dominio
{
    public class NivelMaturidade
    {

        [Key]
        public int? IDNivelMaturidDade { get; set; }

        [Required]
        public string Sigla { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }

        public virtual ICollection<AreaProcesso> AreasProcessos { get; set; }

        public NivelMaturidade()
        {

        }
    }
}
