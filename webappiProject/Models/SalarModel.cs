using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webappiProject.Models
{
    public class SalarModel
    {
        
        [Key]
        public int SalarModelId { get; set; }
        public string Name { get; set; }
        public Double Salary { get; set; }
        public int Month { get; set; }
    }
}