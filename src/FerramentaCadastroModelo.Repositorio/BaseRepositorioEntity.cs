using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerramentaCadastroModelo.Repositorio
{
    public abstract class BaseRepositorioEntity
    {

        protected string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ModeloDeMelhoria"].ConnectionString;

            }
        }


    }
}
