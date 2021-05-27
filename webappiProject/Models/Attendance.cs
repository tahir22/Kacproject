using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webappiProject.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }
        public string AttendanceName { get; set; }
        public int EmployeeId { get; set; }
        public int AttendanceCategoryId { get; set; }
        public Employee Employee { get; set; }
        public AttendanceCategory AttendanceCategory { get; set; }
    }
}