using FerramentaCadastroModelo.Dominio;
using FerramentaCadastroModelo.Dominio.Interfaces;
using FerramentaCadastroModelo.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerramentaCadastroModelo.Aplicativo
{
    public class AreaProcessoAplicativo
    {
        private readonly IAreaProcessoRepositorio repositorio;

        public AreaProcessoAplicativo()
        {
            this.repositorio = new AreaProcessoRepositorio();
        }

        public void Salvar(AreaProcesso areaProcesso)
        {
            repositorio.Salvar(areaProcesso);
        }
    }
}
