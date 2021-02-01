using System.Collections.Generic;
using System.Linq;
using eVisitor_mvcnet5.Models;
using eVisitor_mvcnet5.Service.IServices;

namespace eVisitor_mvcnet5.Service.ServicesRepo
{
    public class CompanyServiceRepoEF : ICompanyService
    {
        // for EF
        private readonly AppDbContext2 _db;
        public CompanyServiceRepoEF(AppDbContext2 db)
        {
            _db = db;
        }


        public m_cls_Company_D Add(m_cls_Company_D company)
        {
            _db.tbl_Company_D.Add(company);
            _db.SaveChanges();
            return company;

        }

        public m_cls_Company_D Find(int id)
        {
            //
            return _db.tbl_Company_D.FirstOrDefault( c => c.CompanyId == id);

        }

        public List<m_cls_Company_D> GetAll()
        {
            //
            return _db.tbl_Company_D.ToList();
        }

        public void Remove(int id)
        {
            //
            m_cls_Company_D company = _db.tbl_Company_D.FirstOrDefault( c => c.CompanyId == id);
            _db.tbl_Company_D.Remove(company);
            _db.SaveChanges();
            return;
        }

        public m_cls_Company_D Update(m_cls_Company_D company)
        {
            //
            _db.tbl_Company_D.Update(company);
            _db.SaveChanges();
            return company;
        }
    }

}