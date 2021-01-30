using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eVisitor_mvcnet5.Helpers;
using eVisitor_mvcnet5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static eVisitor_mvcnet5.Helpers.nodirectaccHelper;

namespace eVisitor_mvcnet5.Controllers
{
    public class TransactionController : Controller
    {

        private AppDbContext2 _context;

        public TransactionController(AppDbContext2 ctx)
        {
            _context = ctx;
        }

        public IActionResult Index(string id)
        {   
            //
            List <m_cls_Transaction> model = _context.tbl_Transactions.ToList();
            return View(model);
        }

        // GET: Transaction/AddOrEdit(Insert)
        // GET: Transaction/AddOrEdit/5(Update)
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new m_cls_Transaction());
            else
            {
                var transactionModel = await _context.tbl_Transactions.FindAsync(id);
                if (transactionModel == null)
                {
                    return NotFound();
                }
                return View(transactionModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("TransactionId,AccountNumber,BeneficiaryName,BankName,SWIFTCode,TranAmount,TranDate")] m_cls_Transaction transactionModel)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    transactionModel.TranDate = DateTime.Now;
                    _context.Add(transactionModel);
                    await _context.SaveChangesAsync();

                }
                //Update
                else
                {
                    try
                    {
                        _context.Update(transactionModel);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TransactionModelExists(transactionModel.TransactionId))
                            { return NotFound(); }
                        else
                            { throw; }
                    }
                }

                return Json(new { isValid = true, html = htmlstringHelper.RenderRazorViewToString(this, "_ViewAll", _context.tbl_Transactions.ToList()) });
            
            }

            return Json(new { isValid = false, html = htmlstringHelper.RenderRazorViewToString(this, "AddOrEdit", transactionModel) });
        
        }


        // GET: Transaction/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionModel = await _context.tbl_Transactions
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transactionModel == null)
            {
                return NotFound();
            }

            return View(transactionModel);
        }

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transactionModel = await _context.tbl_Transactions.FindAsync(id);
            _context.tbl_Transactions.Remove(transactionModel);
            await _context.SaveChangesAsync();
            return Json(new { html = htmlstringHelper.RenderRazorViewToString(this, "_ViewAll", _context.tbl_Transactions.ToList()) });
        }


        private bool TransactionModelExists(int id)
        {
            return _context.tbl_Transactions.Any(e => e.TransactionId == id);
        }
        //
    }

}