namespace Movie_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addratings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ratings", "UserName", c => c.String());
            DropColumn("dbo.Ratings", "User");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ratings", "User", c => c.String());
            DropColumn("dbo.Ratings", "UserName");
        }
    }
}
