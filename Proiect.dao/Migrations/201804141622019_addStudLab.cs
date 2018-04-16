namespace Proiect.dao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStudLab : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Laboratory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LabNumber = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Title = c.String(),
                        Curricula = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Token = c.String(),
                        Username = c.String(),
                        EncPassword = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                        GroupNo = c.Int(nullable: false),
                        Hobby = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Student");
            DropTable("dbo.Laboratory");
        }
    }
}
