namespace TaskManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveIds : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ProjectTasks", name: "PriorityId", newName: "Priority_Id");
            RenameColumn(table: "dbo.ProjectTasks", name: "ProjectId", newName: "Project_Id");
            RenameColumn(table: "dbo.ProjectTasks", name: "StatusId", newName: "Status_Id");
            RenameIndex(table: "dbo.ProjectTasks", name: "IX_PriorityId", newName: "IX_Priority_Id");
            RenameIndex(table: "dbo.ProjectTasks", name: "IX_ProjectId", newName: "IX_Project_Id");
            RenameIndex(table: "dbo.ProjectTasks", name: "IX_StatusId", newName: "IX_Status_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ProjectTasks", name: "IX_Status_Id", newName: "IX_StatusId");
            RenameIndex(table: "dbo.ProjectTasks", name: "IX_Project_Id", newName: "IX_ProjectId");
            RenameIndex(table: "dbo.ProjectTasks", name: "IX_Priority_Id", newName: "IX_PriorityId");
            RenameColumn(table: "dbo.ProjectTasks", name: "Status_Id", newName: "StatusId");
            RenameColumn(table: "dbo.ProjectTasks", name: "Project_Id", newName: "ProjectId");
            RenameColumn(table: "dbo.ProjectTasks", name: "Priority_Id", newName: "PriorityId");
        }
    }
}
