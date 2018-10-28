namespace DronePostWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateWorkerTypes : DbMigration
    {
        public override void Up()
        {
            Sql(@"
				INSERT INTO WorkerTypes (Name) VALUES ('Manager')
				INSERT INTO WorkerTypes (Name) VALUES ('ServiceWorker')
				INSERT INTO WorkerTypes (Name) VALUES ('TechnicalWorker')
				");
        }
        
        public override void Down()
        {
        }
    }
}
