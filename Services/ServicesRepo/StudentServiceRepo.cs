using System;
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
    public class StudentServiceRepo : IStudentService
    {
        //
        m_cls_Student_D _oStudent = new m_cls_Student_D();
        List<m_cls_Student_D> _oStudents = new List<m_cls_Student_D>();


        public string Delete(int studentId)
        {
            //throw new System.NotImplementedException();
            string message ="";
            try
            {
                _oStudent = new m_cls_Student_D()
                {
                    StudentId = studentId
                };

                using(IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if(con.State == ConnectionState.Closed) con.Open();

                    var oStudents = con.Query<m_cls_Student_D>("sp_Student",
                        this.SetParameters(_oStudent, (int)OperationType.Delete),
                        commandType:CommandType.StoredProcedure
                    );

                    if (oStudents != null && oStudents.Count() > 0)
                    {
                        _oStudent = oStudents.FirstOrDefault();
                    }


                }

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return message;
        }

        public m_cls_Student_D Get(int studentId)
        {
            //throw new System.NotImplementedException();
             _oStudent = new m_cls_Student_D();
            using(IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if(con.State == ConnectionState.Closed) con.Open();

                string query = "SELECT * FROM tbl_Student_D WHERE studentId = @studentId";

                var oStudent = con.Query<m_cls_Student_D>(query, new { studentId = studentId}).ToList();

                if (oStudent != null && oStudent.Count() > 0)
                {
                    _oStudent = oStudent.SingleOrDefault();
                }

                return _oStudent;

            }

        }

        public List<m_cls_Student_D> Gets()
        {
            //throw new System.NotImplementedException();
            _oStudents = new List<m_cls_Student_D>();
            using(IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if(con.State == ConnectionState.Closed) con.Open();

                var oStudents = con.Query<m_cls_Student_D>("SELECT * FROM tbl_Student_D").ToList();

                if (oStudents != null && oStudents.Count() > 0)
                {
                    _oStudents = oStudents;
                }

                return _oStudents;

            }

        }

        public m_cls_Student_D Save(m_cls_Student_D oStudent)
        {
            //throw new System.NotImplementedException();
            _oStudent = new m_cls_Student_D();

            try{

                int operationType = Convert.ToInt32(oStudent.StudentId == 0 ? OperationType.Insert : OperationType.Update);
                
                using(IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if(con.State == ConnectionState.Closed) con.Open();

                    var oStudents = con.Query<m_cls_Student_D>("sp_Student",
                        this.SetParameters(oStudent, operationType),
                        commandType:CommandType.StoredProcedure
                    );

                    if (oStudents != null && oStudents.Count() > 0)
                    {
                        _oStudent = oStudents.FirstOrDefault();
                    }


                }


            }
            catch (Exception ex)
            {
                _oStudent.Message = ex.Message;
            }

            return _oStudent;
            
        }

        private DynamicParameters SetParameters(m_cls_Student_D oStudent, int operationType)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@StudentId", oStudent.StudentId);
            parameters.Add("@StudentName", oStudent.StudentName);
            parameters.Add("@Roll", oStudent.Roll);
            parameters.Add("@OperationType", operationType);

            return parameters;
        }


        //
    }

}