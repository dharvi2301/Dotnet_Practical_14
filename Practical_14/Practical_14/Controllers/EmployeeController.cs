using PagedList;
using Practical_14.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Practical_14.Controllers
{
    public class EmployeeController : Controller
    {
        private Employee_Db_Practical_14Entities db = new Employee_Db_Practical_14Entities();

        // GET: Employees
        public ActionResult Index(string search, int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var employees = db.Employee14.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                employees = employees.Where(x => x.Name.StartsWith(search));
            }

            return View(employees.OrderBy(e => e.Id).ToPagedList(pageNumber, pageSize));
        }
        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee14 employee = db.Employee14.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,DOB,Age")] Employee14 employee)
        {
            if (ModelState.IsValid)
            {
                db.Employee14.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee14 employee = db.Employee14.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DOB,Age")] Employee14 employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee14 employee = db.Employee14.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee14 employee = db.Employee14.Find(id);
            db.Employee14.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        //  Implement search functionality to search records into the database by Name field using the AJAX.

        public JsonResult Search(string searchString)
        {
            dynamic employees = db.Employee14
                .Where(e => e.Name.ToLower().Contains(searchString.ToLower()))
                .Select(e => new { e.Id, e.Name, e.DOB, e.Age })
                .ToList();

            if (searchString == "")
            {
                employees = db.Employee14.ToList();
            }

            return Json(employees, JsonRequestBehavior.AllowGet);
        }

        //Paging 
        public JsonResult GetEmployees(string searchStr, int page = 1)
        {
            int pageSize = 10;
            var query = db.Employee14.AsQueryable();
            if (!string.IsNullOrEmpty(searchStr))
            {
                query = query.Where(x => x.Name.Contains(searchStr));
            }
            int totalRecords = query.Count();
            var data = query.OrderBy(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return Json(new { data = data, totalRecords = totalRecords }, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
}
}