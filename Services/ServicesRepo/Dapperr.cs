using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using eVisitor_mvcnet5.Common;
using eVisitor_mvcnet5.Service.IServices;
using Microsoft.Data.SqlClient;
//using Microsoft.Extensions.Configuration;

namespace eVisitor_mvcnet5.Service.ServicesRepo
{
    public class Dapperr : IDapper
    {

        /* private readonly IConfiguration _config;  
        private string Connectionstring = "DBDefaultConnection2";  
  
        public  Dapperr(IConfiguration config)  
        {  
            _config = config;  
        }   */
        

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        // link from IDapper
        /* public DbConnection GetDbconnection()  
        {  
            return new SqlConnection(_config.GetConnectionString(Connectionstring));  
        }   */

        public int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new System.NotImplementedException();
        }

        public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            //throw new System.NotImplementedException();
            //using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            using IDbConnection db = new SqlConnection(Global.ConnectionString);  
            return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();  
        }

        public List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            //throw new System.NotImplementedException();
            //using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));  
            using IDbConnection db = new SqlConnection(Global.ConnectionString);  
            return db.Query<T>(sp, parms, commandType: commandType).ToList();
        }

        public T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            //throw new System.NotImplementedException();
            T result;  
            //using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));  
            using IDbConnection db = new SqlConnection(Global.ConnectionString);  
            try  
            {  
                if (db.State == ConnectionState.Closed)  
                    db.Open();  
  
                using var tran = db.BeginTransaction();  
                try  
                {  
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();  
                    tran.Commit();  
                }  
                catch (Exception ex)  
                {  
                    tran.Rollback();  
                    throw new Exception ("Put more context here", ex);  
                }  
            }  
            catch (Exception ex)  
            {  
                throw new Exception ("Put more context here", ex);
            }  
            finally  
            {  
                if (db.State == ConnectionState.Open)  
                    db.Close();  
            }  
  
            return result;  
            
        }

        public T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            //throw new System.NotImplementedException();
            T result;  
            //using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));  
            using IDbConnection db = new SqlConnection(Global.ConnectionString);  
            try  
            {  
                if (db.State == ConnectionState.Closed)  
                    db.Open();  
  
                using var tran = db.BeginTransaction();  
                try  
                {  
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();  
                    tran.Commit();  
                }  
                catch (Exception ex)  
                {  
                    tran.Rollback();  
                    throw new Exception ("Put more context here", ex);
                }  
            }  
            catch (Exception ex)  
            {  
                throw new Exception ("Put more context here", ex);
            }  
            {  
                if (db.State == ConnectionState.Open)  
                   db.Close();  
            }  
  
            return result;

        }
    }
}