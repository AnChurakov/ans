using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ans.Models;

namespace ans.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        [Authorize]
        public ActionResult Index()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            var AllProject = dbContext.Projects.ToList();
            
            return View(AllProject);
        }

        [Authorize]
        public ActionResult Create()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            var AllTeams = dbContext.Teams.ToList();

            ViewBag.Teams = AllTeams;

            ViewBag.Status = dbContext.Status.ToList();
            ViewBag.Stage = dbContext.Stage.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public string CreateProject(string Name, string LinkProject, string Procent, string Description,
            Guid team, Guid status, Guid stage)
        {
            if (Name != null && LinkProject != null && Procent != null && Description != null)
            {
                ApplicationDbContext dbContext = new ApplicationDbContext();

                var SelectTeam = dbContext.Teams.FirstOrDefault(t => t.Id == team);

                var SelectStatus = dbContext.Status.FirstOrDefault(t => t.Id == status);

                var SelectStage = dbContext.Stage.FirstOrDefault(t => t.Id == stage);

                Project pr = new Project
                {
                    Id = Guid.NewGuid(),
                    Name = Name,
                    Procent = int.Parse(Procent),
                    Description = Description,
                    LinkProject = LinkProject,
                    DateStart = DateTime.Now,
                    DateEnd = DateTime.Now,
                    Team = SelectTeam,
                    Stage = SelectStage,
                    Status = SelectStatus
                };

                dbContext.Projects.Add(pr);
                dbContext.SaveChanges();

                ViewBag.Check = 1;
                ViewBag.Message = "Проект успешно добавлен!";

            }
            else
            {
                ViewBag.Check = 0;
                ViewBag.Message = "Проект не добавлен!";
            }

            return string.Empty;
        }

    }
}