namespace LeaderTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIdentity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "UserName", c => c.String());
            AddColumn("dbo.Customers", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Password");
            DropColumn("dbo.Customers", "UserName");
        }
    }
}
