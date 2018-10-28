namespace DronePostWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePackageSizes : DbMigration
    {
        public override void Up()
        {
            Sql(@"
				INSERT INTO PackageSizes (Name, Height, Width, Length) VALUES ('A', 15, 15, 15)
				INSERT INTO PackageSizes (Name, Height, Width, Length) VALUES ('AA', 15, 15, 45)
				INSERT INTO PackageSizes (Name, Height, Width, Length) VALUES ('B', 30, 30, 30)
				INSERT INTO PackageSizes (Name, Height, Width, Length) VALUES ('BB', 30, 30, 90)
				INSERT INTO PackageSizes (Name, Height, Width, Length) VALUES ('C', 45, 45, 45)
				INSERT INTO PackageSizes (Name, Height, Width, Length) VALUES ('CC', 45, 45, 135)
				INSERT INTO PackageSizes (Name, Height, Width, Length) VALUES ('D', 60, 60, 60)
				INSERT INTO PackageSizes (Name, Height, Width, Length) VALUES ('DD', 60, 60, 180)
				");
        }

        public override void Down()
        {
        }
    }
}
