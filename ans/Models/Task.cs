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

        //Название задачи
        public string Name { get; set; }

        //Дата открытия задачи
        public DateTime DateStart { get; set; }

        //Дата закрытия задачи
        public DateTime DateEnd { get; set; }

        //Ссылка на проект
        public virtual Project Projects { get; set; }
    }
}