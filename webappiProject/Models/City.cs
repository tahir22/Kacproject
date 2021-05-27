using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webappiProject.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public ICollection<Employee> Employee { get; set; }
    }
}