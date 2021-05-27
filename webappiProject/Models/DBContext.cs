using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using webappiProject.Models.DatabaseAndHTML;
using webappiProject.Models.PARTIALCLASS;

namespace webappiProject.Models
{
    //public class DBContext
    //{
    //}
    public class DBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public DBContext() : base("name=SampleAppContext")
        {
            Database.SetInitializer<DBContext>(null);
        }

        internal static IDisposable Create()
        {
            throw new NotImplementedException();
        }

        public System.Data.Entity.DbSet<Employee> Employees { get; set; }
        public System.Data.Entity.DbSet<Attendance> Attendance { get; set; }
        public System.Data.Entity.DbSet<Salary> Salary { get; set; }
        public System.Data.Entity.DbSet<EmpCategory> EmpCategory { get; set; }
        public System.Data.Entity.DbSet<AttendanceCategory> AttendanceCategory { get; set; }
        public System.Data.Entity.DbSet<SalaryCategory> SalaryCategory { get; set; }
        public System.Data.Entity.DbSet<EmployeeInformation> EmployeeInformation { get; set; }
        public System.Data.Entity.DbSet<City> City { get; set; }
        public System.Data.Entity.DbSet<Picmodel> Picmodel { get; set; }
        public System.Data.Entity.DbSet<SalarModel> SalarModel { get; set; }
        public System.Data.Entity.DbSet<StudentPARTIALCLASS> StudentPARTIALCLASS { get; set; }
        public System.Data.Entity.DbSet<Students> Students { get; set; }
        public System.Data.Entity.DbSet<DatabaseAndHTMLModel> DatabaseAndHTMLModel { get; set; }

 



    }
}