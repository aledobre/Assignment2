namespace Proiect.dao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSubAssig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Deadline = c.DateTime(nullable: false),
                        Description = c.String(),
                        LabId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Laboratory", t => t.LabId, cascadeDelete: true)
                .Index(t => t.LabId);
            
            CreateTable(
                "dbo.Submission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        AssignmentId = c.Int(nullable: false),
                        Link = c.String(),
                        Remark = c.String(),
                        Grade = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Assignment", t => t.AssignmentId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.AssignmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Submission", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Submission", "AssignmentId", "dbo.Assignment");
            DropForeignKey("dbo.Assignment", "LabId", "dbo.Laboratory");
            DropIndex("dbo.Submission", new[] { "AssignmentId" });
            DropIndex("dbo.Submission", new[] { "StudentId" });
            DropIndex("dbo.Assignment", new[] { "LabId" });
            DropTable("dbo.Submission");
            DropTable("dbo.Assignment");
        }
    }
}
