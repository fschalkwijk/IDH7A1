namespace IDH7A1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserExamMomentRoomandSurveillant : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Subject = c.String(),
                        Students = c.Int(nullable: false),
                        ComputerRoom = c.Boolean(nullable: false),
                        SurveillantNeeded = c.Boolean(nullable: false),
                        Code = c.String(),
                        EuropeanCredits = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Moments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Exam_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exams", t => t.Exam_Id)
                .Index(t => t.Exam_Id);
            
            CreateTable(
                "dbo.MomentRooms",
                c => new
                    {
                        MomentId = c.Int(nullable: false),
                        RoomKey = c.String(nullable: false, maxLength: 10),
                        Surveillant_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.MomentId, t.RoomKey })
                .ForeignKey("dbo.Moments", t => t.MomentId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomKey, cascadeDelete: true)
                .ForeignKey("dbo.Surveillants", t => t.Surveillant_Id)
                .Index(t => t.MomentId)
                .Index(t => t.RoomKey)
                .Index(t => t.Surveillant_Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Key = c.String(nullable: false, maxLength: 10),
                        Computers = c.Int(nullable: false),
                        MaxStudents = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Key);
            
            CreateTable(
                "dbo.Surveillants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exams", "User_Id", "dbo.Users");
            DropForeignKey("dbo.MomentRooms", "Surveillant_Id", "dbo.Surveillants");
            DropForeignKey("dbo.MomentRooms", "RoomKey", "dbo.Rooms");
            DropForeignKey("dbo.MomentRooms", "MomentId", "dbo.Moments");
            DropForeignKey("dbo.Moments", "Exam_Id", "dbo.Exams");
            DropIndex("dbo.MomentRooms", new[] { "Surveillant_Id" });
            DropIndex("dbo.MomentRooms", new[] { "RoomKey" });
            DropIndex("dbo.MomentRooms", new[] { "MomentId" });
            DropIndex("dbo.Moments", new[] { "Exam_Id" });
            DropIndex("dbo.Exams", new[] { "User_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Surveillants");
            DropTable("dbo.Rooms");
            DropTable("dbo.MomentRooms");
            DropTable("dbo.Moments");
            DropTable("dbo.Exams");
        }
    }
}
