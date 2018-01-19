using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ans.Models;

namespace ans.Controllers
{
    public class PositionController : Controller
    {
        // GET: Position
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}