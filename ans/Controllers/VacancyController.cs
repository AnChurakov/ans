using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ans.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ans.Controllers
{
    public class VacancyController : Controller
    {
        // GET: Vacancy
        [Authorize]
        public ActionResult Index()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            ViewBag.Teams = dbContext.Teams.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectResult CreateVacancy(Vacancy vac, Guid Team)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext dbContext = new ApplicationDbContext();

                var SelectTeam = dbContext.Teams.FirstOrDefault(t => t.Id == Team);

                Vacancy v = new Vacancy
                {
                    Id = Guid.NewGuid(),
                    Name = vac.Name,
                    Teams = new List<Team>() { SelectTeam}
                };

                dbContext.Vacancy.Add(v);
                dbContext.SaveChanges();

                ViewBag.Check = 1;
                ViewBag.Message = "Вакансия успешно добавлена!";
            }
            else
            {
                ViewBag.Check = 0;
                ViewBag.Message = "Вакансия не добавлена!";
            }

            return Redirect("Index");
        }
    }
}