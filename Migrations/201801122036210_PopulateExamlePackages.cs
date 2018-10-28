namespace DronePostWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateExamlePackages : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO Packages (RecipientPhoneNumber, Code, Sender_Id, Size_Id, TargetStation_Id) VALUES ('111222333', '1234', 2, 1, 1)
                    INSERT INTO Packages (RecipientPhoneNumber, Code, Sender_Id, Size_Id, TargetStation_Id) VALUES ('111222333', '1235', 2, 2, 2)
                    INSERT INTO Packages (RecipientPhoneNumber, Code, Sender_Id, Size_Id, TargetStation_Id) VALUES ('111222333', '1236', 2, 3, 3)
                    INSERT INTO Packages (RecipientPhoneNumber, Code, Sender_Id, Size_Id, TargetStation_Id) VALUES ('132321123', '1237', 1, 2, 4)
                    INSERT INTO Packages (RecipientPhoneNumber, Code, Sender_Id, Size_Id, TargetStation_Id) VALUES ('132321123', '1238', 1, 4, 5)
                    INSERT INTO Packages (RecipientPhoneNumber, Code, Sender_Id, Size_Id, TargetStation_Id) VALUES ('132321123', '1239', 1, 1, 6)
                ");
        }
        
        public override void Down()
        {
        }
    }
}
