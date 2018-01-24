namespace ans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VacancyAndTeam : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vacancies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VacancyTeams",
                c => new
                    {
                        Vacancy_Id = c.Guid(nullable: false),
                        Team_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vacancy_Id, t.Team_Id })
                .ForeignKey("dbo.Vacancies", t => t.Vacancy_Id, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.Team_Id, cascadeDelete: true)
                .Index(t => t.Vacancy_Id)
                .Index(t => t.Team_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VacancyTeams", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.VacancyTeams", "Vacancy_Id", "dbo.Vacancies");
            DropIndex("dbo.VacancyTeams", new[] { "Team_Id" });
            DropIndex("dbo.VacancyTeams", new[] { "Vacancy_Id" });
            DropTable("dbo.VacancyTeams");
            DropTable("dbo.Vacancies");
        }
    }
}
