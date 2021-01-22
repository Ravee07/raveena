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
    public class DepartmentController1 : Controller
    {
        SqlConnection con = new SqlConnection("Server = DESKTOP-OK1P17M\\MSSQLSERVERNEW; Database = EmployeeDB; integrated security =True");
       
        public ActionResult ListDepartment()
        {
            DataTable dt = new DataTable();
            using (con)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_ListDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

            }
            return View(dt);
            
        }

       
        public ActionResult CreateDepartment()
        {
            return View(new Department());
        }

      
        [HttpPost]
       
        public ActionResult CreateDepartment(Department dept)
        {
            using (con)
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SP_CreateDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //cmd.Parameters.AddWithValue("@Empid", ed.Empid);
               // cmd.Parameters.AddWithValue("@Deptid", dept.Deptid);
                cmd.Parameters.AddWithValue("@DeptName", dept.DeptName);



                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("ListDepartment");
        }

        // GET: DepartmentController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepartmentController1/Edit/5
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

        // GET: DepartmentController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepartmentController1/Delete/5
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
