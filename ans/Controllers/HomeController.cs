﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ans.Models;

namespace ans.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            var SelectUser = dbContext.Users.FirstOrDefault(a => a.Email == User.Identity.Name);

            return View(SelectUser);
        }

    }
}