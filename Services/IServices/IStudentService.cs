using System.Collections.Generic;
using eVisitor_mvcnet5.Models;

namespace eVisitor_mvcnet5.Service.IServices
{
    public interface IStudentService
    {
        m_cls_Student_D Save (m_cls_Student_D oStudent);

        List<m_cls_Student_D> Gets();

        m_cls_Student_D Get(int studentId);

        string Delete(int studentId);
        
    }

}