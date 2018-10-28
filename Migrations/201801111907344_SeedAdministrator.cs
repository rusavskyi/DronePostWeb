namespace DronePostWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedAdministrator : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    SET IDENTITY_INSERT [dbo].[Workers] ON
                    INSERT INTO [dbo].[Workers] ([Id], [EmployementDate], [Name], [Lastname], [PESEL], [PhoneNumber], [Address], [BirthDate], [City_Id], [WorkerType_Id], [WorkStation_Id]) VALUES (1, N'2018-01-11 00:00:00', N'Admin', N'Administrator', N'112358132134', 123456789, N'Here', N'2018-01-11 00:00:00', 1, 4, 12)
                    SET IDENTITY_INSERT [dbo].[Workers] OFF
                ");
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'cb4d09dc-01f1-43b2-967d-0d799584b106', N'Admin')");
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [IsWorker], [Consumer_Id], [Worker_Id]) VALUES (N'05ad7abb-88a5-4f9b-8157-c72862fbdefc', N'admin@dronepost.com', 0, N'AO3Wje52OfZCl3AgOeVLtC53DxTabJRIvYWBqjuTTTlQfEl/UuC5sc6lvWS8YX2JRw==', N'1dd1619e-0668-4506-ba2d-2b00f4f44687', NULL, 0, 0, NULL, 1, 0, N'admin@dronepost.com', 1, NULL, 1)");
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'05ad7abb-88a5-4f9b-8157-c72862fbdefc', N'cb4d09dc-01f1-43b2-967d-0d799584b106')");
        }

        public override void Down()
        {
        }
    }
}
