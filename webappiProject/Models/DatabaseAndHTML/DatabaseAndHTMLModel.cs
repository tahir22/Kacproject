using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webappiProject.Models.DatabaseAndHTML
{
    public class DatabaseAndHTMLModel
    { [Key]
        public int MyProperty { get; set; }
        [AllowHtml]
        public string Data { get; set; }
        public string DataHtml { get; set; }
    }
}