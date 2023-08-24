namespace Movie_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addratingtoseries : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SeriesRatings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        SeriesID = c.Int(nullable: false),
                        UserName = c.String(),
                        Slug = c.String(),
                        Series_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Series", t => t.SeriesID, cascadeDelete: true)
                .ForeignKey("dbo.Series", t => t.Series_Id)
                .Index(t => t.SeriesID)
                .Index(t => t.Series_Id);
            
            AddColumn("dbo.Series", "NewSeriesRating_Id", c => c.Int());
            CreateIndex("dbo.Series", "NewSeriesRating_Id");
            AddForeignKey("dbo.Series", "NewSeriesRating_Id", "dbo.SeriesRatings", "Id");
            DropColumn("dbo.Series", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Series", "Rating", c => c.String(nullable: false));
            DropForeignKey("dbo.SeriesRatings", "Series_Id", "dbo.Series");
            DropForeignKey("dbo.Series", "NewSeriesRating_Id", "dbo.SeriesRatings");
            DropForeignKey("dbo.SeriesRatings", "SeriesID", "dbo.Series");
            DropIndex("dbo.SeriesRatings", new[] { "Series_Id" });
            DropIndex("dbo.SeriesRatings", new[] { "SeriesID" });
            DropIndex("dbo.Series", new[] { "NewSeriesRating_Id" });
            DropColumn("dbo.Series", "NewSeriesRating_Id");
            DropTable("dbo.SeriesRatings");
        }
    }
}
