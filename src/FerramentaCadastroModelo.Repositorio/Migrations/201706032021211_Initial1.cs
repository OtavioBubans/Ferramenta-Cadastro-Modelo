namespace FerramentaCadastroModelo.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MetaGenerica",
                c => new
                    {
                        IDMetaGenerica = c.Int(nullable: false, identity: true),
                        Sigla = c.String(nullable: false, maxLength: 10, unicode: false),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 250, unicode: false),
                        IDModelo = c.Int(nullable: false),
                        IDNivelCapacidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDMetaGenerica)
                .ForeignKey("dbo.Modelo", t => t.IDModelo, cascadeDelete: true)
                .ForeignKey("dbo.NivelCapacidade", t => t.IDNivelCapacidade, cascadeDelete: true)
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MetaGenerica", "IDNivelCapacidade", "dbo.NivelCapacidade");
            DropForeignKey("dbo.MetaGenerica", "IDModelo", "dbo.Modelo");
            DropIndex("dbo.MetaGenerica", new[] { "IDNivelCapacidade" });
            DropIndex("dbo.MetaGenerica", new[] { "IDModelo" });
            DropTable("dbo.NivelCapacidade");
            DropTable("dbo.MetaGenerica");
        }
    }
}
