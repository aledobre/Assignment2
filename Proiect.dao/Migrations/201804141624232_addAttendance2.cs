namespace Proiect.dao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAttendance2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        LabId = c.Int(nullable: false),
                        AttendanceStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Laboratory", t => t.LabId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.LabId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Attendances", "LabId", "dbo.Laboratory");
            DropIndex("dbo.Attendances", new[] { "LabId" });
            DropIndex("dbo.Attendances", new[] { "StudentId" });
            DropTable("dbo.Attendances");
        }
    }
}
