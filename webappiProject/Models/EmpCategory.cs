using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webappiProject.Models
{
    public class EmpCategory
    {
        [Key]
        public int EmpCategoryId { get; set; }
        public string EmpCategoryName { get; set; }
        public ICollection<Employee> Employee { get; set; }


    }
}