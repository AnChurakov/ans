using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ans.Models;
using System.Data.Entity;

namespace ans.Models
{
    public class TeamViewModel
    {
        public ICollection<Team> Teams { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
    }
}