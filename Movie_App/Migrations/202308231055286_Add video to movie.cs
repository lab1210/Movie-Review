namespace Movie_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addvideotomovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "VideoPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "VideoPath");
        }
    }
}
