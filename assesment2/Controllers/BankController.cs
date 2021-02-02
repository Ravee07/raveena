using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SampleProject.Models;
using SampleProject.Controllers;


namespace SampleProject.Controllers
{
    public class BankController : Controller
    {
        SqlConnection con = new SqlConnection("Server = DESKTOP-OK1P17M\\MSSQLSERVERNEW; Database = EmployeeDB; integrated security =True");
        [HttpGet]
        public ActionResult ListBankDetails()
        {
            DataTable dt = new DataTable();

            using (con)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ShowBankDetails", con);


                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sda = cmd.ExecuteReader();
                    dt.Load(sda);
                    //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    //sda.Fill(dt);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }

            }
            return View(dt);
        }



        public ActionResult CreateBankDetails()
        {
            return View(new BankDetail());
        }

        // POST: BankController/Create
        [HttpPost]

        public ActionResult CreateBankDetails(BankDetail bd)
        {
            DataTable dt = new DataTable();
            using (con)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_InsertBankDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@Empid", bd.Empid);
                    // cmd.Parameters.AddWithValue("@EmpName", emp.EmpName);
                    //cmd.Parameters.AddWithValue("@DeptName", dept.DeptName);
                    cmd.Parameters.AddWithValue("@BankName", bd.BankName);
                    cmd.Parameters.AddWithValue("@AccountNo", bd.AccountNo);
                    cmd.Parameters.AddWithValue("@BasicSalary", bd.BasicSalary);
                    cmd.Parameters.AddWithValue("@HRA", bd.HRA);
                    cmd.Parameters.AddWithValue("@OtherAllowances", bd.OtherAllowances);


                    //SqlCommand cmd =new SqlCommand()
                    //  cmd.Parameters.AddWithValue("@GrossSalary", bd);

                    cmd.Parameters.AddWithValue("@PF", bd.PF);
                    cmd.Parameters.AddWithValue("@MedicalPremium", bd.MedicalPremium);
                    cmd.Parameters.AddWithValue("@TDS", bd.TDS);
                    //cmd.Parameters.AddWithValue("@NetSalary", bd.NetSalary);
                    cmd.ExecuteNonQuery();
                    sda.Fill(dt);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
            }
            return RedirectToAction("ListBankDetails");
        }






       








    //[HttpGet]
    //    public ActionResult EditBank(int id)
    //    {
    //        return View(new BankDetail());
    //    }

      
        [HttpPost]
   
        public ActionResult EditBank(BankDetail bd)
        {
            using (con)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_EDITBANK", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@Empid", bd.Empid);
                    // cmd.Parameters.AddWithValue("@EmpName", emp.EmpName);
                    //cmd.Parameters.AddWithValue("@DeptName", dept.DeptName);
                    cmd.Parameters.AddWithValue("@BankName", bd.BankName);
                    cmd.Parameters.AddWithValue("@AccountNo", bd.AccountNo);
                    cmd.Parameters.AddWithValue("@BasicSalary", bd.BasicSalary);
                    cmd.Parameters.AddWithValue("@HRA", bd.HRA);
                    cmd.Parameters.AddWithValue("@OtherAllowances", bd.OtherAllowances);
                    //cmd.Parameters.AddWithValue("@GrossSalary", bd);


                    cmd.Parameters.AddWithValue("@PF", bd.PF);
                    cmd.Parameters.AddWithValue("@MedicalPremium", bd.MedicalPremium);
                    cmd.Parameters.AddWithValue("@TDS", bd.TDS);
                    //cmd.Parameters.AddWithValue("@NetSalary", bd.NetSalary);

                    //bd.Gross();



                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
            }
            return RedirectToAction("ListBankDetails");
        }
        //[HttpGet]
        // public ActionResult DeleteBank()
        // {
        //     return View(new BankDetail());


        // }

        [HttpGet]

        public ActionResult DeleteBank(int id)
        {
            using (con)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_Delete_Bank", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@Bankid", id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }

            }

            return RedirectToAction("ListBankDetails");
        }


        public ActionResult ShowNetSalary(int id)
        {
            DataTable dt = new DataTable();

            using (con)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("ShowNetSal", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@Empid", id);
                    sda.Fill(dt);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }

            }
            return View(dt);
        }


        public ActionResult ShowGrossSalary(int id)
        {
            DataTable dt = new DataTable();

            using (con)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("ShowGross", con);


                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@Empid", id);
                    sda.Fill(dt);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }

            }
            return View(dt);
        }



    }
}

