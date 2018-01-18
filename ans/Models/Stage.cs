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
        [Key, ForeignKey("Projects")]
        public Guid Id { get; set; }

        //Название этапа
        public string Name { get; set; }

        public virtual Project Projects { get; set; }
    }
}