namespace FerramentaCadastroModelo.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AreaProcesso",
                c => new
                    {
                        IDAreaProcesso = c.Int(nullable: false, identity: true),
                        Sigla = c.String(nullable: false),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(nullable: false),
                        IDModelo = c.Int(nullable: false),
                        IDNivelMaturidade = c.Int(nullable: false),
                        IDCategoria = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDAreaProcesso)
                .ForeignKey("dbo.Categoria", t => t.IDCategoria, cascadeDelete: true)
                .ForeignKey("dbo.Modelo", t => t.IDModelo, cascadeDelete: true)
                .ForeignKey("dbo.NivelMaturidade", t => t.IDNivelMaturidade, cascadeDelete: true)
                .Index(t => t.IDModelo)
                .Index(t => t.IDNivelMaturidade)
                .Index(t => t.IDCategoria);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        IDCategoria = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IDCategoria);
            
            CreateTable(
                "dbo.MetaEspecifica",
                c => new
                    {
                        IDMetaEspecifica = c.Int(nullable: false, identity: true),
                        Sigla = c.String(nullable: false),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(nullable: false),
                        IDAreaProcesso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDMetaEspecifica)
                .ForeignKey("dbo.AreaProcesso", t => t.IDAreaProcesso, cascadeDelete: true)
                .Index(t => t.IDAreaProcesso);
            
            CreateTable(
                "dbo.PraticaEspecifica",
                c => new
                    {
                        IDPraticaEspecifica = c.Int(nullable: false, identity: true),
                        Sigla = c.String(nullable: false),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(nullable: false),
                        IDMetaEspecifica = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDPraticaEspecifica)
                .ForeignKey("dbo.MetaEspecifica", t => t.IDMetaEspecifica, cascadeDelete: true)
                .Index(t => t.IDMetaEspecifica);
            
            CreateTable(
                "dbo.Modelo",
                c => new
                    {
                        IDModelo = c.Int(nullable: false, identity: true),
                        Sigla = c.String(nullable: false),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IDModelo);
            
            CreateTable(
                "dbo.NivelMaturidade",
                c => new
                    {
                        IDNivelMaturidDade = c.Int(nullable: false, identity: true),
                        Sigla = c.String(nullable: false),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IDNivelMaturidDade);
            
            CreateTable(
                "dbo.ProdutoTrabalho",
                c => new
                    {
                        IDProdutoTrabalho = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IDProdutoTrabalho);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AreaProcesso", "IDNivelMaturidade", "dbo.NivelMaturidade");
            DropForeignKey("dbo.AreaProcesso", "IDModelo", "dbo.Modelo");
            DropForeignKey("dbo.PraticaEspecifica", "IDMetaEspecifica", "dbo.MetaEspecifica");
            DropForeignKey("dbo.MetaEspecifica", "IDAreaProcesso", "dbo.AreaProcesso");
            DropForeignKey("dbo.AreaProcesso", "IDCategoria", "dbo.Categoria");
            DropIndex("dbo.PraticaEspecifica", new[] { "IDMetaEspecifica" });
            DropIndex("dbo.MetaEspecifica", new[] { "IDAreaProcesso" });
            DropIndex("dbo.AreaProcesso", new[] { "IDCategoria" });
            DropIndex("dbo.AreaProcesso", new[] { "IDNivelMaturidade" });
            DropIndex("dbo.AreaProcesso", new[] { "IDModelo" });
            DropTable("dbo.ProdutoTrabalho");
            DropTable("dbo.NivelMaturidade");
            DropTable("dbo.Modelo");
            DropTable("dbo.PraticaEspecifica");
            DropTable("dbo.MetaEspecifica");
            DropTable("dbo.Categoria");
            DropTable("dbo.AreaProcesso");
        }
    }
}
