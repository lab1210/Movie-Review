namespace Movie_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addpending : DbMigration
    {
        public override void Up()
        {
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
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}
