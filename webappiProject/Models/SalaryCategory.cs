using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webappiProject.Models
{
    public class SalaryCategory
    {
        [Key]
        public int SalaryCategoryId { get; set; }

        public string Name { get; set; }
        public ICollection<Salary> Salary { get; set; }
    }
}