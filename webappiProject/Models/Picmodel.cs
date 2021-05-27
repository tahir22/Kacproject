using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webappiProject.Models
{
    public class Picmodel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public HttpPostedFileBase Pic { get; set; }
        public string Path { get; set; }
        public string FullPath { get; set; }
    }
}