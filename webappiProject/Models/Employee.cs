using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webappiProject.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
       
        public string EmployeeName { get; set; }
        public string countt { get; set; }
        public int? countted { get; set; }
        [NotMapped]
       public string CityNamee { get; set; }
        [NotMapped]
        public HttpPostedFileBase  Pic { get; set; }
        
        public int? CityId { get; set; }
        public City City { get; set; }
        public int EmpCategoryId { get; set; }
        public EmpCategory EmpCategory { get; set; }
        public ICollection<EmployeeInformation> EmployeeInformation { get; set; }
        public ICollection<Attendance> Attendance { get; set; }
        public ICollection<Salary> Salary { get; set; }
    }
}