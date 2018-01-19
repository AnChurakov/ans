using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using ans.Models;

namespace ans.Controllers
{
    public class StatusController : Controller
    {
        // GET: Status
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateStatus(Status status)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext dbContext =  new ApplicationDbContext();

                Status st = new Status {
                        
                    Id = Guid.NewGuid(),
                    Name = status.Name
                };

                dbContext.Status.Add(st);
                dbContext.SaveChanges();
                ViewBag.Check = 1;
                ViewBag.Message = "Статус успешно добавлен!";
            }
            else
            {
                ViewBag.Check = 0;
                ViewBag.Message = "Статус не добавлен!";
            }

            return View("Index");

        }
    }
}