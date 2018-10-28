namespace DronePostWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWuAndCuTabsRemFieldsFromUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Consumer_Id", "dbo.Consumers");
            DropForeignKey("dbo.AspNetUsers", "Worker_Id", "dbo.Workers");
            DropIndex("dbo.AspNetUsers", new[] { "Consumer_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Worker_Id" });
            CreateTable(
                "dbo.ConsumerUsers",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Consumer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Consumers", t => t.Consumer_Id, cascadeDelete: true)
                .Index(t => t.Consumer_Id);
            
            CreateTable(
                "dbo.WorkerUsers",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Worker_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Workers", t => t.Worker_Id, cascadeDelete: true)
                .Index(t => t.Worker_Id);
            
            DropColumn("dbo.AspNetUsers", "Consumer_Id");
            DropColumn("dbo.AspNetUsers", "Worker_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Worker_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Consumer_Id", c => c.Int());
            DropForeignKey("dbo.WorkerUsers", "Worker_Id", "dbo.Workers");
            DropForeignKey("dbo.ConsumerUsers", "Consumer_Id", "dbo.Consumers");
            DropIndex("dbo.WorkerUsers", new[] { "Worker_Id" });
            DropIndex("dbo.ConsumerUsers", new[] { "Consumer_Id" });
            DropTable("dbo.WorkerUsers");
            DropTable("dbo.ConsumerUsers");
            CreateIndex("dbo.AspNetUsers", "Worker_Id");
            CreateIndex("dbo.AspNetUsers", "Consumer_Id");
            AddForeignKey("dbo.AspNetUsers", "Worker_Id", "dbo.Workers", "Id");
            AddForeignKey("dbo.AspNetUsers", "Consumer_Id", "dbo.Consumers", "Id");
        }
    }
}
