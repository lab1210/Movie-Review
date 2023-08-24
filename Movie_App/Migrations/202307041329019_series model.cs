namespace Movie_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seriesmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Series",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        Rating = c.String(nullable: false),
                        TicketPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Country = c.String(nullable: false),
                        NumberOfSeasons = c.Int(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SeriesPickedGenres",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        genreid = c.Int(nullable: false),
                        Selected = c.Boolean(nullable: false),
                        Series_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Genres", t => t.genreid, cascadeDelete: true)
                .ForeignKey("dbo.Series", t => t.Series_Id)
                .Index(t => t.genreid)
                .Index(t => t.Series_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SeriesPickedGenres", "Series_Id", "dbo.Series");
            DropForeignKey("dbo.SeriesPickedGenres", "genreid", "dbo.Genres");
            DropIndex("dbo.SeriesPickedGenres", new[] { "Series_Id" });
            DropIndex("dbo.SeriesPickedGenres", new[] { "genreid" });
            DropTable("dbo.SeriesPickedGenres");
            DropTable("dbo.Series");
        }
    }
}
