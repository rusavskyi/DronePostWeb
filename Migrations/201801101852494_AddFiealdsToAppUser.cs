namespace DronePostWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFiealdsToAppUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsWorker", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Consumer_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Worker_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Consumer_Id");
            CreateIndex("dbo.AspNetUsers", "Worker_Id");
            AddForeignKey("dbo.AspNetUsers", "Consumer_Id", "dbo.Consumers", "Id");
            AddForeignKey("dbo.AspNetUsers", "Worker_Id", "dbo.Workers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Worker_Id", "dbo.Workers");
            DropForeignKey("dbo.AspNetUsers", "Consumer_Id", "dbo.Consumers");
            DropIndex("dbo.AspNetUsers", new[] { "Worker_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Consumer_Id" });
            DropColumn("dbo.AspNetUsers", "Worker_Id");
            DropColumn("dbo.AspNetUsers", "Consumer_Id");
            DropColumn("dbo.AspNetUsers", "IsWorker");
        }
    }
}
