using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webappiProject.Models
{
    public class Salary
    {
        [Key]
        public int SalaryId { get; set; }
        public string SalaryName { get; set; }
        public int EmployeeId { get; set; }
        public int SalaryCategoryId { get; set; }
        public Employee Employee { get; set; }
        public SalaryCategory SalaryCategory { get; set; }
    }
}