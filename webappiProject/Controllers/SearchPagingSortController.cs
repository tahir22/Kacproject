using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webappiProject.Models;

namespace webappiProject.Controllers
{
    public class SearchPagingSortController : Controller
    {
        DBContext db = new DBContext();
        // GET: SearchPagingSort
        public ActionResult Index(string option, string search , int? pageNumber , string sort)
        {

            //if the sort parameter is null or empty then we are initializing the value as descending name  
            ViewBag.SortByName = string.IsNullOrEmpty(sort) ? "descending name" : "";
            //if the sort value is gender then we are initializing the value as descending gender  
            ViewBag.SortByGender = sort == "Gender" ? "descending gender" : "Gender";

            //here we are converting the db.Students to AsQueryable so that we can invoke all the extension methods on variable records.  
            var records = db.Employees.AsQueryable();
      

            if (option == "Subjects")
            {
                records = records.Where(x => x.EmployeeName == search || search == null);
            }
            else if (option == "Gender")
            {
                records = records.Where(x => x.countt == search || search == null);
            }
            else
            {
                records = records.Where(x => x.EmployeeName.StartsWith(search) || search == null);
            }

            switch (sort)
            {

                case "descending name":
                    records = records.OrderByDescending(x => x.EmployeeName);
                    break;

                case "descending gender":
                    records = records.OrderByDescending(x => x.countt);
                    break;

                case "Gender":
                    records = records.OrderBy(x => x.countt);
                    break;

                default:
                    records = records.OrderBy(x => x.EmployeeName);
                    break;

            }
            return View(records.ToPagedList(pageNumber ?? 1, 3));

                 

            //if (option == "Subjects")
            //{
            //    //Index action method will return a view with a student records based on what a user specify the value in textbox  
            //    return View(db.Employees.Where(x => x.EmployeeName == search || search == null).ToList().ToPagedList(pageNumber ?? 1, 3));
            //}
            //else if (option == "Gender")
            //{
            //    return View(db.Employees.Where(x => x.countt == search || search == null).ToList().ToPagedList(pageNumber ?? 1, 3));
            //}
            //else
            //{
            //    return View(db.Employees.Where(x =>x.EmployeeName.StartsWith(search) || search == null).ToList().ToPagedList(pageNumber ?? 1, 3));
            //}





        }

















 





    }




    
 

}