using System;
using System.Data;
using System.Dynamic;
using System.Linq;
using Dapper;
using eVisitor_mvcnet5.Common;
using eVisitor_mvcnet5.Models;
using eVisitor_mvcnet5.Service.IServices;
using Microsoft.Data.SqlClient;

namespace eVisitor_mvcnet5.Service.ServicesRepo
{
    public class SchoolServiceRepo : ISchoolService
    {
        //
        public string Delete(int studentId, int teacherId)
        {
            //throw new System.NotImplementedException();
            try
            {
                using(IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if(con.State == ConnectionState.Closed) con.Open();

                    string query =@"DELETE FROM tbl_Student_D WHERE StudentId = " + studentId + ";" +
                                    "DELETE FROM tbl_Teacher_D WHERE TeacherId = " + teacherId;
                    
                    con.QueryMultiple(query);

                    return "Deleted ...";

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }

        public object Get(int studentId, int teacherId)
        {
            //throw new System.NotImplementedException();
            dynamic obj = new ExpandoObject();
            using(IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if(con.State == ConnectionState.Closed) con.Open();

                string query =@"SELECT * FROM tbl_Student_D WHERE StudentId = " + studentId + ";" +
                                "SELECT * FROM tbl_Teacher_D WHERE TeacherId = " + teacherId;
                
                using( var multi = con.QueryMultiple(query, null))
                {
                    obj.Student = multi.Read<m_cls_Student_D>().Single();
                    obj.Teacher = multi.Read<m_cls_Teacher_D>().Single();
                }

                return obj;

            }

        }

        public object Gets()
        {
            //throw new System.NotImplementedException();
            dynamic obj = new ExpandoObject();
            using(IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if(con.State == ConnectionState.Closed) con.Open();

                string query =@"SELECT * FROM tbl_Student_D;
                                SELECT * FROM tbl_Teacher_D";
                
                using( var multi = con.QueryMultiple(query, null))
                {
                    obj.Students = multi.Read<m_cls_Student_D>().ToList();
                    obj.Teachers = multi.Read<m_cls_Teacher_D>().ToList();
                }

                return obj;

            }

        }

        public object Save(m_cls_Student_D oStudent, m_cls_Teacher_D oTeacher)
        {
            //throw new System.NotImplementedException();
            dynamic obj = new ExpandoObject();
            try
            {
                int operationType = 0;
                
                using(IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if(con.State == ConnectionState.Closed) con.Open();

                    string query =@"EXEC sp_Student @StudentId, @StudentName, @Roll, @OperationType; " +
                                    "EXEC sp_Teacher @TeacherId, @FullName, @SubjectName";
                    
                    using( var multi = con.QueryMultiple(query, new {
                        oStudent.StudentId,
                        oStudent.StudentName,
                        oStudent.Roll,
                        operationType,
                        oTeacher.TeacherId,
                        oTeacher.FullName,
                        oTeacher.SubjectName
                    }))
                    {
                        obj.Student = multi.Read<m_cls_Student_D>().Single();
                        obj.Teacher = multi.Read<m_cls_Teacher_D>().Single();
                    }

                }

            }
            catch (Exception ex)
            {
                obj.Message = ex.Message;
            }

            return obj;

        }

        //
    }

}