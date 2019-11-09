namespace LeaderTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtendOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ShipEmail", c => c.String());
            AddColumn("dbo.Orders", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Phone");
            DropColumn("dbo.Orders", "ShipEmail");
        }
    }
}
