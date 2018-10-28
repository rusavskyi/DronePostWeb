namespace DronePostWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixes0 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workers", "EmployementDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Workers", "EmploymentDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workers", "EmploymentDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Workers", "EmployementDate");
        }
    }
}
