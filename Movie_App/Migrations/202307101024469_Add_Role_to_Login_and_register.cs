namespace Movie_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Role_to_Login_and_register : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logins", "Role", c => c.String());
            AddColumn("dbo.Registers", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Registers", "Role");
            DropColumn("dbo.Logins", "Role");
        }
    }
}
