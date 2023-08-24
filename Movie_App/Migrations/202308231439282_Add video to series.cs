namespace Movie_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addvideotoseries : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Series", "VideoPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Series", "VideoPath");
        }
    }
}
