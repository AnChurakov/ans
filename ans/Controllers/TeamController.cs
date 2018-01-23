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
            return View();
        }

        [Authorize]
        public ActionResult AddUser()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            TeamViewModel AddInTeam = new TeamViewModel
            {
                Teams = dbContext.Teams.ToList(),
                Users = dbContext.Users.ToList()
            };

            return View(AddInTeam);
        }

        /// <summary>
        /// Добавление пользователя в команду
        /// </summary>
        /// <param name="IdTeams">id выбранной команды</param>
        /// <param name="IdUser">id выбранного пользователя</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectResult AddUserInTeam(Guid IdTeams, string IdUser)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            
            if (IdTeams != null && IdUser != null)
            {
                var SelectUser = dbContext.Users.FirstOrDefault(a => a.Id == IdUser);

                var SelectTeam = dbContext.Teams.FirstOrDefault(s => s.Id == IdTeams);

                SelectUser.Teams = SelectTeam;

                dbContext.SaveChanges();
            }

            return Redirect("AddUser");
        }

        /// <summary>
        /// Создание новой команды
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
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