using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ans.Models;
using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ans.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult AddUsers()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            ViewBag.Users = dbContext.Users.ToList();

            ViewBag.Roles = dbContext.Roles.ToList();

            return View();
        }

        [HttpPost]
        public RedirectResult AddRoleUser(List<string> Users, List<string> Roles)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(dbContext));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(dbContext));

            foreach (var user in Users)
            {
                foreach(var role in Roles)
                {
                    var SelectRoles = dbContext.Roles.FirstOrDefault(r => r.Id == role);

                    //Если у пользователя нет данной роли, то добавляем выбранную роль
                    if (!userManager.IsInRole(user, SelectRoles.Name))
                    {
                        userManager.AddToRole(user, SelectRoles.Name);
                    }
                   
                }
            }
            

            dbContext.SaveChanges();


            return Redirect("AddUsers");
        }

        /// <summary>
        /// Добавление новой роли
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddRole(string NameRole)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(dbContext));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(dbContext));

            if (NameRole != null)
            {
                // добавляем роль
                var NewRole = new IdentityRole { Name = NameRole };

                // добавляем роли в бд
                roleManager.Create(NewRole);

                ViewBag.Message = "Роль успешно добавлена";
                ViewBag.Check = 1;
            }
            else
            {
                ViewBag.Check = 0;
                ViewBag.Message = "Роль не добавлена!";
            }

            return View("Index");
        }
    }
}