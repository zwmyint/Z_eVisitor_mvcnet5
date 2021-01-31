using eVisitor_mvcnet5.Models;

namespace eVisitor_mvcnet5.Service.IServices
{
    public interface ISchoolService
    {
        object Save(m_cls_Student_D oStudent, m_cls_Teacher_D oTeacher);

        object Gets();

        object Get(int studentId, int teacherId);

        string Delete(int studentId, int teacherId);

        
    }

}