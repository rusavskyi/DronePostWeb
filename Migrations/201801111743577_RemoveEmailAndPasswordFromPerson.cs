namespace DronePostWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveEmailAndPasswordFromPerson : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Consumers", "Email");
            DropColumn("dbo.Consumers", "Password");
            DropColumn("dbo.Workers", "Email");
            DropColumn("dbo.Workers", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workers", "Password", c => c.String(nullable: false));
            AddColumn("dbo.Workers", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Consumers", "Password", c => c.String(nullable: false));
            AddColumn("dbo.Consumers", "Email", c => c.String(nullable: false));
        }
    }
}
