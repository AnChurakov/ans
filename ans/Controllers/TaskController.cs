using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ans.Models;
using System.Threading.Tasks;

namespace ans.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Добавление новой задачи к проекту
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTask (TaskProject task)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext dbContext = new ApplicationDbContext();

                TaskProject tp = new TaskProject {

                    Id = Guid.NewGuid(),
                    Name = task.Name,
                    Description = task.Description

                };

                dbContext.TaskProjects.Add(tp);
                dbContext.SaveChanges();
                ViewBag.Message = "Задача успешно добавлена";
                ViewBag.Check = 1;
            }
            else
            {
                ViewBag.Message = "Задача не добавлена!";
                ViewBag.Check = 0;
            }

            return View("Index");
        }
    }
}