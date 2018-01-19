using System;
using System.Collections.Generic;
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

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateProject(string Name, string LinkProject)
        {
            if (ModelState.IsValid)
            {
                Project pr = new Project
                {
                    Id = Guid.NewGuid(),
                    Name = Name,
                    LinkProject = LinkProject,
                    DateStart = DateTime.Now,
                    DateEnd = DateTime.Now
                };
                

            }

            return View();
        }

    }
}