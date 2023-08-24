namespace Movie_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSluginmovieandseriesModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "Slug");
            DropColumn("dbo.Series", "Slug");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Series", "Slug", c => c.String());
            AddColumn("dbo.Movies", "Slug", c => c.String());
        }
    }
}
