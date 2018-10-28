namespace DronePostWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PackageModelUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Packages", "Sender_Id", "dbo.Consumers");
            DropIndex("dbo.Packages", new[] { "Sender_Id" });
            AddColumn("dbo.Packages", "Price", c => c.Single(nullable: false));
            AlterColumn("dbo.Packages", "Sender_Id", c => c.Int());
            CreateIndex("dbo.Packages", "Sender_Id");
            AddForeignKey("dbo.Packages", "Sender_Id", "dbo.Consumers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Packages", "Sender_Id", "dbo.Consumers");
            DropIndex("dbo.Packages", new[] { "Sender_Id" });
            AlterColumn("dbo.Packages", "Sender_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Packages", "Price");
            CreateIndex("dbo.Packages", "Sender_Id");
            AddForeignKey("dbo.Packages", "Sender_Id", "dbo.Consumers", "Id", cascadeDelete: true);
        }
    }
}
