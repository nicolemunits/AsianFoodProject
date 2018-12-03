namespace AsianFoodProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedata : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order", "CustomerID", "dbo.Customer");
            DropIndex("dbo.Order", new[] { "CustomerID" });
            AddColumn("dbo.Order", "Customer_CustomerID", c => c.Int());
            AlterColumn("dbo.Order", "CustomerID", c => c.String());
            CreateIndex("dbo.Order", "Customer_CustomerID");
            AddForeignKey("dbo.Order", "Customer_CustomerID", "dbo.Customer", "CustomerID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "Customer_CustomerID", "dbo.Customer");
            DropIndex("dbo.Order", new[] { "Customer_CustomerID" });
            AlterColumn("dbo.Order", "CustomerID", c => c.Int(nullable: false));
            DropColumn("dbo.Order", "Customer_CustomerID");
            CreateIndex("dbo.Order", "CustomerID");
            AddForeignKey("dbo.Order", "CustomerID", "dbo.Customer", "CustomerID", cascadeDelete: true);
        }
    }
}
