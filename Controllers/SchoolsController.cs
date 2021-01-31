using eVisitor_mvcnet5.Models;
using eVisitor_mvcnet5.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace eVisitor_mvcnet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private ISchoolService _oSchoolService;

        public SchoolsController(ISchoolService oSchoolService)
        {
            _oSchoolService = oSchoolService;
        }
        
        // https://localhost:5001/api/schools
        // GET: api/schools
        [HttpGet]
        public object Get()
        {
            return _oSchoolService.Gets();
        }

        // https://localhost:5001/api/schools/6/4
        // GET: api/schools/5/2
        [HttpGet("{studentId}/{teacherId}", Name="GetSchool")]
        public object Get( int studentId, int teacherId)
        {
            return _oSchoolService.Get(studentId, teacherId);
        }

        // https://localhost:5001/api/schools
        // POST: api/schools
        [HttpPost]
        public object Post([FromBody] m_cls_School_D oSchool)
        {          
            if(ModelState.IsValid) return _oSchoolService.Save(oSchool.Student, oSchool.Teacher);
            return null;
            
            /* {
                "Student": {
                        "studentId": 0,
                        "studentName": "NewStudentName 6",
                        "roll": "1006"
                    },
                "Teacher": {
                    "teacherId": 0,
                    "fullName": "New Teacher 6",
                    "subjectName": "Bio"
                }
            } */

        }

        //
        // PUT: api/schools

        // https://localhost:5001/api/schools/0/3
        // DELETE: api/api/schools/6/4
        [HttpDelete("{studentId}/{teacherId}")]
        public string Delete( int studentId, int teacherId)
        {                      
            return _oSchoolService.Delete(studentId, teacherId);
        }


        //
    }
}