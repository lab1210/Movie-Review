namespace Movie_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewcommenttoseries : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SeriesComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User = c.String(),
                        Post = c.String(nullable: false),
                        PostDate = c.DateTime(nullable: false),
                        SeriesId = c.Int(nullable: false),
                        Series_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Series", t => t.SeriesId, cascadeDelete: true)
                .ForeignKey("dbo.Series", t => t.Series_Id)
                .Index(t => t.SeriesId)
                .Index(t => t.Series_Id);
            
            AddColumn("dbo.Series", "NewComment_Id", c => c.Int());
            CreateIndex("dbo.Series", "NewComment_Id");
            AddForeignKey("dbo.Series", "NewComment_Id", "dbo.SeriesComments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SeriesComments", "Series_Id", "dbo.Series");
            DropForeignKey("dbo.Series", "NewComment_Id", "dbo.SeriesComments");
            DropForeignKey("dbo.SeriesComments", "SeriesId", "dbo.Series");
            DropIndex("dbo.SeriesComments", new[] { "Series_Id" });
            DropIndex("dbo.SeriesComments", new[] { "SeriesId" });
            DropIndex("dbo.Series", new[] { "NewComment_Id" });
            DropColumn("dbo.Series", "NewComment_Id");
            DropTable("dbo.SeriesComments");
        }
    }
}
