namespace Movie_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewcomment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User = c.String(),
                        Post = c.String(nullable: false),
                        PostDate = c.DateTime(nullable: false),
                        MovieId = c.Int(nullable: false),
                        Movie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .Index(t => t.MovieId)
                .Index(t => t.Movie_Id);
            
            AddColumn("dbo.Movies", "NewComment_Id", c => c.Int());
            CreateIndex("dbo.Movies", "NewComment_Id");
            AddForeignKey("dbo.Movies", "NewComment_Id", "dbo.MovieComments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "NewComment_Id", "dbo.MovieComments");
            DropForeignKey("dbo.MovieComments", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.MovieComments", "MovieId", "dbo.Movies");
            DropIndex("dbo.MovieComments", new[] { "Movie_Id" });
            DropIndex("dbo.MovieComments", new[] { "MovieId" });
            DropIndex("dbo.Movies", new[] { "NewComment_Id" });
            DropColumn("dbo.Movies", "NewComment_Id");
            DropTable("dbo.MovieComments");
        }
    }
}
