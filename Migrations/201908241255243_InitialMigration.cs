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
                        ID = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        TimeEstimateInHours = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Project_ID = c.Guid(nullable: false),
                        Role_ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Project", t => t.Project_ID, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.Role_ID, cascadeDelete: true)
                .Index(t => t.Project_ID)
                .Index(t => t.Role_ID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        UserRole_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Role", t => t.UserRole_ID)
                .Index(t => t.UserRole_ID);
            
            CreateTable(
                "dbo.TimeRecord",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        DurationInHours = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(nullable: false),
                        User_ID = c.Guid(nullable: false),
                        Task_ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Task", t => t.Task_ID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_ID, cascadeDelete: true)
                .Index(t => t.User_ID)
                .Index(t => t.Task_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "UserRole_ID", "dbo.Role");
            DropForeignKey("dbo.TimeRecord", "User_ID", "dbo.User");
            DropForeignKey("dbo.TimeRecord", "Task_ID", "dbo.Task");
            DropForeignKey("dbo.Task", "Role_ID", "dbo.Role");
            DropForeignKey("dbo.Task", "Project_ID", "dbo.Project");
            DropIndex("dbo.TimeRecord", new[] { "Task_ID" });
            DropIndex("dbo.TimeRecord", new[] { "User_ID" });
            DropIndex("dbo.User", new[] { "UserRole_ID" });
            DropIndex("dbo.Task", new[] { "Role_ID" });
            DropIndex("dbo.Task", new[] { "Project_ID" });
            DropTable("dbo.TimeRecord");
            DropTable("dbo.User");
            DropTable("dbo.Role");
            DropTable("dbo.Task");
            DropTable("dbo.Project");
        }
    }
}
