namespace DronePostWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Consumers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Lastname = c.String(nullable: false, maxLength: 100),
                        PESEL = c.String(maxLength: 100),
                        PhoneNumber = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 255),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        City_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id, cascadeDelete: true)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.DroneModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        MaxWeight = c.Single(nullable: false),
                        MaxDistance = c.Single(nullable: false),
                        MaxPackageSize_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PackageSizes", t => t.MaxPackageSize_Id, cascadeDelete: true)
                .Index(t => t.MaxPackageSize_Id);
            
            CreateTable(
                "dbo.PackageSizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 32),
                        Height = c.Single(nullable: false),
                        Width = c.Single(nullable: false),
                        Length = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Drones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitude = c.String(),
                        Wideness = c.String(),
                        Model_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DroneModels", t => t.Model_Id, cascadeDelete: true)
                .Index(t => t.Model_Id);
            
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RecipientPhoneNumber = c.Int(nullable: false),
                        Code = c.String(nullable: false, maxLength: 16),
                        Sender_Id = c.Int(nullable: false),
                        Size_Id = c.Int(nullable: false),
                        TargetStation_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Consumers", t => t.Sender_Id, cascadeDelete: true)
                .ForeignKey("dbo.PackageSizes", t => t.Size_Id, cascadeDelete: true)
                .ForeignKey("dbo.Stations", t => t.TargetStation_Id, cascadeDelete: true)
                .Index(t => t.Sender_Id)
                .Index(t => t.Size_Id)
                .Index(t => t.TargetStation_Id);
            
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false, maxLength: 255),
                        Latitude = c.String(),
                        Wideness = c.String(),
                        City_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Transfers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Departure = c.DateTime(nullable: false),
                        Arrival = c.DateTime(nullable: false),
                        ArrivalStation_Id = c.Int(),
                        DepartureStation_Id = c.Int(),
                        Drone_Id = c.Int(),
                        Package_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stations", t => t.ArrivalStation_Id)
                .ForeignKey("dbo.Stations", t => t.DepartureStation_Id)
                .ForeignKey("dbo.Drones", t => t.Drone_Id)
                .ForeignKey("dbo.Packages", t => t.Package_Id)
                .Index(t => t.ArrivalStation_Id)
                .Index(t => t.DepartureStation_Id)
                .Index(t => t.Drone_Id)
                .Index(t => t.Package_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmploymentDate = c.DateTime(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Lastname = c.String(nullable: false, maxLength: 100),
                        PESEL = c.String(maxLength: 100),
                        PhoneNumber = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 255),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        City_Id = c.Int(nullable: false),
                        WorkerType_Id = c.Int(nullable: false),
                        WorkStation_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id, cascadeDelete: true)
                .ForeignKey("dbo.WorkerTypes", t => t.WorkerType_Id, cascadeDelete: true)
                .ForeignKey("dbo.Stations", t => t.WorkStation_Id, cascadeDelete: true)
                .Index(t => t.City_Id)
                .Index(t => t.WorkerType_Id)
                .Index(t => t.WorkStation_Id);
            
            CreateTable(
                "dbo.WorkerTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workers", "WorkStation_Id", "dbo.Stations");
            DropForeignKey("dbo.Workers", "WorkerType_Id", "dbo.WorkerTypes");
            DropForeignKey("dbo.Workers", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Transfers", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.Transfers", "Drone_Id", "dbo.Drones");
            DropForeignKey("dbo.Transfers", "DepartureStation_Id", "dbo.Stations");
            DropForeignKey("dbo.Transfers", "ArrivalStation_Id", "dbo.Stations");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Packages", "TargetStation_Id", "dbo.Stations");
            DropForeignKey("dbo.Stations", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Packages", "Size_Id", "dbo.PackageSizes");
            DropForeignKey("dbo.Packages", "Sender_Id", "dbo.Consumers");
            DropForeignKey("dbo.Drones", "Model_Id", "dbo.DroneModels");
            DropForeignKey("dbo.DroneModels", "MaxPackageSize_Id", "dbo.PackageSizes");
            DropForeignKey("dbo.Consumers", "City_Id", "dbo.Cities");
            DropIndex("dbo.Workers", new[] { "WorkStation_Id" });
            DropIndex("dbo.Workers", new[] { "WorkerType_Id" });
            DropIndex("dbo.Workers", new[] { "City_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Transfers", new[] { "Package_Id" });
            DropIndex("dbo.Transfers", new[] { "Drone_Id" });
            DropIndex("dbo.Transfers", new[] { "DepartureStation_Id" });
            DropIndex("dbo.Transfers", new[] { "ArrivalStation_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Stations", new[] { "City_Id" });
            DropIndex("dbo.Packages", new[] { "TargetStation_Id" });
            DropIndex("dbo.Packages", new[] { "Size_Id" });
            DropIndex("dbo.Packages", new[] { "Sender_Id" });
            DropIndex("dbo.Drones", new[] { "Model_Id" });
            DropIndex("dbo.DroneModels", new[] { "MaxPackageSize_Id" });
            DropIndex("dbo.Consumers", new[] { "City_Id" });
            DropTable("dbo.WorkerTypes");
            DropTable("dbo.Workers");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Transfers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Stations");
            DropTable("dbo.Packages");
            DropTable("dbo.Drones");
            DropTable("dbo.PackageSizes");
            DropTable("dbo.DroneModels");
            DropTable("dbo.Consumers");
            DropTable("dbo.Cities");
        }
    }
}
