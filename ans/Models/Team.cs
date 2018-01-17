using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ans.Models
{
    public class Team : DbContext
    {
        public Guid Id { get; set; }

        //Название команды
        public string Name { get; set; }

    }
}