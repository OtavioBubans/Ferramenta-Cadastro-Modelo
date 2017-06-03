namespace FerramentaCadastroModelo.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PraticaEspecifica", "ProdutoTrabalho_IDProdutoTrabalho", c => c.Int());
            AddColumn("dbo.ProdutoTrabalho", "Tamplate", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.AreaProcesso", "Sigla", c => c.String(nullable: false, maxLength: 10, unicode: false));
            AlterColumn("dbo.AreaProcesso", "Nome", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.AreaProcesso", "Descricao", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Categoria", "Nome", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.MetaEspecifica", "Sigla", c => c.String(nullable: false, maxLength: 10, unicode: false));
            AlterColumn("dbo.MetaEspecifica", "Nome", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.MetaEspecifica", "Descricao", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.PraticaEspecifica", "Sigla", c => c.String(nullable: false, maxLength: 10, unicode: false));
            AlterColumn("dbo.PraticaEspecifica", "Nome", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.PraticaEspecifica", "Descricao", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Modelo", "Sigla", c => c.String(nullable: false, maxLength: 10, unicode: false));
            AlterColumn("dbo.Modelo", "Nome", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Modelo", "Descricao", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.NivelMaturidade", "Sigla", c => c.String(nullable: false, maxLength: 10, unicode: false));
            AlterColumn("dbo.NivelMaturidade", "Nome", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.NivelMaturidade", "Descricao", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.ProdutoTrabalho", "Nome", c => c.String(nullable: false, maxLength: 50, unicode: false));
            CreateIndex("dbo.PraticaEspecifica", "ProdutoTrabalho_IDProdutoTrabalho");
            AddForeignKey("dbo.PraticaEspecifica", "ProdutoTrabalho_IDProdutoTrabalho", "dbo.ProdutoTrabalho", "IDProdutoTrabalho");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PraticaEspecifica", "ProdutoTrabalho_IDProdutoTrabalho", "dbo.ProdutoTrabalho");
            DropIndex("dbo.PraticaEspecifica", new[] { "ProdutoTrabalho_IDProdutoTrabalho" });
            AlterColumn("dbo.ProdutoTrabalho", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.NivelMaturidade", "Descricao", c => c.String(nullable: false));
            AlterColumn("dbo.NivelMaturidade", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.NivelMaturidade", "Sigla", c => c.String(nullable: false));
            AlterColumn("dbo.Modelo", "Descricao", c => c.String(nullable: false));
            AlterColumn("dbo.Modelo", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Modelo", "Sigla", c => c.String(nullable: false));
            AlterColumn("dbo.PraticaEspecifica", "Descricao", c => c.String(nullable: false));
            AlterColumn("dbo.PraticaEspecifica", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.PraticaEspecifica", "Sigla", c => c.String(nullable: false));
            AlterColumn("dbo.MetaEspecifica", "Descricao", c => c.String(nullable: false));
            AlterColumn("dbo.MetaEspecifica", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.MetaEspecifica", "Sigla", c => c.String(nullable: false));
            AlterColumn("dbo.Categoria", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.AreaProcesso", "Descricao", c => c.String(nullable: false));
            AlterColumn("dbo.AreaProcesso", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.AreaProcesso", "Sigla", c => c.String(nullable: false));
            DropColumn("dbo.ProdutoTrabalho", "Tamplate");
            DropColumn("dbo.PraticaEspecifica", "ProdutoTrabalho_IDProdutoTrabalho");
        }
    }
}
