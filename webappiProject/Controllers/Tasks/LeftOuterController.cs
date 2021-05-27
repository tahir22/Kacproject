using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webappiProject.Models;

namespace webappiProject.Controllers.Tasks
{
    public class LeftOuterController : Controller
    {
        DBContext db = new DBContext();
        // GET: LeftOuter
        public ActionResult Index()
        {
            //left outer join in linq
    
            var q = (
    from c in db.Employees
    join p in db.City on c.CityId equals p.CityId into ps
    from pp in ps.DefaultIfEmpty()
    select new { Employee = c, CityNamee = pp == null ? "(No CityName)" : pp.CityName }).ToList();


            //or

            var leftOuterJoin = from c in db.Employees
                                join p in  db.City on c.CityId equals p.CityId  into dept
                                from department in dept.DefaultIfEmpty()
                                select new
                                {
                                    Employee = c,
                                   
                                    DepartmentName = department.CityName
                                };



            /////////////////////////////////////////////////////////////////////////////////////////////

            //Right outer join in linq


            var rightOuterJoin = from d in db.City
                                 join e in db.Employees on d.CityId equals e.CityId into emp
                                 from hhemployee in emp.DefaultIfEmpty()
                                 select new
                                 {
                                     Employee = d,
                                     CityNamee = hhemployee == null ? "(No CityName)" : d.CityName
                                 };









    



            return View();
        }public ActionResult Index2()
        {
            //left outer join in linq
    
            var q = (
    from c in db.Employees
    join p in db.City on c.CityId equals p.CityId into ps
    from p in ps.DefaultIfEmpty()
    select new { Employee = c, CityNamee = p == null ? "(No CityName)" : p.CityName }).ToList();


            //or

            var leftOuterJoin = from c in db.Employees
                                join p in  db.City on c.CityId equals p.CityId  into dept
                                from department in dept.DefaultIfEmpty()
                                select new
                                {
                                    Employee = c,
                                   
                                    DepartmentName = department.CityName
                                };
         

            return View();
        }
    }
}