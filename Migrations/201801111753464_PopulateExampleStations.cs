namespace DronePostWeb.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateExampleStations : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO Stations (Address, Latitude, Wideness, City_Id) VALUES ('Addres 1', '234567', '123456', 1)
                    INSERT INTO Stations (Address, Latitude, Wideness, City_Id) VALUES ('Addres 2', '234567', '123456', 1)
                    INSERT INTO Stations (Address, Latitude, Wideness, City_Id) VALUES ('Addres 3', '234567', '123456', 2)
                    INSERT INTO Stations (Address, Latitude, Wideness, City_Id) VALUES ('Addres 4', '234567', '123456', 2)
                    INSERT INTO Stations (Address, Latitude, Wideness, City_Id) VALUES ('Addres 5', '234567', '123456', 3)
                    INSERT INTO Stations (Address, Latitude, Wideness, City_Id) VALUES ('Addres 6', '234567', '123456', 3)
                    INSERT INTO Stations (Address, Latitude, Wideness, City_Id) VALUES ('Addres 7', '234567', '123456', 4)
                    INSERT INTO Stations (Address, Latitude, Wideness, City_Id) VALUES ('Addres 8', '234567', '123456', 4)
                    INSERT INTO Stations (Address, Latitude, Wideness, City_Id) VALUES ('Addres 9', '234567', '123456', 5)
                    INSERT INTO Stations (Address, Latitude, Wideness, City_Id) VALUES ('Addres 10', '234567', '123456', 5)
                    INSERT INTO Stations (Address, Latitude, Wideness, City_Id) VALUES ('Addres 11', '234567', '123456', 1)
                ");
        }

        public override void Down()
        {
        }
    }
}
