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
        
        public Guid Id { get; set; }

        //Название команды
        [Required(ErrorMessage = "Это обязательное поле")]
        [DataType(DataType.Text)]
        [Display(Name = "Название команды")]
        public string Name { get; set; }

        //Ссылка на пользователей
        public virtual ICollection<ApplicationUser> Users { get; set; }

    }
}