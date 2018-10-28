namespace DronePostWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateExampleCities : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO Cities (Name) VALUES ('Wroclaw')
                INSERT INTO Cities (Name) VALUES ('Warshaw')
                INSERT INTO Cities (Name) VALUES ('Krakow')
                INSERT INTO Cities (Name) VALUES ('Gdansk')
                INSERT INTO Cities (Name) VALUES ('Katowice')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
