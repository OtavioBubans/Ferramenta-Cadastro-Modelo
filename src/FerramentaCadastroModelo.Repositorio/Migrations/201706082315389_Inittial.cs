namespace FerramentaCadastroModelo.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inittial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AreaProcesso",
                c => new
                    {
                        IDAreaProcesso = c.Int(nullable: false, identity: true),
                        Sigla = c.String(nullable: false, maxLength: 10, unicode: false),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 250, unicode: false),
                        IDModelo = c.Int(),
                        IDNivelMaturidade = c.Int(),
                        IDCategoria = c.Int(),
                    })
                .PrimaryKey(t => t.IDAreaProcesso)
                .ForeignKey("dbo.Categoria", t => t.IDCategoria)
                .ForeignKey("dbo.Modelo", t => t.IDModelo)
                .ForeignKey("dbo.NivelMaturidade", t => t.IDNivelMaturidade)
                .Index(t => t.IDModelo)
                .Index(t => t.IDNivelMaturidade)
                .Index(t => t.IDCategoria);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        IDCategoria = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.IDCategoria);
            
            CreateTable(
                "dbo.MetaEspecifica",
                c => new
                    {
                        IDMetaEspecifica = c.Int(nullable: false, identity: true),
                        Sigla = c.String(nullable: false, maxLength: 10, unicode: false),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 250, unicode: false),
                        IDAreaProcesso = c.Int(),
                    })
                .PrimaryKey(t => t.IDMetaEspecifica)
                .ForeignKey("dbo.AreaProcesso", t => t.IDAreaProcesso)
                .Index(t => t.IDAreaProcesso);
            
            CreateTable(
                "dbo.PraticaEspecifica",
                c => new
                    {
                        IDPraticaEspecifica = c.Int(nullable: false, identity: true),
                        Sigla = c.String(nullable: false, maxLength: 10, unicode: false),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 250, unicode: false),
                        IDMetaEspecifica = c.Int(),
                        ProdutoTrabalho_IDProdutoTrabalho = c.Int(),
                    })
                .PrimaryKey(t => t.IDPraticaEspecifica)
                .ForeignKey("dbo.MetaEspecifica", t => t.IDMetaEspecifica)
                .ForeignKey("dbo.ProdutoTrabalho", t => t.ProdutoTrabalho_IDProdutoTrabalho)
                .Index(t => t.IDMetaEspecifica)
                .Index(t => t.ProdutoTrabalho_IDProdutoTrabalho);
            
            CreateTable(
                "dbo.Modelo",
                c => new
                    {
                        IDModelo = c.Int(nullable: false, identity: true),
                        Sigla = c.String(nullable: false, maxLength: 10, unicode: false),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.IDModelo);
            
            CreateTable(
                "dbo.NivelMaturidade",
                c => new
                    {
                        IDNivelMaturidade = c.Int(nullable: false, identity: true),
                        Sigla = c.String(nullable: false, maxLength: 10, unicode: false),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.IDNivelMaturidade);
            
            CreateTable(
                "dbo.MetaGenerica",
                c => new
                    {
                        IDMetaGenerica = c.Int(nullable: false, identity: true),
                        Sigla = c.String(nullable: false, maxLength: 10, unicode: false),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 250, unicode: false),
                        IDModelo = c.Int(),
                        IDNivelCapacidade = c.Int(),
                    })
                .PrimaryKey(t => t.IDMetaGenerica)
                .ForeignKey("dbo.Modelo", t => t.IDModelo)
                .ForeignKey("dbo.NivelCapacidade", t => t.IDNivelCapacidade)
                .Index(t => t.IDModelo)
                .Index(t => t.IDNivelCapacidade);
            
            CreateTable(
                "dbo.NivelCapacidade",
                c => new
                    {
                        IDNivelCapacidade = c.Int(nullable: false, identity: true),
                        SiglaNivelCapacidade = c.String(maxLength: 10, unicode: false),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.IDNivelCapacidade);
            
            CreateTable(
                "dbo.ProdutoTrabalho",
                c => new
                    {
                        IDProdutoTrabalho = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Tamplate = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.IDProdutoTrabalho);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PraticaEspecifica", "ProdutoTrabalho_IDProdutoTrabalho", "dbo.ProdutoTrabalho");
            DropForeignKey("dbo.MetaGenerica", "IDNivelCapacidade", "dbo.NivelCapacidade");
            DropForeignKey("dbo.MetaGenerica", "IDModelo", "dbo.Modelo");
            DropForeignKey("dbo.AreaProcesso", "IDNivelMaturidade", "dbo.NivelMaturidade");
            DropForeignKey("dbo.AreaProcesso", "IDModelo", "dbo.Modelo");
            DropForeignKey("dbo.PraticaEspecifica", "IDMetaEspecifica", "dbo.MetaEspecifica");
            DropForeignKey("dbo.MetaEspecifica", "IDAreaProcesso", "dbo.AreaProcesso");
            DropForeignKey("dbo.AreaProcesso", "IDCategoria", "dbo.Categoria");
            DropIndex("dbo.MetaGenerica", new[] { "IDNivelCapacidade" });
            DropIndex("dbo.MetaGenerica", new[] { "IDModelo" });
            DropIndex("dbo.PraticaEspecifica", new[] { "ProdutoTrabalho_IDProdutoTrabalho" });
            DropIndex("dbo.PraticaEspecifica", new[] { "IDMetaEspecifica" });
            DropIndex("dbo.MetaEspecifica", new[] { "IDAreaProcesso" });
            DropIndex("dbo.AreaProcesso", new[] { "IDCategoria" });
            DropIndex("dbo.AreaProcesso", new[] { "IDNivelMaturidade" });
            DropIndex("dbo.AreaProcesso", new[] { "IDModelo" });
            DropTable("dbo.ProdutoTrabalho");
            DropTable("dbo.NivelCapacidade");
            DropTable("dbo.MetaGenerica");
            DropTable("dbo.NivelMaturidade");
            DropTable("dbo.Modelo");
            DropTable("dbo.PraticaEspecifica");
            DropTable("dbo.MetaEspecifica");
            DropTable("dbo.Categoria");
            DropTable("dbo.AreaProcesso");
        }
    }
}
