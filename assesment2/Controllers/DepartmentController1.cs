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
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ListDepartment", con);
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

        [HttpGet]
        public ActionResult CreateDepartment()
        {
            return View(new Department());
        }


        [HttpPost]
       
        public ActionResult CreateDepartment(Department dept)
        {
            DataTable dt = new DataTable();
            using (con)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_CreateDepartment", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    //cmd.Parameters.AddWithValue("@Empid", ed.Empid);
                    // cmd.Parameters.AddWithValue("@Deptid", dept.Deptid);
                    cmd.Parameters.AddWithValue("@DeptName", dept.DeptName);



                    cmd.ExecuteNonQuery();
                    sda.Fill(dt);
                }
                catch (Exception e)
                {
                    Console.WriteLine(  e.Message);

                }

            }
            return RedirectToAction("ListDepartment");
        }

    
        //public ActionResult EditDept(int id)
        //{
        //    return View(  new Department ());
        //}


        [HttpGet]
     
        public ActionResult EditDept(Department d)
        {
            using (con)
            {

                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_EDITDEPT", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    //cmd.Parameters.AddWithValue("@Empid", ed.Empid);
                    cmd.Parameters.AddWithValue("@Deptid", d.Deptid);
                    cmd.Parameters.AddWithValue("@DeptName", d.DeptName);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine( e.Message);

                }


               
            }
            return RedirectToAction("ListDepartment");
        }
    

        //// GET: DepartmentController1/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: DepartmentController1/Delete/5
        [HttpGet]
        public ActionResult DeleteDepartment(int id)
        {
            using (con)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_DeleteDept", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@Deptid", id);
                    cmd.ExecuteNonQuery();
                }
                catch(Exception e)
                {
                    Console.WriteLine("cannot delete dept" +e.Message);

                }
            }

            return RedirectToAction("ListDepartment");
        }
    }
}
