namespace IDH7A1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addnotnullcontraints : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Moments", "Exam_Id", "dbo.Exams");
            DropForeignKey("dbo.Exams", "User_Id", "dbo.Users");
            DropForeignKey("dbo.MomentRooms", "Surveillant_Id", "dbo.Surveillants");
            DropIndex("dbo.Exams", new[] { "User_Id" });
            DropIndex("dbo.Moments", new[] { "Exam_Id" });
            DropIndex("dbo.MomentRooms", new[] { "Surveillant_Id" });
            AlterColumn("dbo.Exams", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Exams", "Subject", c => c.String(nullable: false));
            AlterColumn("dbo.Exams", "Code", c => c.String(nullable: false));
            AlterColumn("dbo.Exams", "User_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Moments", "Exam_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.MomentRooms", "Surveillant_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Surveillants", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Role", c => c.String(nullable: false));
            CreateIndex("dbo.Exams", "User_Id");
            CreateIndex("dbo.Moments", "Exam_Id");
            CreateIndex("dbo.MomentRooms", "Surveillant_Id");
            AddForeignKey("dbo.Moments", "Exam_Id", "dbo.Exams", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Exams", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MomentRooms", "Surveillant_Id", "dbo.Surveillants", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MomentRooms", "Surveillant_Id", "dbo.Surveillants");
            DropForeignKey("dbo.Exams", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Moments", "Exam_Id", "dbo.Exams");
            DropIndex("dbo.MomentRooms", new[] { "Surveillant_Id" });
            DropIndex("dbo.Moments", new[] { "Exam_Id" });
            DropIndex("dbo.Exams", new[] { "User_Id" });
            AlterColumn("dbo.Users", "Role", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Surveillants", "Name", c => c.String());
            AlterColumn("dbo.MomentRooms", "Surveillant_Id", c => c.Int());
            AlterColumn("dbo.Moments", "Exam_Id", c => c.Int());
            AlterColumn("dbo.Exams", "User_Id", c => c.Int());
            AlterColumn("dbo.Exams", "Code", c => c.String());
            AlterColumn("dbo.Exams", "Subject", c => c.String());
            AlterColumn("dbo.Exams", "Name", c => c.String());
            CreateIndex("dbo.MomentRooms", "Surveillant_Id");
            CreateIndex("dbo.Moments", "Exam_Id");
            CreateIndex("dbo.Exams", "User_Id");
            AddForeignKey("dbo.MomentRooms", "Surveillant_Id", "dbo.Surveillants", "Id");
            AddForeignKey("dbo.Exams", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Moments", "Exam_Id", "dbo.Exams", "Id");
        }
    }
}
