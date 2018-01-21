using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ans.Models;
using System.Threading.Tasks;

namespace ans.Controllers
{
    public class TeamController : Controller
    {
        // GET: Team
        [Authorize]
        public ActionResult Index()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            var Users = dbContext.Users.ToList();

            ViewBag.Users = Users;

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTeam(Team team)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext dbContext = new ApplicationDbContext();
            

                Team t = new Team {

                    Id = Guid.NewGuid(),
                    Name = team.Name,
                   
                };
                dbContext.Teams.Add(t);
                dbContext.SaveChanges();

                ViewBag.Message = "Команда успешно добавлена!";
                ViewBag.Check = 1;
            }
            else
            {
                ViewBag.Message = "Команда не добавлена!";
                ViewBag.Check = 0;
            }

            return View("Index");
        }

    }
}