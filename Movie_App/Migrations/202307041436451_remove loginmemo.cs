namespace Movie_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeloginmemo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovieComments", "LoginMemoID", "dbo.LoginMemoes");
            DropIndex("dbo.MovieComments", new[] { "LoginMemoID" });
            DropColumn("dbo.MovieComments", "LoginMemoID");
            DropTable("dbo.LoginMemoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LoginMemoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.MovieComments", "LoginMemoID", c => c.Int(nullable: false));
            CreateIndex("dbo.MovieComments", "LoginMemoID");
            AddForeignKey("dbo.MovieComments", "LoginMemoID", "dbo.LoginMemoes", "ID", cascadeDelete: true);
        }
    }
}
