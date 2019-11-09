namespace LeaderTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addShoppingCart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        amount = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Username = c.String(),
                        product_ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.product_ProductID)
                .Index(t => t.product_ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "product_ProductID", "dbo.Products");
            DropIndex("dbo.ShoppingCarts", new[] { "product_ProductID" });
            DropTable("dbo.ShoppingCarts");
        }
    }
}
