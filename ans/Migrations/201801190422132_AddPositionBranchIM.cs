namespace ans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPositionBranchIM : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Branch", c => c.String());
            AddColumn("dbo.AspNetUsers", "Position", c => c.String());
            CreateIndex("dbo.Teams", "User_Id");
            AddForeignKey("dbo.Teams", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Teams", new[] { "User_Id" });
            DropColumn("dbo.AspNetUsers", "Position");
            DropColumn("dbo.AspNetUsers", "Branch");
            DropColumn("dbo.Teams", "User_Id");
        }
    }
}
