using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerramentaCadastroModelo.Dominio
{
    public class ProdutoTrabalhoXPraticaEspecifica
    {

     //   [Key]
     //   public int? IDProdutoXPraticaEs { get; set; }

        [Key]
        [Column(Order = 1)]
        public int? IDPraticaEspecifica { get; set; }
        //  [Key("IDPraticaEspecifica")]
        //  public virtual PraticaEspecifica PraticaEspecifica { get; set; }

        [Key]
        [Column(Order = 2)]
        public int? IDProdutoTrabalho { get; set; }
      //  [ForeignKey("IDProdutoTrabalho")]
      //  public virtual ProdutoTrabalho ProdutoTrabalho { get; set; }
    }
}
