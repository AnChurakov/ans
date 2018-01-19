using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ans.Models
{
    public class Status : DbContext
    {
        public Guid Id { get; set; }

        //Название этапа
        [Required(ErrorMessage = "Это обязательное поле")]
        [Display(Name = "Название статуса")]
        public string Name { get; set; }

        //public virtual ICollection<Project> Projects { get; set; }

    }
}