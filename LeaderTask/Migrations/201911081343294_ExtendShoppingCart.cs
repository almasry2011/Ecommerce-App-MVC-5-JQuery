namespace LeaderTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtendShoppingCart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShoppingCarts", "CustomerID", c => c.Int(nullable: false));
            CreateIndex("dbo.ShoppingCarts", "CustomerID");
            AddForeignKey("dbo.ShoppingCarts", "CustomerID", "dbo.Customers", "CustomerID", cascadeDelete: true);
            DropColumn("dbo.ShoppingCarts", "Username");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShoppingCarts", "Username", c => c.String());
            DropForeignKey("dbo.ShoppingCarts", "CustomerID", "dbo.Customers");
            DropIndex("dbo.ShoppingCarts", new[] { "CustomerID" });
            DropColumn("dbo.ShoppingCarts", "CustomerID");
        }
    }
}
