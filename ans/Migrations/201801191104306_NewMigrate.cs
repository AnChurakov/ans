namespace ans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigrate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Status", "Id", "dbo.Projects");
            DropIndex("dbo.Status", new[] { "Id" });
            AddColumn("dbo.Projects", "Status_Id", c => c.Guid());
            AlterColumn("dbo.Status", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Projects", "Status_Id");
            AddForeignKey("dbo.Projects", "Status_Id", "dbo.Status", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "Status_Id", "dbo.Status");
            DropIndex("dbo.Projects", new[] { "Status_Id" });
            AlterColumn("dbo.Status", "Name", c => c.String());
            DropColumn("dbo.Projects", "Status_Id");
            CreateIndex("dbo.Status", "Id");
            AddForeignKey("dbo.Status", "Id", "dbo.Projects", "Id");
        }
    }
}
