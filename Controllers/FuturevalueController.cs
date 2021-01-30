using eVisitor_mvcnet5.Models;
using Microsoft.AspNetCore.Mvc;

namespace eVisitor_mvcnet5.Controllers
{
    public class FuturevalueController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.FutureValue = "";
            return View();
        }

        [HttpPost]
        public IActionResult Index(FutureValueModel fv)
        {
            if (ModelState.IsValid)
            {
                ViewBag.FutureValue = fv.Calculate().ToString("c2");
            }
            else
            {
                ViewBag.FutureValue = "";
            }
            
            return View();
        }

    }

    //
}