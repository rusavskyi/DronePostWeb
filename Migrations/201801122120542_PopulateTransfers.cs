namespace DronePostWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTransfers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO Transfers (Departure, Arrival, ArrivalStation_Id, DepartureStation_Id, Drone_Id, Package_Id) VALUES (NULL, convert(datetime, '12 Dec 2020 01:50:12', 13), 1, NULL, 4, 1)
                    INSERT INTO Transfers (Departure, Arrival, ArrivalStation_Id, DepartureStation_Id, Drone_Id, Package_Id) VALUES (convert(datetime, '12 Dec 2020 02:00:43', 13), convert(datetime, '12 Dec 2020 04:50:23', 13), 3, 1, 4, 1)
                    INSERT INTO Transfers (Departure, Arrival, ArrivalStation_Id, DepartureStation_Id, Drone_Id, Package_Id) VALUES (convert(datetime, '12 Dec 2020 05:00:01', 13), convert(datetime, '12 Dec 2020 07:33:10', 13), 5, 3, 4, 1)
                    INSERT INTO Transfers (Departure, Arrival, ArrivalStation_Id, DepartureStation_Id, Drone_Id, Package_Id) VALUES (convert(datetime, '12 Dec 2020 08:02:22', 13), convert(datetime, '12 Dec 2020 12:10:15', 13), 6, 5, 4, 1)
                ");
        }
        
        public override void Down()
        {
        }
    }
}
