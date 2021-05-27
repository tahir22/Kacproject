using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using webappiProject.Models;

namespace webappiProject.Controllers
{
    
    public class HomeController : Controller
    {
        DBContext db= new DBContext();


        public ActionResult Index()
        {
            List<SelectListItem> listttt = new List<SelectListItem>();


            listttt.Add(new SelectListItem { Text = "Male", Value = "1" });
            listttt.Add(new SelectListItem { Text = "Female", Value = "2" });
            listttt.Add(new SelectListItem { Text = "other", Value = "3" });

            ViewBag.listttt = listttt;

            return View();
        }
   //     public ActionResult Index()
   //     {
   //         ViewBag.Title = "Home Page";











        //         //  var results = (from p in db.SalarModel
        //         //                group p by new {p.Month} into g
        //         //                select new { Salary = g.Sum(x=>x.Salary) }).ToList();


        //         //var ff = db.SalarModel.GroupBy(x => x.Month).Select(grp => grp.Sum(x=>x.Salary)).ToList();


        //         //var total2Review = db.SalarModel
        //         //                     .GroupBy(i => i.Month)
        //         //                     .Where(g => g.Count() > 1)     // This "Where" becomes "having"
        //         //                     .ToList();





        //         //        .GroupBy(c => c.Name)
        //         //.Where(grp => grp.Count() > 1)
        //         //.Select(grp => grp.Key);

        //         var   n = 3.14599;
        //        var a = System.Math.Round(n, 2, MidpointRounding.ToEven);       // 3.14
        //       var b = System.Math.Round(n, 2, MidpointRounding.AwayFromZero); // 3.15

        //       double c = System.Math.Truncate(n * 100) / 100;                    // 3.14
        //         var d = System.Math.Ceiling(n * 100) / 100;


        //         List<string> List1 = new List<string>() { "Apple", "Banana"};
        //         List<string> List2 = new List<string>() { "Apple", "Banana", "Carrot", "Grape", "Plum" };
        //         var firstNotSecond = List1.Except(List2).ToList();

        //         //List<string> l = new List<string>();
        //         //List<string> ltt = new List<string>();
        //         //l.Add("1"); l.Add("1");
        //         //l.Add("2");
        //         //l.Add("2"); // duplicate
        //         //l.Add("3");
        //         //l.Add("4");
        //         //l.Add("4"); // duplicate
        //         //l.Add("5");

        //         // Make new unique list
        //         // List<string> uniqueList = l.Distinct().ToList();


        //         //uniqueList.ForEach(i => ltt.Add(i) );
        //         //var searchStr = "4";

        //         //var results = (from c in db.Employees
        //         //              where SqlMethods.Like(c.countt, "%" + "4" + "%,"  )
        //         //              select c).ToList();



        //         //var result = db.Employees.Where(x => DbFunctions.Like(x.countt, string.Format("%{0}%", searchStr))).ToList();

        //         //        var qq = ( from c in db.Employees 
        //         //                   join p in db.City on c.CityId equals p.CityId select c).ToList();

        //         //        List<Employee> gg = new List<Employee>();
        //         //        foreach (var item in q)
        //         //        {

        //         //            item.Employee.CityNamee = item.CityNamee;
        //         //            gg.Add(item.Employee );
        //         //        }



        //         //var yy = GetMACAddress();
        //         //var yyy = GetIPAddress();


        //         //string strHostName = System.Net.Dns.GetHostName();
        //         //IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
        //         //IPAddress[] addr = ipEntry.AddressList;
        //         //string ip = addr[1].ToString();


        //         var ggg = db.Employees.ToList();
        //         var q = (
        //from cc in db.Employees
        //join p in db.City on cc.CityId equals p.CityId into ps
        //from p in ps.DefaultIfEmpty()
        //select new { Employee = c, CityNamee = p == null ? "(No CityName)" : p.CityName }).ToList();
        //         return View();
        //         //return View(gg);
        //     }

        public ActionResult IndexTest()
        {
          
            return View();
            //return View(gg);
        }


        public ActionResult GetEmployee()
        {
            
            List<SelectListItem> gg = new List<SelectListItem>();
            var gguu = db.Employees.ToList();
            gg.Add(new SelectListItem { Text = "all", Value = "0", Selected = true });
            foreach (var item in gguu)
            {
                gg.Add(new SelectListItem { Text = item.EmployeeName, Value = item.EmployeeId.ToString()  });
            }
            return Json(gg, JsonRequestBehavior.AllowGet);
            //return View(gg);
        }


        [HttpGet]
        public ActionResult PicUpload()
        {
           
 



            return View( );
        }
        [HttpPost]
        public ActionResult PicUpload(Picmodel obje , HttpPostedFileBase pic)
        {

            var fileName = Path.GetFileName(pic.FileName);
            var path = Path.Combine(Server.MapPath("~/Content/Upload"), fileName);

            
           pic.SaveAs(path);


            var path2 = "/Content/Upload/"+ fileName;

            var path22 = Path.Combine(Server.MapPath(path2), fileName);

            var path225 = Path.Combine(Server.MapPath(path2));
            obje.FullPath = path;
            obje.Path = path2;
            db.Picmodel.Add(obje);
            db.SaveChanges();

   

            return View( );
        }


        






        public string GetIPAddress()
        {
            string IPAddress = "";
            IPHostEntry Host = default(IPHostEntry);
            string Hostname = null;
            Hostname = System.Environment.MachineName;
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    IPAddress = Convert.ToString(IP);
                }
            }
            return IPAddress;
        }




        private static string GetMACAddress()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                    return AddressBytesToString(nic.GetPhysicalAddress().GetAddressBytes());
            }

            return string.Empty;
        }

        private static string AddressBytesToString(byte[] addressBytes)
        {
            return string.Join(":", (from b in addressBytes
                                     select b.ToString("X2")).ToArray());
        }
        public ActionResult Index2()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Index22()
        {
            ViewBag.Title = "Home Page";

            return View();
        }



        public ActionResult Index233()
        {
            ViewBag.Title = "Home Page";

            return View();
        } 
        public ActionResult Index2332()
        {
            ViewBag.Title = "Home Page";

            return View();
        }



        public ActionResult Index2333()
        {
            ViewBag.Title = "Home Page";

            return View();
        } 
        public ActionResult jqueryCharts22()
        {
           
            

            return View();
        }
             public ActionResult IndexBase64string()
        {
            var pathh = db.Picmodel.ToList();

            foreach (var path in pathh)
            {
                string pathss = path.FullPath;

                // var GetContentTypeee = pathss.GetContentType();
                //var ttyy = MimeTypes.GetContentType(pathss);
                var GetContentType = pathss.GetContentTypeByMT() ;
                //var tt = pathss.ConvertToBase66Stringpath();
            }




            //ViewBag.path = tt;

            return View();
        }


    }
}
