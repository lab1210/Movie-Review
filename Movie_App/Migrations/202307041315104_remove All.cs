namespace Movie_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeAll : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PickedGenres", "genreid", "dbo.Genres");
            DropForeignKey("dbo.PickedGenres", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.PickedGenres", new[] { "genreid" });
            DropIndex("dbo.PickedGenres", new[] { "Movie_Id" });
            DropTable("dbo.Genres");
            DropTable("dbo.Movies");
            DropTable("dbo.PickedGenres");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.id);
            
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
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.PickedGenres", "Movie_Id");
            CreateIndex("dbo.PickedGenres", "genreid");
            AddForeignKey("dbo.PickedGenres", "Movie_Id", "dbo.Movies", "Id");
            AddForeignKey("dbo.PickedGenres", "genreid", "dbo.Genres", "Id", cascadeDelete: true);
        }
    }
}
