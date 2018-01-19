using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ans.Models;

namespace ans.Models
{
    public class Team : DbContext
    {
        [Key, ForeignKey("Projects")]
        public Guid Id { get; set; }

        //Название команды
        public string Name { get; set; }

        //Ссылка на пользователя
        public virtual ApplicationUser User { get; set; }

        //Ссылка на проект
        public virtual Project Projects { get; set; }

    }
}