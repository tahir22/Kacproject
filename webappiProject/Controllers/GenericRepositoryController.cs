using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webappiProject.Models;
 
using webappiProject.Models.DALGenericRepository;

namespace webappiProject.Controllers
{
    public class GenericRepositoryController : Controller
    {
        private _IAllRepository<Employee> interfaceobj;
        public GenericRepositoryController()
        {
            this.interfaceobj = new AllRepository<Employee>();
        }
        // GET: GenericRepository
        public ActionResult Index()
        {
            return View(from m in interfaceobj.GetModel() select m);
        }

        // GET: GenericRepository/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GenericRepository/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenericRepository/Create
        [HttpPost]
        public ActionResult Create(Employee collection)
        {
            try
            {
                // TODO: Add insert logic here
                interfaceobj.InsertModel(collection);
                interfaceobj.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GenericRepository/Edit/5
        public ActionResult Edit(int id)
        {
            Employee b = interfaceobj.GetModelByID(id);
            return View(b);
        }

        // POST: GenericRepository/Edit/5
        [HttpPost]
        public ActionResult EditEdit(int id, Employee collection)
        {
            try
            {
                // TODO: Add update logic here
                interfaceobj.UpdateModel(collection);
                interfaceobj.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GenericRepository/Delete/5
        public ActionResult Delete(int id)
        {

            Employee b = interfaceobj.GetModelByID(id);
            return View(b);
        }

        // POST: GenericRepository/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee collection)
        {
            try
            {
                // TODO: Add delete logic here
                interfaceobj.DeleteModel(id);
                interfaceobj.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
