namespace Movie_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSluginmovieandseriesModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Slug", c => c.String());
            AddColumn("dbo.Series", "Slug", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Series", "Slug");
            DropColumn("dbo.Movies", "Slug");
        }
    }
}
