using jquery_datatable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jquery_datatable.Controllers
{
    public class EmpController : Controller
    {
        demoEntities db = new demoEntities();
        // GET: Emp
        public ActionResult Index()
        {
            

            return View(db.Emps.ToList());
        }


        public ActionResult Create()
        {
             return View();
        }


        [HttpPost]
        public ActionResult Create(Emp emp)
        {
            db.Emps.Add(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            var data = db.Emps.Where(x => x.EmpId == id).FirstOrDefault();


            return View(data);

        }
        [HttpPost]
        public ActionResult Edit(Emp emp)
        {
            Emp data = db.Emps.Where(x => x.EmpId == emp.EmpId).FirstOrDefault();
            if (data != null)
            {
                data.Ename = emp.Ename;
                data.location = emp.location;
                data.Salary = emp.Salary;
                db.SaveChanges();
            };
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            var data = db.Emps.Where(x => x.EmpId == id).FirstOrDefault();
            return View(data);

        }

        public ActionResult Delete(int? id)
        {
            Emp data = db.Emps.Where(x => x.EmpId == id).FirstOrDefault();

            db.Emps.Remove(data);
            db.SaveChanges();

            return RedirectToAction("Index");

        }
      
    }
}