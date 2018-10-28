namespace DronePostWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnrequireCityInPersone : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Consumers", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Workers", "City_Id", "dbo.Cities");
            DropIndex("dbo.Consumers", new[] { "City_Id" });
            DropIndex("dbo.Workers", new[] { "City_Id" });
            AlterColumn("dbo.Consumers", "City_Id", c => c.Int());
            AlterColumn("dbo.Workers", "City_Id", c => c.Int());
            CreateIndex("dbo.Consumers", "City_Id");
            CreateIndex("dbo.Workers", "City_Id");
            AddForeignKey("dbo.Consumers", "City_Id", "dbo.Cities", "Id");
            AddForeignKey("dbo.Workers", "City_Id", "dbo.Cities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workers", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Consumers", "City_Id", "dbo.Cities");
            DropIndex("dbo.Workers", new[] { "City_Id" });
            DropIndex("dbo.Consumers", new[] { "City_Id" });
            AlterColumn("dbo.Workers", "City_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Consumers", "City_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Workers", "City_Id");
            CreateIndex("dbo.Consumers", "City_Id");
            AddForeignKey("dbo.Workers", "City_Id", "dbo.Cities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Consumers", "City_Id", "dbo.Cities", "Id", cascadeDelete: true);
        }
    }
}
