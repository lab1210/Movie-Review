namespace Movie_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class regupdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Registers", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Registers", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Registers", "Email", c => c.String());
            AlterColumn("dbo.Registers", "UserName", c => c.String());
        }
    }
}
