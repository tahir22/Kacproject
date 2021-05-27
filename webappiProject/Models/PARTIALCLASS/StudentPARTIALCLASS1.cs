using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webappiProject.Models.PARTIALCLASS
{
    public partial class StudentPARTIALCLASS
    {
        [Key]
        public int StudentPARTIALCLASSId { get; set; }
        public string Name { get; set; }
    }
}