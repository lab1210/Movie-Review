namespace Movie_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removenewcomment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovieComments", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Movies", "NewComment_Id", "dbo.MovieComments");
            DropForeignKey("dbo.MovieComments", "MovieId", "dbo.Movies");
            DropIndex("dbo.MovieComments", new[] { "MovieId" });
            DropIndex("dbo.MovieComments", new[] { "Movie_Id" });
            DropIndex("dbo.Movies", new[] { "NewComment_Id" });
            DropColumn("dbo.Movies", "NewComment_Id");
            DropTable("dbo.MovieComments");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "NewComment_Id", c => c.Int());
            CreateIndex("dbo.Movies", "NewComment_Id");
            CreateIndex("dbo.MovieComments", "Movie_Id");
            CreateIndex("dbo.MovieComments", "MovieId");
            AddForeignKey("dbo.MovieComments", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Movies", "NewComment_Id", "dbo.MovieComments", "Id");
            AddForeignKey("dbo.MovieComments", "Movie_Id", "dbo.Movies", "Id");
        }
    }
}
