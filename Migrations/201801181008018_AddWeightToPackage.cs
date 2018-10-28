namespace DronePostWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWeightToPackage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Packages", "Weight", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Packages", "Weight");
        }
    }
}
