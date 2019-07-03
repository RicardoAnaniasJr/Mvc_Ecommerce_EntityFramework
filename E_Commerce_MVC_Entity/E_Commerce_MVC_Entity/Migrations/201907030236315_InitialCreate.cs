namespace E_Commerce_MVC_Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carrinhoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        ProductId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produtoes", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 45),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        LastUpdated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 45),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProdutoPedidoes",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        CustomerOrderId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.CustomerOrderId })
                .ForeignKey("dbo.OrdemClientes", t => t.CustomerOrderId, cascadeDelete: true)
                .ForeignKey("dbo.Produtoes", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.CustomerOrderId);
            
            CreateTable(
                "dbo.OrdemClientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 160),
                        LastName = c.String(nullable: false, maxLength: 160),
                        Address = c.String(nullable: false, maxLength: 70),
                        City = c.String(nullable: false, maxLength: 40),
                        State = c.String(nullable: false, maxLength: 40),
                        PostalCode = c.String(nullable: false, maxLength: 10),
                        Country = c.String(nullable: false, maxLength: 40),
                        Phone = c.String(nullable: false, maxLength: 24),
                        Email = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerUserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carrinhoes", "ProductId", "dbo.Produtoes");
            DropForeignKey("dbo.ProdutoPedidoes", "ProductId", "dbo.Produtoes");
            DropForeignKey("dbo.ProdutoPedidoes", "CustomerOrderId", "dbo.OrdemClientes");
            DropForeignKey("dbo.Produtoes", "CategoryId", "dbo.Categorias");
            DropIndex("dbo.ProdutoPedidoes", new[] { "CustomerOrderId" });
            DropIndex("dbo.ProdutoPedidoes", new[] { "ProductId" });
            DropIndex("dbo.Produtoes", new[] { "CategoryId" });
            DropIndex("dbo.Carrinhoes", new[] { "ProductId" });
            DropTable("dbo.Clientes");
            DropTable("dbo.OrdemClientes");
            DropTable("dbo.ProdutoPedidoes");
            DropTable("dbo.Categorias");
            DropTable("dbo.Produtoes");
            DropTable("dbo.Carrinhoes");
        }
    }
}
