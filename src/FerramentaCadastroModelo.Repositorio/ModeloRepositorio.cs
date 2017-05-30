using FerramentaCadastroModelo.Dominio;
using FerramentaCadastroModelo.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerramentaCadastroModelo.Repositorio
{
    public class ModeloRepositorio :IModeloRepositorio
    {
        public void Salvar(Modelo modelo)
        {
            using (var contexto = new ContextoDeDados())
            {
                contexto.Modelo.Add(modelo);
                contexto.SaveChanges();
            }

        }

    }
}
