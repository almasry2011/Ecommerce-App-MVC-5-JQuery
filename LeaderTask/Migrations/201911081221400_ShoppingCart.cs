namespace LeaderTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShoppingCart : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShoppingCarts", "product_ProductID", "dbo.Products");
            DropIndex("dbo.ShoppingCarts", new[] { "product_ProductID" });
            RenameColumn(table: "dbo.ShoppingCarts", name: "product_ProductID", newName: "ProductID");
            AlterColumn("dbo.ShoppingCarts", "ProductID", c => c.Int(nullable: false));
            CreateIndex("dbo.ShoppingCarts", "ProductID");
            AddForeignKey("dbo.ShoppingCarts", "ProductID", "dbo.Products", "ProductID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "ProductID", "dbo.Products");
            DropIndex("dbo.ShoppingCarts", new[] { "ProductID" });
            AlterColumn("dbo.ShoppingCarts", "ProductID", c => c.Int());
            RenameColumn(table: "dbo.ShoppingCarts", name: "ProductID", newName: "product_ProductID");
            CreateIndex("dbo.ShoppingCarts", "product_ProductID");
            AddForeignKey("dbo.ShoppingCarts", "product_ProductID", "dbo.Products", "ProductID");
        }
    }
}
