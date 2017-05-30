using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FerramentaCadastroModelo.Models
{
    public class CategoriaModel
    {
        [Key]
        public int? IDCategoria { get; set; }

        [Required]
        public string Nome { get; set; }


        public virtual ICollection<AreaProcessoModel> AreasProcessos { get; set; }

    }
}