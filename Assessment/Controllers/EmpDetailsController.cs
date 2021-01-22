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

        // GET: EmpDetailsController/Details/5
      

        // GET: EmpDetailsController/Create
        public ActionResult CreateEmployeeDetail()
        {
            return View(new EmployeeDetail());
        }

        // POST: EmpDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult CreateEmployeeDetail(EmployeeDetail ed)
        //{
        //    using (con)
        //    {

        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("SP_CreateEmpDetail", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataAdapter sda = new SqlDataAdapter(cmd);
               
        //        cmd.Parameters.AddWithValue("Empid", ed.Empid);
        //        cmd.Parameters.AddWithValue("@DateOfBirth", ed.DateOfBirth);
        //        cmd.Parameters.AddWithValue("@DateOfJoining", ed.DateOfJoining);
        //        cmd.Parameters.AddWithValue("@Designation", ed.Designation);
        //        cmd.Parameters.AddWithValue("@Degree", ed.Degree);
        //        cmd.Parameters.AddWithValue("@PassOutYear", ed.PassOutYear);


        //        cmd.ExecuteNonQuery();
        //    }
        //    return RedirectToAction("ListEmployee");
        //}

        
        
        
        
        
        
        
        
        // GET: EmpDetailsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmpDetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
