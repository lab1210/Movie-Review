namespace Movie_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addslugtoseriescomment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SeriesComments", "Slug", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SeriesComments", "Slug");
        }
    }
}
