namespace Movie_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Post = c.String(),
                        User = c.String(),
                        PostedDate = c.DateTime(nullable: false),
                        Movie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieComments", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.MovieComments", new[] { "Movie_Id" });
            DropTable("dbo.MovieComments");
        }
    }
}
