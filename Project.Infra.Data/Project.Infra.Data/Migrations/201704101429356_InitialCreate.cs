namespace Project.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.SubCategorias",
                c => new
                    {
                        SubCategoriaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30, unicode: false),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubCategoriaId)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 150, unicode: false),
                        Detalhes = c.String(nullable: false, maxLength: 1500, unicode: false),
                        CategoriaId = c.Int(nullable: false),
                        SubCategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId)
                .ForeignKey("dbo.SubCategorias", t => t.SubCategoriaId)
                .Index(t => t.CategoriaId)
                .Index(t => t.SubCategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "SubCategoriaId", "dbo.SubCategorias");
            DropForeignKey("dbo.Produtos", "CategoriaId", "dbo.Categorias");
            DropForeignKey("dbo.SubCategorias", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Produtos", new[] { "SubCategoriaId" });
            DropIndex("dbo.Produtos", new[] { "CategoriaId" });
            DropIndex("dbo.SubCategorias", new[] { "CategoriaId" });
            DropTable("dbo.Produtos");
            DropTable("dbo.SubCategorias");
            DropTable("dbo.Categorias");
        }
    }
}
