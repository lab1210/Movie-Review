namespace Movie_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moviemodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        Rating = c.String(nullable: false),
                        TicketPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Country = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PickedGenres",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        genreid = c.Int(nullable: false),
                        Selected = c.Boolean(nullable: false),
                        Movie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Genres", t => t.genreid, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .Index(t => t.genreid)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PickedGenres", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.PickedGenres", "genreid", "dbo.Genres");
            DropIndex("dbo.PickedGenres", new[] { "Movie_Id" });
            DropIndex("dbo.PickedGenres", new[] { "genreid" });
            DropTable("dbo.PickedGenres");
            DropTable("dbo.Movies");
        }
    }
}
