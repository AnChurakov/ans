using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ans.Models
{
    public class Project : DbContext
    {

        public Guid Id { get; set; }

        //Название проекта
        public string Name { get; set; }

        //Дата закрытия проекта
        public DateTime DateEnd { get; set; }

        //Дата начала проекта
        public DateTime DateStart { get; set; }

        //Процент выполнения проекта
        public int Procent { get; set; }

        //Ссылка на проекта
        public string LinkProject { get; set; }
    }
}