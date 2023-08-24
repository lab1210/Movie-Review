namespace Movie_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addratingtomovie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movie_Rating",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        rating = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movie_Rating", "MovieId", "dbo.Movies");
            DropIndex("dbo.Movie_Rating", new[] { "MovieId" });
            DropTable("dbo.Movie_Rating");
        }
    }
}
