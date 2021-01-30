using System.Collections.Generic;
using System.Linq;
using eVisitor_mvcnet5.Models;
using Microsoft.AspNetCore.Mvc;


namespace eVisitor_mvcnet5.Controllers
{
    public class PersonController : Controller
    {
        //
        List<m_cls_Person> db;
        public PersonController()
        {
            db = new List<m_cls_Person>()
            {
                new m_cls_Person()
                {
                    Id = 1,
                    firstName = "Hello",
                    lastName ="World",
                    s_Amount = 100.00
                },
                new m_cls_Person()
                {
                    Id = 2,
                    firstName = "Foo",
                    lastName ="Bar",
                    s_Amount = 101.00
                },
                new m_cls_Person()
                {
                    Id = 3,
                    firstName = "Zaw",
                    lastName ="Win Myint",
                    s_Amount = 102.00
                }
            };
        }

        //
        [HttpGet]
        public IActionResult Index()
        {
            List <m_cls_Person> model = db.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            m_cls_Person model = db.Where(e => e.Id == id).FirstOrDefault();
            return Ok(model);
        }

        public JsonResult GetPerson(int id)
        {
            var person = db.Where(p => p.Id == id).SingleOrDefault();
            return Json(person);
        }
        //
    }

}