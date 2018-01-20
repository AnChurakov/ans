namespace ans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToManyTeamIM : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teams", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Teams", "Id", "dbo.Projects");
            DropIndex("dbo.Teams", new[] { "Id" });
            DropIndex("dbo.Teams", new[] { "User_Id" });
            CreateTable(
                "dbo.ApplicationUserTeams",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Team_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Team_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.Team_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Team_Id);
            
            AddColumn("dbo.Projects", "Team_Id", c => c.Guid());
            AlterColumn("dbo.Teams", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Projects", "Team_Id");
            AddForeignKey("dbo.Projects", "Team_Id", "dbo.Teams", "Id");
            DropColumn("dbo.Teams", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teams", "User_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Projects", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.ApplicationUserTeams", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.ApplicationUserTeams", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserTeams", new[] { "Team_Id" });
            DropIndex("dbo.ApplicationUserTeams", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Projects", new[] { "Team_Id" });
            AlterColumn("dbo.Teams", "Name", c => c.String());
            DropColumn("dbo.Projects", "Team_Id");
            DropTable("dbo.ApplicationUserTeams");
            CreateIndex("dbo.Teams", "User_Id");
            CreateIndex("dbo.Teams", "Id");
            AddForeignKey("dbo.Teams", "Id", "dbo.Projects", "Id");
            AddForeignKey("dbo.Teams", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
