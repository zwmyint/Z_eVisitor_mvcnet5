using System;
using System.Linq;
using eVisitor_mvcnet5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eVisitor_mvcnet5.Controllers
{
    public class TodoController : Controller
    {
        private AppDbContext2 _context;

        public TodoController(AppDbContext2 ctx)
        {
            _context = ctx;
        }

        //
        public IActionResult Index(string id)
        {            

            var model = new ToDoViewModel();
            model.Filters = new m_cls_Filters(id);
            model.Categories = _context.tbl_Categories.ToList();
            model.Statuses = _context.tbl_Statuses.ToList();
            model.DueFilters = m_cls_Filters.DueFilterValues;

            IQueryable<m_cls_ToDo> query = _context.tbl_ToDos.Include(c => c.Category).Include(s => s.Status);

            if (model.Filters.HasCategory)
            {
                query = query.Where(t => t.CategoryId == model.Filters.CategoryId);
            }
                
            if (model.Filters.HasStatus)
            {
                query = query.Where(t => t.StatusId == model.Filters.StatusId);
            }
                
            if (model.Filters.HasDue)
            {
                var today = DateTime.Today;

                if (model.Filters.IsPast)
                query = query.Where(t => t.DueDate < today);
                else if (model.Filters.IsFuture)
                query = query.Where(t => t.DueDate > today);
                else if (model.Filters.IsToday)
                query = query.Where(t => t.DueDate == today);
            }

            var tasks = query.OrderBy(t => t.DueDate).ToList();

            model.Tasks = tasks;

            return View(model);
            
        }

        //
        [HttpGet]
        public IActionResult Add()
        {
            var model = new ToDoViewModel();
            model.Categories = _context.tbl_Categories.ToList();
            model.Statuses = _context.tbl_Statuses.ToList();

            return View(model);
        }

        //
        [HttpPost]
        public IActionResult Add(ToDoViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.tbl_ToDos.Add(model.CurrentTask);
                _context.SaveChanges();
                return RedirectToAction("Index", "Todo");
            }
            else
            {
                model.Categories = _context.tbl_Categories.ToList();
                model.Statuses = _context.tbl_Statuses.ToList();
                return View(model);
            }
        }
        
        //
        [HttpPost]
        public IActionResult EditDelete([FromRoute] string id, m_cls_ToDo selected)
        {
            if (selected.StatusId == null)
                _context.tbl_ToDos.Remove(selected);
            else
            {
                string newStatusId = selected.StatusId;
                selected = _context.tbl_ToDos.Find(selected.Id);
                selected.StatusId = newStatusId;
                _context.tbl_ToDos.Update(selected);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Todo", new { ID = id });
        }

        //
        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string id = string.Join('-', filter);
            return RedirectToAction("Index", "Todo", new { ID = id });
        }



        //
    }

    
}