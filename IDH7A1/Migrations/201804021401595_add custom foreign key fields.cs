namespace IDH7A1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcustomforeignkeyfields : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Exams", name: "User_Id", newName: "UserID");
            RenameColumn(table: "dbo.MomentRooms", name: "Surveillant_Id", newName: "SurveillantId");
            RenameIndex(table: "dbo.Exams", name: "IX_User_Id", newName: "IX_UserID");
            RenameIndex(table: "dbo.MomentRooms", name: "IX_Surveillant_Id", newName: "IX_SurveillantId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.MomentRooms", name: "IX_SurveillantId", newName: "IX_Surveillant_Id");
            RenameIndex(table: "dbo.Exams", name: "IX_UserID", newName: "IX_User_Id");
            RenameColumn(table: "dbo.MomentRooms", name: "SurveillantId", newName: "Surveillant_Id");
            RenameColumn(table: "dbo.Exams", name: "UserID", newName: "User_Id");
        }
    }
}
