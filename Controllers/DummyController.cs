using System.Data;
using System.Threading.Tasks;
using eVisitor_mvcnet5.Models;
using eVisitor_mvcnet5.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace eVisitor_mvcnet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DummyController : ControllerBase
    {
        private readonly IDapper _dapper;  
        public DummyController(IDapper dapper)  
        {  
            _dapper = dapper;  
        }  

        // https://localhost:5001/api/dummy/GetById?Id=7
        [HttpGet(nameof(GetById))]  
        public async Task<m_cls_Dummy> GetById(int Id)  
        {  
            var result = await Task.FromResult(_dapper.Get<m_cls_Dummy>($"Select * from [tbl_Dummy] where Id = {Id}", null, commandType: CommandType.Text));  
            return result;  
        }  




        //
    }
}