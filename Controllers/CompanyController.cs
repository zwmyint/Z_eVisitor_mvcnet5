using eVisitor_mvcnet5.Models;
using eVisitor_mvcnet5.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace eVisitor_mvcnet5.Controllers
{
    public class CompanyController : Controller
    {

        // link to ServiceRepo using Interface
        private readonly ICompanyService _companydb;

        public CompanyController(ICompanyService companydb)
        {
            _companydb = companydb;
        }

        //
        // GET: Companies
        public IActionResult Index()
        {
            return View(_companydb.GetAll());
        }

        //
        // GET: Companies/Details/5
        public IActionResult Details(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }

            var company = _companydb.Find(id.GetValueOrDefault());
            if(company ==null)
            {
                return NotFound();
            }

            return View(company);

        }

        //
        public IActionResult Create()
        {
            return View();
        }

        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CompanyId,CompanyName,Address,Status")] m_cls_Company_D company)
        {
            if(ModelState.IsValid)
            {
                _companydb.Add(company);
                return RedirectToAction(nameof(Index));
            }

            return View(company);
        }

        //
        // GET: Companies/Edit/5
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var company = _companydb.Find(id.GetValueOrDefault());
            if(company ==null)
            {
                return NotFound();
            }

            return View(company);

        }

        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CompanyId,CompanyName,Address,Status")] m_cls_Company_D company)
        {
            if(id != company.CompanyId)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                _companydb.Update(company);
                return RedirectToAction(nameof(Index));
            }

            return View(company);
        }

        //
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            _companydb.Remove(id.GetValueOrDefault());
            return RedirectToAction(nameof(Index));

        }


        //
    }

}