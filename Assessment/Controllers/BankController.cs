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
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_ShowBankDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

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
                //  cmd.Parameters.AddWithValue("@GrossSalary", bd);

                cmd.Parameters.AddWithValue("@PF", bd.PF);
                cmd.Parameters.AddWithValue("@MedicalPremium", bd.MedicalPremium);
                cmd.Parameters.AddWithValue("@TDS", bd.TDS);
                //cmd.Parameters.AddWithValue("@NetSalary", bd.NetSalary);

                //bd.Gross();



                cmd.ExecuteNonQuery();
                sda.Fill(dt);
            }
            return RedirectToAction("ListBankDetails");
        }






        public ActionResult Gross()
        {
            DataTable ds = new DataTable();
            SqlCommand cmd = new SqlCommand("CAl_GrossSalary", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            //cmd.Parameters.AddWithValue("@Empid", e.Empid);
            // cmd.Parameters.AddWithValue("@Empid", e.GrossSalary);
            return View();
        }









        public ActionResult EditBank(int id)
        {
            return View(new BankDetail());
        }

        // POST: BankController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBank(BankDetail bd)
        {
            using (con)
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
                //  cmd.Parameters.AddWithValue("@GrossSalary", bd);

                cmd.Parameters.AddWithValue("@PF", bd.PF);
                cmd.Parameters.AddWithValue("@MedicalPremium", bd.MedicalPremium);
                cmd.Parameters.AddWithValue("@TDS", bd.TDS);
                //cmd.Parameters.AddWithValue("@NetSalary", bd.NetSalary);

                //bd.Gross();



                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("ListBankDetails");
        }
       [HttpGet]
        public ActionResult DeleteBank()
        {
            return View("DeleteBank");


        }

        [HttpPost]

        public ActionResult DeleteBank(BankDetail bd)
        {
            using (con)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_Delete_Bank", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@Empid", bd.Empid);
                // return RedirectToAction("ListBankDetails");
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("ListBankDetails");
        }
    }
}

