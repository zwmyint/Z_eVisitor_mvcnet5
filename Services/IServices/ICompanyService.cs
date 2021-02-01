using System.Collections.Generic;
using eVisitor_mvcnet5.Models;

namespace eVisitor_mvcnet5.Service.IServices
{
    public interface ICompanyService  
    {    
        m_cls_Company_D Find(int id);

        List<m_cls_Company_D> GetAll();

        m_cls_Company_D Add(m_cls_Company_D company);

        m_cls_Company_D Update(m_cls_Company_D company);

        void Remove(int id);
    }    

}