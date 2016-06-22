namespace TaskManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulatePriorityTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Priorities (Id, Name) VALUES (1, 'Low')
                INSERT INTO Priorities (Id, Name) VALUES (2, 'Normal')
                INSERT INTO Priorities (Id, Name) VALUES (3, 'High')
                INSERT INTO Priorities (Id, Name) VALUES (4, 'Urgent')
                INSERT INTO Priorities (Id, Name) VALUES (5, 'Immediate')
                ");
        }

        public override void Down()
        {
        }
    }
}
