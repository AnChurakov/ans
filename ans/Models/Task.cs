using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ans.Models
{
    public class TaskProject : DbContext
    {
        public Guid Id { get; set; }

        //Описание задачи
        [Required(ErrorMessage = "Это обязательное поле")]
        [Display(Name = "Описание задачи")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        //Название задачи
        [Required(ErrorMessage = "Это обязательное поле")]
        [Display(Name = "Название задачи")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        //Дата открытия задачи
        public DateTime DateStart { get; set; }

        //Дата закрытия задачи
        public DateTime DateEnd { get; set; }

        //Ссылка на проект
        public virtual Project Projects { get; set; }
    }
}