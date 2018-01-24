using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ans.Models;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ans.Models
{
    public class Vacancy : DbContext
    {

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Это обязательное поле")]
        [DataType(DataType.Text)]
        [Display(Name = "Название вакансии")]
        public string Name { get; set; }

    }
}