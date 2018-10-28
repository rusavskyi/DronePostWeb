namespace DronePostWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnrequireDateTimeInTransfers : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transfers", "Departure", c => c.DateTime());
            AlterColumn("dbo.Transfers", "Arrival", c => c.DateTime());

        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transfers", "Arrival", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Transfers", "Departure", c => c.DateTime(nullable: false));
        }
    }
}
