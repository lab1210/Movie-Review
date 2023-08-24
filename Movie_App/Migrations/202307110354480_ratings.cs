namespace Movie_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ratings : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movie_Rating", "MovieId", "dbo.Movies");
            DropIndex("dbo.Movie_Rating", new[] { "MovieId" });
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
            AddColumn("dbo.Movies", "AverageRating", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropTable("dbo.Movie_Rating");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Movie_Rating",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        rating = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                        User = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Ratings", "MovieId", "dbo.Movies");
            DropIndex("dbo.Ratings", new[] { "MovieId" });
            DropColumn("dbo.Movies", "AverageRating");
            DropTable("dbo.Ratings");
            CreateIndex("dbo.Movie_Rating", "MovieId");
            AddForeignKey("dbo.Movie_Rating", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
        }
    }
}
