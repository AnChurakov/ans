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
        [Required(ErrorMessage = "Это обязательное поле")]
        [Display(Name = "Название проекта")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Поле не должно быть пустым!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Это обязательное поле")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание проекта")]
        public string Description { get; set; }

        //Дата завершения проекта
        [Display(Name = "Дата завершения проекта")]
        [DataType(DataType.DateTime)]
        public DateTime DateEnd { get; set; }

        //Дата начала проекта
        [Required(ErrorMessage = "Это обязательное поле")]
        [Display(Name = "Дата начала проекта")]
        [DataType(DataType.DateTime)]
        public DateTime DateStart { get; set; }

        //Процент выполнения проекта
        [Display(Name = "Процент выполнения проекта")]
        public int Procent { get; set; }

        //Ссылка на проекта
        [Required(ErrorMessage = "Это обязательное поле")]
        [Display(Name = "Ссылка на проект")]
        public string LinkProject { get; set; }

        //Ссылка на команду проекта
        public virtual Team Team { get; set; }

        //Ссылка на этап проекта
        public virtual Stage Stage { get; set; }

        //Ссылка на задачи проекта
        public virtual ICollection<TaskProject> TaskProjects { get; set; }

        //Ссылка на статус проекта
        public virtual Status Status { get; set; }
    }
}