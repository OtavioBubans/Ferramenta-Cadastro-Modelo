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

        public DbSet<AreaProcesso> AreaProcesso { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<MetaEspecifica> MetaEspecifica { get; set; }
        public DbSet<MetaGenerica> MetaGenerica { get; set; }
        public DbSet<Modelo> Modelo { get; set; }
        public DbSet<NivelMaturidade> NivelMaturidade { get; set; }
        public DbSet<NivelCapacidade> NivelCapacidade { get; set; }
        public DbSet<PraticaEspecifica> PraticaEspecifica { get; set; }
        public DbSet<ProdutoTrabalho> ProdutoTrabalho { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

    }
}
