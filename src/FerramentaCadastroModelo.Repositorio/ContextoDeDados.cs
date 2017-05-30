using FerramentaCadastroModelo.Dominio;
using FerramentaCadastroModelo.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerramentaCadastroModelo.Repositorio
{
    public class ContextoDeDados : DbContext
    {

        public ContextoDeDados() : base("ModeloDeMelhoria")
        {
        }

        public DbSet<Modelo> Modelo { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

    }
}
