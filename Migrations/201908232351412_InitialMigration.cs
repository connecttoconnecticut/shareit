namespace TimeTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        TimeEstimateInHours = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Project_ID = c.Int(nullable: false),
                        Role_ID = c.Int(nullable: false),
                        Project_ID1 = c.Int(),
                        Role_ID1 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Project", t => t.Project_ID1)
                .ForeignKey("dbo.Role", t => t.Role_ID1)
                .Index(t => t.Project_ID1)
                .Index(t => t.Role_ID1);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        UserRole_ID = c.Int(nullable: false),
                        UserRole_ID1 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Role", t => t.UserRole_ID1)
                .Index(t => t.UserRole_ID1);
            
            CreateTable(
                "dbo.TimeRecord",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        DurationInHours = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(nullable: false),
                        User_ID = c.Int(nullable: false),
                        Task_ID = c.Int(nullable: false),
                        Task_ID1 = c.Int(),
                        User_ID1 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Task", t => t.Task_ID1)
                .ForeignKey("dbo.User", t => t.User_ID1)
                .Index(t => t.Task_ID1)
                .Index(t => t.User_ID1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "UserRole_ID1", "dbo.Role");
            DropForeignKey("dbo.TimeRecord", "User_ID1", "dbo.User");
            DropForeignKey("dbo.TimeRecord", "Task_ID1", "dbo.Task");
            DropForeignKey("dbo.Task", "Role_ID1", "dbo.Role");
            DropForeignKey("dbo.Task", "Project_ID1", "dbo.Project");
            DropIndex("dbo.TimeRecord", new[] { "User_ID1" });
            DropIndex("dbo.TimeRecord", new[] { "Task_ID1" });
            DropIndex("dbo.User", new[] { "UserRole_ID1" });
            DropIndex("dbo.Task", new[] { "Role_ID1" });
            DropIndex("dbo.Task", new[] { "Project_ID1" });
            DropTable("dbo.TimeRecord");
            DropTable("dbo.User");
            DropTable("dbo.Role");
            DropTable("dbo.Task");
            DropTable("dbo.Project");
        }
    }
}
