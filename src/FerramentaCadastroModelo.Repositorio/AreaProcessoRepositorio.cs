using FerramentaCadastroModelo.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FerramentaCadastroModelo.Dominio;

namespace FerramentaCadastroModelo.Repositorio
{
    public class AreaProcessoRepositorio : IAreaProcessoRepositorio
    {
        public void Salvar(AreaProcesso areaProcesso)
        {
            using (var contexto = new ContextoDeDados())
            {
                contexto.AreaProcesso.Add(areaProcesso);
                contexto.SaveChanges();
            }
        }
    }
}
