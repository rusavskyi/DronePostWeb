namespace DronePostWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixSeedAdmin : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO WorkerUsers (UserId, Worker_Id) VALUES ('05ad7abb-88a5-4f9b-8157-c72862fbdefc', 1)");
        }
        
        public override void Down()
        {
        }
    }
}
