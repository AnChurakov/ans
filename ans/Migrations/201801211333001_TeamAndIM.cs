namespace ans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeamAndIM : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationUserTeams", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserTeams", "Team_Id", "dbo.Teams");
            DropIndex("dbo.ApplicationUserTeams", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserTeams", new[] { "Team_Id" });
            AddColumn("dbo.AspNetUsers", "Teams_Id", c => c.Guid());
            CreateIndex("dbo.AspNetUsers", "Teams_Id");
            AddForeignKey("dbo.AspNetUsers", "Teams_Id", "dbo.Teams", "Id");
            DropTable("dbo.ApplicationUserTeams");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ApplicationUserTeams",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Team_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Team_Id });
            
            DropForeignKey("dbo.AspNetUsers", "Teams_Id", "dbo.Teams");
            DropIndex("dbo.AspNetUsers", new[] { "Teams_Id" });
            DropColumn("dbo.AspNetUsers", "Teams_Id");
            CreateIndex("dbo.ApplicationUserTeams", "Team_Id");
            CreateIndex("dbo.ApplicationUserTeams", "ApplicationUser_Id");
            AddForeignKey("dbo.ApplicationUserTeams", "Team_Id", "dbo.Teams", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationUserTeams", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
