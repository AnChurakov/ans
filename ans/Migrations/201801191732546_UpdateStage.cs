namespace ans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stages", "Id", "dbo.Projects");
            DropIndex("dbo.Stages", new[] { "Id" });
            AddColumn("dbo.Projects", "Stage_Id", c => c.Guid());
            AlterColumn("dbo.Stages", "Name", c => c.String(nullable: false, maxLength: 200));
            CreateIndex("dbo.Projects", "Stage_Id");
            AddForeignKey("dbo.Projects", "Stage_Id", "dbo.Stages", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "Stage_Id", "dbo.Stages");
            DropIndex("dbo.Projects", new[] { "Stage_Id" });
            AlterColumn("dbo.Stages", "Name", c => c.String());
            DropColumn("dbo.Projects", "Stage_Id");
            CreateIndex("dbo.Stages", "Id");
            AddForeignKey("dbo.Stages", "Id", "dbo.Projects", "Id");
        }
    }
}
