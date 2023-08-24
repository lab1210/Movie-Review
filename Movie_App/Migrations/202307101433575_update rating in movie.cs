namespace Movie_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateratinginmovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movie_Rating", "User", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movie_Rating", "User");
        }
    }
}
