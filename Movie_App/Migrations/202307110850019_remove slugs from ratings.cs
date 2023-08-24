namespace Movie_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeslugsfromratings : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ratings", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Ratings", new[] { "Movie_Id" });
            DropTable("dbo.Ratings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        User = c.String(),
                        slug = c.String(),
                        Movie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Ratings", "Movie_Id");
            AddForeignKey("dbo.Ratings", "Movie_Id", "dbo.Movies", "Id");
        }
    }
}
