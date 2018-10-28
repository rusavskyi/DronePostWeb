namespace DronePostWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSaleryFieldToWorker : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workers", "Salery", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workers", "Salery");
        }
    }
}
