using System.Data;
using System.Data.SqlClient;
using SampleProject.Models;
using SampleProject.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace SampleProject.NewFolder
{
    public class UseDB
    {
        SqlConnection con = new SqlConnection("Server = DESKTOP-OK1P17M\\MSSQLSERVERNEW; Database = EmployeeDB; integrated security =True");
        
       
        public DataSet showdata()
        {
            
            
                SqlCommand cmd = new SqlCommand("SP_ListEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                sda.Fill(ds);

                return ds;
            
          
        }
       
        public void Add(Employee emp)
        {
            try 
            {
                SqlCommand cmd = new SqlCommand("SP_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                cmd.Parameters.AddWithValue("@EmpName", emp.EmpName);
                //cmd.Parameters.AddWithValue("@DeptName", dept.DeptName);
                //cmd.Parameters.AddWithValue("DateOfBirth", ed.DateOfBirth);
                //cmd.Parameters.AddWithValue("@DateOFJoining", ed.DateOfBirth);
                //cmd.Parameters.AddWithValue("@Designation", ed.Designation);
                //cmd.Parameters.AddWithValue("@Degree", ed.Degree);
                //cmd.Parameters.AddWithValue("@PassOutYear", ed.PassOutYear);
                //cmd.Parameters.AddWithValue("@BankName", bd.BankName);
                //cmd.Parameters.AddWithValue("@AccountNo", bd.AccountNo);
                //cmd.Parameters.AddWithValue("@BasicSalary", bd.BasicSalary);
                //cmd.Parameters.AddWithValue("@HRA", bd.HRA);
                //cmd.Parameters.AddWithValue("@OtherAllowances", bd.OtherAllowances);
                //cmd.Parameters.AddWithValue("@PF", bd.PF);
                //cmd.Parameters.AddWithValue("@MedicalPremium", bd.MedicalPremium);
                //cmd.Parameters.AddWithValue("@TDS", bd.TDS);
                //cmd.Parameters.AddWithValue("@NetSalary", bd.NetSalary);
                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();
            }


            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }















       


        //public void Update(Employee emp)
        //{
        //    SqlCommand cmd = new SqlCommand("SP_Update", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter sda = new SqlDataAdapter(cmd);

        //  //  cmd.Parameters.AddWithValue("@EmpName", emp.Empid);
        //    cmd.Parameters.AddWithValue("@EmpName", emp.EmpName);
            //cmd.Parameters.AddWithValue("@DeptName", dept.DeptName);
            //cmd.Parameters.AddWithValue("DateOfBirth", ed.DateOfBirth);
            //cmd.Parameters.AddWithValue("@DateOFJoining", ed.DateOfBirth);
            //cmd.Parameters.AddWithValue("@Designation", ed.Designation);
            //cmd.Parameters.AddWithValue("@Degree", ed.Degree);
            //cmd.Parameters.AddWithValue("@PassOutYear", ed.PassOutYear);
            //cmd.Parameters.AddWithValue("@BankName", bd.BankName);
            //cmd.Parameters.AddWithValue("@AccountNo", bd.AccountNo);
            //cmd.Parameters.AddWithValue("@BasicSalary", bd.BasicSalary);
            //cmd.Parameters.AddWithValue("@HRA", bd.HRA);
            //cmd.Parameters.AddWithValue("@OtherAllowances", bd.OtherAllowances);
            //cmd.Parameters.AddWithValue("@PF", bd.PF);
            //cmd.Parameters.AddWithValue("@MedicalPremium", bd.MedicalPremium);
            //cmd.Parameters.AddWithValue("@TDS", bd.TDS);
            //cmd.Parameters.AddWithValue("@NetSalary", bd.NetSalary);
            //con.Open();
            //cmd.ExecuteNonQuery();

            //con.Close();














        //}






    }

}