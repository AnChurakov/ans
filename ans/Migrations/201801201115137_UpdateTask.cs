namespace ans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTask : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Description", c => c.String(nullable: false));
            AddColumn("dbo.TaskProjects", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.TaskProjects", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TaskProjects", "Name", c => c.String());
            DropColumn("dbo.TaskProjects", "Description");
            DropColumn("dbo.Projects", "Description");
        }
    }
}
