namespace Movie_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loginmemo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoginMemoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Ratings", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.Ratings", "Login_ID", c => c.Int());
            CreateIndex("dbo.Ratings", "Login_ID");
            AddForeignKey("dbo.Ratings", "Login_ID", "dbo.Logins", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "Login_ID", "dbo.Logins");
            DropIndex("dbo.Ratings", new[] { "Login_ID" });
            DropColumn("dbo.Ratings", "Login_ID");
            DropColumn("dbo.Ratings", "UserID");
            DropTable("dbo.LoginMemoes");
        }
    }
}
