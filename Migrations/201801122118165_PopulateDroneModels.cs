namespace DronePostWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDroneModels : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO DroneModels (Name, MaxWeight, MaxDistance, MaxPackageSize_Id) VALUES ('Universal', 200.0, 10000.0, 8)");
        }
        
        public override void Down()
        {
        }
    }
}
