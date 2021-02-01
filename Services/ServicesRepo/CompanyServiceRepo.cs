using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using eVisitor_mvcnet5.Common;
using eVisitor_mvcnet5.Models;
using eVisitor_mvcnet5.Service.IServices;
using Microsoft.Data.SqlClient;

namespace eVisitor_mvcnet5.Service.ServicesRepo
{
    public class CompanyServiceRepo : ICompanyService
    {
        // for Depper
        private IDbConnection db;

        public CompanyServiceRepo()
        {
            //
            this.db = new SqlConnection(Global.ConnectionString);
        }


        public m_cls_Company_D Add(m_cls_Company_D company)
        {
            //
            var sql = "INSERT INTO tbl_Company_D (CompanyName,Address,[Status]) VALUES (@CompanyName,@Address,@Status);"
                        + "SELECT CAST(SCOPE_IDENTITY() as int);";

            /* var id = db.Query<int>(sql,new{
                @CompanyName = company.CompanyName,
                @Address = company.Address,
                @Status = company.Status
            }).Single(); */
            var id = db.Query<int>(sql,new{
                company.CompanyName,
                company.Address,
                company.Status
            }).Single();
            company.CompanyId = id;
            return company;


        }

        public m_cls_Company_D Find(int id)
        {
            //
            var sql = "SELECT * FROM tbl_Company_D WHERE CompanyId = @CompanyId";
            return db.Query<m_cls_Company_D>(sql, new {@CompanyId = id}).Single();

        }

        public List<m_cls_Company_D> GetAll()
        {
            //
            var sql = "SELECT * FROM tbl_Company_D";
            return db.Query<m_cls_Company_D>(sql).ToList();
        }

        public void Remove(int id)
        {
            //
            var sql ="DELETE FROM tbl_Company_D WHERE CompanyId = @id";
            db.Execute(sql, new {id});

        }

        public m_cls_Company_D Update(m_cls_Company_D company)
        {
            //
            var sql = "UPDATE tbl_Company_D SET CompanyName = @CompanyName, Address = @Address, [Status] = @Status "
                        + "WHERE CompanyId = @CompanyId;";

            db.Execute(sql, company); 
            // parameter and field name are the same, 
            //so can pass company object as parameter

            return company;
        }


        //
    }

}