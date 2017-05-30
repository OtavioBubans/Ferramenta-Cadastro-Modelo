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
    public class ModeloAplicativo
    {

        private readonly IModeloRepositorio repositorio;


        public ModeloAplicativo()
        {
            this.repositorio = new ModeloRepositorio();
        }


        public void Salvar(Modelo modelo)
        {
           // if (modelo.Id == 0)
                repositorio.Salvar(modelo);
            //else
            //    repositorio.Editar(modelo);
        }
    }
}
