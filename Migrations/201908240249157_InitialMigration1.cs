namespace TimeTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Task", "Project_ID1", "dbo.Project");
            DropForeignKey("dbo.Task", "Role_ID1", "dbo.Role");
            DropForeignKey("dbo.TimeRecord", "Task_ID1", "dbo.Task");
            DropForeignKey("dbo.User", "UserRole_ID1", "dbo.Role");
            DropForeignKey("dbo.TimeRecord", "User_ID1", "dbo.User");
            DropIndex("dbo.Task", new[] { "Project_ID1" });
            DropIndex("dbo.Task", new[] { "Role_ID1" });
            DropIndex("dbo.User", new[] { "UserRole_ID1" });
            DropIndex("dbo.TimeRecord", new[] { "Task_ID1" });
            DropIndex("dbo.TimeRecord", new[] { "User_ID1" });
            DropColumn("dbo.Task", "Project_ID");
            DropColumn("dbo.Task", "Role_ID");
            DropColumn("dbo.User", "UserRole_ID");
            DropColumn("dbo.TimeRecord", "Task_ID");
            RenameColumn(table: "dbo.Task", name: "Project_ID1", newName: "Project_ID");
            RenameColumn(table: "dbo.Task", name: "Role_ID1", newName: "Role_ID");
            RenameColumn(table: "dbo.TimeRecord", name: "Task_ID1", newName: "Task_ID");
            RenameColumn(table: "dbo.User", name: "UserRole_ID1", newName: "UserRole_ID");
            DropPrimaryKey("dbo.Project");
            DropPrimaryKey("dbo.Task");
            DropPrimaryKey("dbo.Role");
            DropPrimaryKey("dbo.User");
            DropPrimaryKey("dbo.TimeRecord");
            AlterColumn("dbo.Project", "ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Task", "ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Task", "Project_ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Task", "Role_ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Task", "Project_ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Task", "Role_ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Role", "ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.User", "ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.User", "UserRole_ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.User", "UserRole_ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.TimeRecord", "ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.TimeRecord", "User_ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.TimeRecord", "Task_ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.TimeRecord", "Task_ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.TimeRecord", "User_ID1", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Project", "ID");
            AddPrimaryKey("dbo.Task", "ID");
            AddPrimaryKey("dbo.Role", "ID");
            AddPrimaryKey("dbo.User", "ID");
            AddPrimaryKey("dbo.TimeRecord", "ID");
            CreateIndex("dbo.Task", "Project_ID");
            CreateIndex("dbo.Task", "Role_ID");
            CreateIndex("dbo.User", "UserRole_ID");
            CreateIndex("dbo.TimeRecord", "Task_ID");
            CreateIndex("dbo.TimeRecord", "User_ID1");
            AddForeignKey("dbo.Task", "Project_ID", "dbo.Project", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Task", "Role_ID", "dbo.Role", "ID", cascadeDelete: true);
            AddForeignKey("dbo.TimeRecord", "Task_ID", "dbo.Task", "ID", cascadeDelete: true);
            AddForeignKey("dbo.User", "UserRole_ID", "dbo.Role", "ID", cascadeDelete: true);
            AddForeignKey("dbo.TimeRecord", "User_ID1", "dbo.User", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeRecord", "User_ID1", "dbo.User");
            DropForeignKey("dbo.User", "UserRole_ID", "dbo.Role");
            DropForeignKey("dbo.TimeRecord", "Task_ID", "dbo.Task");
            DropForeignKey("dbo.Task", "Role_ID", "dbo.Role");
            DropForeignKey("dbo.Task", "Project_ID", "dbo.Project");
            DropIndex("dbo.TimeRecord", new[] { "User_ID1" });
            DropIndex("dbo.TimeRecord", new[] { "Task_ID" });
            DropIndex("dbo.User", new[] { "UserRole_ID" });
            DropIndex("dbo.Task", new[] { "Role_ID" });
            DropIndex("dbo.Task", new[] { "Project_ID" });
            DropPrimaryKey("dbo.TimeRecord");
            DropPrimaryKey("dbo.User");
            DropPrimaryKey("dbo.Role");
            DropPrimaryKey("dbo.Task");
            DropPrimaryKey("dbo.Project");
            AlterColumn("dbo.TimeRecord", "User_ID1", c => c.Int());
            AlterColumn("dbo.TimeRecord", "Task_ID", c => c.Int());
            AlterColumn("dbo.TimeRecord", "Task_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.TimeRecord", "User_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.TimeRecord", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.User", "UserRole_ID", c => c.Int());
            AlterColumn("dbo.User", "UserRole_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.User", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Role", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Task", "Role_ID", c => c.Int());
            AlterColumn("dbo.Task", "Project_ID", c => c.Int());
            AlterColumn("dbo.Task", "Role_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Task", "Project_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Task", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Project", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.TimeRecord", "ID");
            AddPrimaryKey("dbo.User", "ID");
            AddPrimaryKey("dbo.Role", "ID");
            AddPrimaryKey("dbo.Task", "ID");
            AddPrimaryKey("dbo.Project", "ID");
            RenameColumn(table: "dbo.User", name: "UserRole_ID", newName: "UserRole_ID1");
            RenameColumn(table: "dbo.TimeRecord", name: "Task_ID", newName: "Task_ID1");
            RenameColumn(table: "dbo.Task", name: "Role_ID", newName: "Role_ID1");
            RenameColumn(table: "dbo.Task", name: "Project_ID", newName: "Project_ID1");
            AddColumn("dbo.TimeRecord", "Task_ID", c => c.Int(nullable: false));
            AddColumn("dbo.User", "UserRole_ID", c => c.Int(nullable: false));
            AddColumn("dbo.Task", "Role_ID", c => c.Int(nullable: false));
            AddColumn("dbo.Task", "Project_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.TimeRecord", "User_ID1");
            CreateIndex("dbo.TimeRecord", "Task_ID1");
            CreateIndex("dbo.User", "UserRole_ID1");
            CreateIndex("dbo.Task", "Role_ID1");
            CreateIndex("dbo.Task", "Project_ID1");
            AddForeignKey("dbo.TimeRecord", "User_ID1", "dbo.User", "ID");
            AddForeignKey("dbo.User", "UserRole_ID1", "dbo.Role", "ID");
            AddForeignKey("dbo.TimeRecord", "Task_ID1", "dbo.Task", "ID");
            AddForeignKey("dbo.Task", "Role_ID1", "dbo.Role", "ID");
            AddForeignKey("dbo.Task", "Project_ID1", "dbo.Project", "ID");
        }
    }
}
