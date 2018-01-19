namespace ans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "Name", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Projects", "LinkProject", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "LinkProject", c => c.String());
            AlterColumn("dbo.Projects", "Name", c => c.String());
        }
    }
}
