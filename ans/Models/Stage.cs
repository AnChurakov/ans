using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ans.Models
{
    public class Stage : DbContext
    {
        
        public Guid Id { get; set; }

        //Название этапа
        [Required(ErrorMessage = "Это обязательное поле")]
        [DataType(DataType.Text)]
        [Display(Name = "Название этапа")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Слишком короткое название этапа")]
        public string Name { get; set; }

       // public virtual Project Projects { get; set; }
    }
}