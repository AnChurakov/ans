using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

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

        //Ссылка на команду проекта
        public Team Team { get; set; }

        //Ссылка на этап проекта
        public Stage Stage { get; set; }

        //Ссылка на задачи проекта
        public virtual ICollection<TaskProject> TaskProjects { get; set; }

        //Ссылка на статус проекта
        public Status Status { get; set; }
    }
}