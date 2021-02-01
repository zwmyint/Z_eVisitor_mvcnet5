using System.Data;
using System.Threading.Tasks;
using Dapper;
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

        // 
        [HttpPost(nameof(Create))]  
        public async Task<int> Create(m_cls_Dummy data)  
        {  
            var dbparams = new DynamicParameters();  
            dbparams.Add("Id", data.Id, DbType.Int32);  
            var result = await Task.FromResult(_dapper.Insert<int>("[dbo].[SP_Add_Article]"  
                , dbparams,  
                commandType: CommandType.StoredProcedure));  
            return result;  
        }  

        // 
        [HttpPatch(nameof(Update))]  
        public Task<int> Update(m_cls_Dummy data)  
        {  
            var dbPara = new DynamicParameters();  
            dbPara.Add("Id", data.Id);  
            dbPara.Add("Name", data.Name, DbType.String);  
  
            var updateArticle = Task.FromResult(_dapper.Update<int>("[dbo].[SP_Update_Article]",  
                            dbPara,  
                            commandType: CommandType.StoredProcedure));  
            return updateArticle;  
        }  

        // 
        [HttpDelete(nameof(Delete))]  
        public async Task<int> Delete(int Id)  
        {  
            var result = await Task.FromResult(_dapper.Execute($"Delete [tbl_Dummy] Where Id = {Id}", null, commandType: CommandType.Text));  
            return result;  
        }  

        // https://localhost:5001/api/dummy/GetById?Id=7
        [HttpGet(nameof(GetById))]  
        public async Task<m_cls_Dummy> GetById(int Id)  
        {  
            var result = await Task.FromResult(_dapper.Get<m_cls_Dummy>($"Select * from [tbl_Dummy] where Id = {Id}", null, commandType: CommandType.Text));  
            return result;  
        }  

        // 
        [HttpGet(nameof(Count))]  
        public Task<int> Count(int num)  
        {  
            var totalcount = Task.FromResult(_dapper.Get<int>($"select COUNT(*) from [tbl_Dummy] WHERE Age like '%{num}%'", null,  
                    commandType: CommandType.Text));  
            return totalcount;  
        }  


        //
    }
}