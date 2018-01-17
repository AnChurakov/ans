namespace ans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProjectTaskTeam : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        DateEnd = c.DateTime(nullable: false),
                        DateStart = c.DateTime(nullable: false),
                        Procent = c.Int(nullable: false),
                        LinkProject = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TaskProjects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Teams");
            DropTable("dbo.TaskProjects");
            DropTable("dbo.Projects");
        }
    }
}
