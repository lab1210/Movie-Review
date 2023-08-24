namespace Movie_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addnewratings : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ratings", "MovieID", "dbo.Movies");
            AddColumn("dbo.Movies", "NewRating_Id", c => c.Int());
            AddColumn("dbo.Ratings", "Movie_Id", c => c.Int());
            CreateIndex("dbo.Movies", "NewRating_Id");
            CreateIndex("dbo.Ratings", "Movie_Id");
            AddForeignKey("dbo.Movies", "NewRating_Id", "dbo.Ratings", "Id");
            AddForeignKey("dbo.Ratings", "Movie_Id", "dbo.Movies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Movies", "NewRating_Id", "dbo.Ratings");
            DropIndex("dbo.Ratings", new[] { "Movie_Id" });
            DropIndex("dbo.Movies", new[] { "NewRating_Id" });
            DropColumn("dbo.Ratings", "Movie_Id");
            DropColumn("dbo.Movies", "NewRating_Id");
            AddForeignKey("dbo.Ratings", "MovieID", "dbo.Movies", "Id", cascadeDelete: true);
        }
    }
}
