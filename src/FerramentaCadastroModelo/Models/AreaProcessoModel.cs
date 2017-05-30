using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FerramentaCadastroModelo.Models
{
    public class AreaProcessoModel
    {
        [Key]
        public int? IDAreaProcesso { get; set; }

        [Required]
        public string Sigla { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }


        public int IDModelo { get; set; }
        [ForeignKey("IDModelo")]
        public virtual ModeloModel Modelo { get; set; }

        public int IDNivelMaturidade { get; set; }
        [ForeignKey("IDNivelMaturidade")]
        public virtual NivelMaturidadeModel NivelMaturidade { get; set; }

        public int IDCategoria { get; set; }
        [ForeignKey("IDCategoria")]
        public virtual CategoriaModel Categoria { get; set; }


        public virtual ICollection<MetaEspecificaModel> MetasEspecificas { get; set; }




    }
}