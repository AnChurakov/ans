using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ans.Models;
using System.Threading.Tasks;

namespace ans.Controllers
{
    public class StageController : Controller
    {
        // GET: Stage
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateStage(Stage stage)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext dbContext = new ApplicationDbContext();

                Stage st = new Stage {
                    Id = Guid.NewGuid(),
                    Name = stage.Name
                };

                dbContext.Stage.Add(st);
                dbContext.SaveChanges();
                ViewBag.Check = 1;
                ViewBag.Message = "Этап успешно добавлен!";
            }
            else
            {
                ViewBag.Check = 0;
                ViewBag.Message = "Этап не добавлен!";
            }

            return View("Index");

        }
    }
}