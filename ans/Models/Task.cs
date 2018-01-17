using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ans.Models
{
    public class Task : DbContext
    {
        public Guid Id { get; set; }

        //Название задачи
        public string Name { get; set; }

        //Дата открытия задачи
        public DateTime DateStart { get; set; }

        //Дата закрытия задачи
        public DateTime DateEnd { get; set; }
    }
}