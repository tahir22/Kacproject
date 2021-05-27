using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webappiProject.Models
{
    public class EmployeeInformation
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}