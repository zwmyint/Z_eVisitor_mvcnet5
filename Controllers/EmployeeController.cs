using System.Collections.Generic;
using eVisitor_mvcnet5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eVisitor_mvcnet5.Controllers
{
    public class EmployeeController : Controller
    {
        private AppDbContext _db = null;

        public EmployeeController(AppDbContext db)
        {
            _db = db;
        }

        //
        public IActionResult List()
        {
            List<m_cls_Employee> model = (from e in _db.Employees orderby e.EmployeeID select e).ToList();
                                    
            return View(model);
        }

        //
        [HttpGet]
        public IActionResult Insert()
        {
            FillCountries();
            FillTitle();

            return View();
        }

        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(m_cls_Employee model)
        {
            FillCountries();
            FillTitle();

            if (ModelState.IsValid)
            {
                _db.Employees.Add(model);
                _db.SaveChanges();
                ViewBag.Message = "Employee added successfully";
            }

            return View(model);
        }

        //
        [HttpGet]
        public IActionResult Update(int id)
        {
            FillCountries();
            FillTitle();

            var model = _db.Employees.Find(id);
            return View(model);
        }

        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(m_cls_Employee model)
        {
            FillCountries();
            FillTitle();

            if (ModelState.IsValid)
            {
                _db.Employees.Update(model);
                _db.SaveChanges();
                ViewBag.Message = "Employee updated successfully";
            }

            return View(model);
        }


        
        //
        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var model = _db.Employees.Find(id);
            return View(model);
        }

        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = _db.Employees.Find(id);
            _db.Employees.Remove(model);
            _db.SaveChanges();
            TempData["Message"] = "Employee Deleted Successfully";
            return RedirectToAction("List");
        }



        //
        //
        private void FillTitle()
        {
            List<SelectListItem> listOfTitles = (from c in _db.Employees
                                                    select new SelectListItem()
                                                    {
                                                        Text = c.Title,
                                                        Value = c.Title
                                                    }).Distinct().ToList();
            ViewBag.Titles = listOfTitles;

        }

        //
        private void FillCountries()
        {
            List<SelectListItem> listOfCountries = (from c in _db.Employees
                                                    select new SelectListItem()
                                                    {
                                                        Text = c.Country,
                                                        Value = c.Country
                                                    }).Distinct().ToList();
            ViewBag.Countries = listOfCountries;

        }


    }


}