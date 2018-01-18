namespace ans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relationships : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Id)
                .Index(t => t.Id);
            
            AddColumn("dbo.TaskProjects", "Projects_Id", c => c.Guid());
            CreateIndex("dbo.TaskProjects", "Projects_Id");
            CreateIndex("dbo.Teams", "Id");
            AddForeignKey("dbo.TaskProjects", "Projects_Id", "dbo.Projects", "Id");
            AddForeignKey("dbo.Teams", "Id", "dbo.Projects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "Id", "dbo.Projects");
            DropForeignKey("dbo.TaskProjects", "Projects_Id", "dbo.Projects");
            DropForeignKey("dbo.Status", "Id", "dbo.Projects");
            DropForeignKey("dbo.Stages", "Id", "dbo.Projects");
            DropIndex("dbo.Teams", new[] { "Id" });
            DropIndex("dbo.TaskProjects", new[] { "Projects_Id" });
            DropIndex("dbo.Status", new[] { "Id" });
            DropIndex("dbo.Stages", new[] { "Id" });
            DropColumn("dbo.TaskProjects", "Projects_Id");
            DropTable("dbo.Status");
            DropTable("dbo.Stages");
        }
    }
}
