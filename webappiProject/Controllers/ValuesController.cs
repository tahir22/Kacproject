using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using webappiProject.Models;
using System.Data.Entity;
using System.Web;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http.Cors;

namespace webappiProject.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        DBContext db = new DBContext();
        // GET api/values
        public List<Array>   Get()
        {
            //var path = db.Picmodel.Where(x => x.Id == 1).FirstOrDefault();
            //string pathss = path.FullPath;


            //using (FileStream fileStream = File.OpenRead(pathss))
            //{
            //    MemoryStream memStream = new MemoryStream();
            //    memStream.SetLength(fileStream.Length);
            //    fileStream.Read(memStream.GetBuffer(), 0, (int)fileStream.Length);
            //    var fff = fileStream.ConvertToBase64();

            //}
            List<Array> listofarray = new List<Array>();
            var ListOfCity = db.City.Select(x => new { x.CityId, x.CityName }).ToArray();
            var ListOfEmpCategory = db.EmpCategory.Select(x => new { x.EmpCategoryId, x.EmpCategoryName }).ToArray();
            listofarray.Add(ListOfEmpCategory);
            listofarray.Add(ListOfCity);
           
          return listofarray;
            //using (var memoryStream = new MemoryStream())
            //{


            //    var fileName = $"FileName.xlsx";
            //    string tempFilePath = Path.Combine(path.FullPath);


            //    using (var fs = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write))
            //    {

            //        memoryStream.WriteTo(fs);
            //    }


            //using (FileStream fileStream = new FileStream(pathss, FileMode.Open, FileAccess.Read))
            //{
            //    fileStream.CopyTo(memoryStream);
            //}
            // var fff = memoryStream.ConvertToBase64();  



            //var fff2 = memoryStream.ConvertToBase644();


            // string path = @"c:\temp\MyTest.txt";

            // Create the file, or overwrite if the file exists.






            //var employeeList = db.Employees
            //    .Include(c => c.Salary)
            //    .Include(c => c.Attendance)
            //    .ToList();


            //return employeeList;
        }



     
         [Route("api/Values/GetEmployee")]
        public List<Employee> GetEmployee()
        {
        var hhh = db.Employees.Include(x=>x.EmpCategory).Include(x=>x.City).ToList();

            return hhh;
        }

        // GET api/values/5
        public string Get(int id)
        {

            var path = db.Picmodel.Where(x => x.Id == 1).FirstOrDefault();

            using (var memoryStream = new MemoryStream())
            {
             

              var fileName = $"FileName.xlsx";
                string tempFilePath = Path.Combine(path.Path);
                using (var fs = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write))
                {
                    memoryStream.WriteTo(fs);
                }

            }
            return "value";
        }

        // POST api/values
        public string Post(Employee emp)
        {

            db.Employees.Add(emp);
            db.SaveChanges();

            return "data saved successfully";
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
