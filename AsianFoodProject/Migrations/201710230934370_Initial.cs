namespace AsianFoodProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Categories_CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryID)
                .ForeignKey("dbo.Category", t => t.Categories_CategoryID)
                .Index(t => t.Categories_CategoryID);
            
            CreateTable(
                "dbo.Food",
                c => new
                    {
                        FoodID = c.Int(nullable: false, identity: true),
                        FoodName = c.String(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        IsVegetarian = c.Boolean(nullable: false),
                        FoodPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.FoodID)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        OrderPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FoodID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Food", t => t.FoodID, cascadeDelete: true)
                .Index(t => t.FoodID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FirstName = c.String(nullable: false, maxLength: 10),
                        LastName = c.String(nullable: false, maxLength: 10),
                        PhoneNumber = c.String(nullable: false),
                        Address = c.String(nullable: false, maxLength: 35),
                    })
                .PrimaryKey(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "FoodID", "dbo.Food");
            DropForeignKey("dbo.Order", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Food", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Category", "Categories_CategoryID", "dbo.Category");
            DropIndex("dbo.Order", new[] { "CustomerID" });
            DropIndex("dbo.Order", new[] { "FoodID" });
            DropIndex("dbo.Food", new[] { "CategoryId" });
            DropIndex("dbo.Category", new[] { "Categories_CategoryID" });
            DropTable("dbo.Customer");
            DropTable("dbo.Order");
            DropTable("dbo.Food");
            DropTable("dbo.Category");
        }
    }
}
