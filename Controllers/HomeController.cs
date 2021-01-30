using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using eVisitor_mvcnet5.Models;

namespace eVisitor_mvcnet5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Home Page (In or Out)
            return View();
        }

        // Modal Popup Test
        public ActionResult ModalPopUp()  
        {  
            return View();  
        }  


        public IActionResult VisitorIn()
        {
            // visitor registration page (Register Form page)
            return View();
        }

        public RedirectToRouteResult SignIn()
        {
            // visitor registration data save to database
            // and redirect to SignIn Success page

            return RedirectToRoute(new { action = "VisitorSignInSuccess", controller = "Home", area="" });
        }

        public IActionResult VisitorSignInSuccess()
        {
            // visitor SignIn Success
            return View();
        }

        public IActionResult VisitorOut()
        {
            // visitor out page
            return View();
        }

        public RedirectToRouteResult CheckOut()
        {
            // check out function from visitor out page
            // when check out process is completed page need to redirect to Home Index

            return RedirectToRoute(new { action = "Index", controller = "Home", area="" });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
