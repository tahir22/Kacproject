using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webappiProject.Models
{
    public class AttendanceCategory
    {
        [Key]
        public int AttendanceCategoryId { get; set; }

        public string AttendanceCategoryName { get; set; }
        public ICollection<Attendance> Attendance { get; set; }
    }
}