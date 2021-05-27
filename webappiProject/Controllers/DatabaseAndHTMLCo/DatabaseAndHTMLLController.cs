using DocumentFormat.OpenXml.EMMA;
using Microsoft.VisualStudio.Services.Common.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using webappiProject.Models;

namespace webappiProject.Controllers.DatabaseAndHTMLCo
{
    public class DatabaseAndHTMLLController : Controller
    {
      
        DBContext db = new DBContext();

 
        // GET: DatabaseAndHTMLL
        public ActionResult Index()
        {
            
            return View();
        }
    }
}