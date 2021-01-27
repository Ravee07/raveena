using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Controllers
{
    public class EmpDetailsController : Controller
    {
        // GET: EmpDetailsController

        SqlConnection con = new SqlConnection("Server = DESKTOP-OK1P17M\\MSSQLSERVERNEW; Database = EmployeeDB; integrated security =True");

        public ActionResult ListEmployeeDetails()
        {
            DataTable dt = new DataTable();
            using (con)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_ListEmployeeDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

            }
            return View(dt);
        }
        [HttpGet]
        //public ActionResult ParticularEmp(int id)
        //{
        //    DataTable dt = new DataTable();
        //    using (con)
        //    {
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("Particular", con);
        //        cmd.Parameters.AddWithValue("Empid", id);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //        sda.Fill(dt);

        //    }
        //    return View();
        //}


        //public ActionResult NETSAL()
        //{
        //    using (con)
        //    {

        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("SP_CreateEmpDetail", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataAdapter sda = new SqlDataAdapter(cmd);



        //        return View();
        // }



        // GET: EmpDetailsController/Details/5


        // GET: EmpDetailsController/Create
        public ActionResult CreateEmployeeDetail()
        {
            return View(new EmployeeDetail());
        }

        // POST: EmpDetailsController/Create
        [HttpPost]

        public ActionResult CreateEmployeeDetail(EmployeeDetail ed)
        {
            DataTable dt = new DataTable();
            using (con)
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SP_CreateEmpDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                cmd.Parameters.AddWithValue("Empid", ed.Empid);
                cmd.Parameters.AddWithValue("@DateOfBirth", ed.DateOfBirth);
                cmd.Parameters.AddWithValue("@DateOfJoining", ed.DateOfJoining);
                cmd.Parameters.AddWithValue("@Designation", ed.Designation);
                cmd.Parameters.AddWithValue("@Degree", ed.Degree);
                cmd.Parameters.AddWithValue("@PassOutYear", ed.PassOutYear);
               

                cmd.ExecuteNonQuery();
                sda.Fill(dt);

            }
            return RedirectToAction("ListEmployeeDetails");
        }









       
        public ActionResult EditEMpDetail(int id)
        {
            return View(new EmployeeDetail());
        }

        // POST: EmpDetailsController/Edit/5
        [HttpPost]
      
        public ActionResult EditEmpDetail(EmployeeDetail ed)
        {
            DataTable dt = new DataTable();
            using (con)
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SP_EditEmpDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                cmd.Parameters.AddWithValue("Empid", ed.Empid);
                cmd.Parameters.AddWithValue("@DateOfBirth", ed.DateOfBirth);
                cmd.Parameters.AddWithValue("@DateOfJoining", ed.DateOfJoining);
                cmd.Parameters.AddWithValue("@Designation", ed.Designation);
                cmd.Parameters.AddWithValue("@Degree", ed.Degree);
                cmd.Parameters.AddWithValue("@PassOutYear", ed.PassOutYear);

               
                cmd.ExecuteNonQuery();
                sda.Fill(dt);
            }
            return RedirectToAction("ListEmployeeDetails");
        }

        // GET: EmpDetailsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmpDetailsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
