using System.Collections.Generic;
using eVisitor_mvcnet5.Models;
using eVisitor_mvcnet5.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace eVisitor_mvcnet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentService _oStudentService;

        public StudentsController(IStudentService oStudentService)
        {
            _oStudentService = oStudentService;
        }

        // https://localhost:5001/api/students
        // GET: /students
        [HttpGet]
        public IEnumerable<m_cls_Student_D> Get()
        {                      
            return _oStudentService.Gets();
        }

        // https://localhost:5001/api/students/2
        // GET: /students/5
        [HttpGet("{id}", Name = "Get")]
        public m_cls_Student_D Get(int id)
        {                      
            return _oStudentService.Get(id);
        }

        // https://localhost:5001/api/students
        // POST: /students
        [HttpPost]
        public m_cls_Student_D Post([FromBody] m_cls_Student_D oStudent)
        {          
            if(ModelState.IsValid) return _oStudentService.Save(oStudent);
            return null;
            
        }

        // PUT: /students



        // DELETE: /students/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {                      
            return _oStudentService.Delete(id);
        }

        //
    }

    
}