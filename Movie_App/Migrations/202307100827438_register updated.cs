namespace Movie_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class registerupdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Registers", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Registers", "Password", c => c.String());
        }
    }
}
