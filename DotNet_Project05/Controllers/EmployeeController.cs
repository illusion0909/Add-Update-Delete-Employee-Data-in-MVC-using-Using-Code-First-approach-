using DotNet_Project05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNet_Project05.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Employee
        public ActionResult Index()
        {
            var EmployeeList = _context.Employees.ToList();
            return View(EmployeeList);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Employee employee)
        {
            if (employee == null)
                return HttpNotFound();
            _context.Employees.Add(employee);
            _context.SaveChanges();
            //return RedirectToAction("index");
            return RedirectToAction(nameof(Index));

        }
        public ActionResult Edit(int id)
        {
            //select * from tbemp where empno=id
            var employeeFromDb = _context.Employees.Find(id);
            //var employeeInDb = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
            // var employeeInDb = _context.Employees.Where(e => e.EmployeeId == id).FirstOrDefault();
            if (employeeFromDb == null)
                return HttpNotFound();
            return View(employeeFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Employee employee)
        {
            if (employee == null) return HttpNotFound();

            var employeeInDb = _context.Employees.Find(employee.EmployeeId);
            if (employeeInDb == null)
                return HttpNotFound();
            employeeInDb.Name = employee.Name;
            employeeInDb.Address = employee.Address;
            employeeInDb.Salary = employee.Salary;
            employeeInDb.Age = employee.Age;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public ActionResult Details(int id)
        {
            var employeInDb = _context.Employees.Find(id);
            if (employeInDb == null)
                return HttpNotFound();
            return View(employeInDb);
        }

        public ActionResult Delete(int id)
        {
            var employeeInDb = _context.Employees.Find(id);
            if (employeeInDb == null)
                return HttpNotFound();
            return View(employeeInDb);
        }
        [HttpPost]
        public ActionResult Delete(Employee employee, int id)
        {
            var employeeInDb = _context.Employees.Find(id);
            if (employeeInDb == null)
                return HttpNotFound();
            _context.Employees.Remove(employeeInDb);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        //[HttpPost]
        //public ActionResult Delete_Rec(int id)
        //{
        //    var employeeInDb = _context.Employees.Find(id);
        //    if (employeeInDb == null)
        //        return HttpNotFound();
        //    _context.Employees.Remove(employeeInDb);
        //    _context.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}


    }
}