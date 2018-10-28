namespace DronePostWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDrones : DbMigration
    {
        public override void Up()
        {
            Sql(" INSERT INTO Drones (Latitude, Wideness, Model_Id) VALUES (\'123\', \'321\', 4)");
        }
        
        public override void Down()
        {
        }
    }
}
