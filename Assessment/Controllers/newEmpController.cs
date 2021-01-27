using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SampleProject.Models;
namespace SampleProject.Controllers
{
    public class newEmpController : Controller
    {
        SqlConnection con = new SqlConnection("Server = DESKTOP-OK1P17M\\MSSQLSERVERNEW; Database = EmployeeDB; integrated security =True");
        // GET: newEmpController
        [HttpGet]
        public ActionResult ListEmployee()
        {
            DataTable dt = new DataTable();
            using (con) {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_listEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

            }
            return View(dt);
        }


        public ActionResult Create()
        {
            return View(new Employee());
        }

       
       [HttpPost]

        public ActionResult Create(Employee emp, Department dept)
        {
            DataTable dt = new DataTable();
            using (con)
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SP_InsertEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //cmd.Parameters.AddWithValue("@Empid", ed.Empid);
                cmd.Parameters.AddWithValue("@Deptid", dept.Deptid);
                cmd.Parameters.AddWithValue("@EmpName", emp.EmpName);

    
              
                cmd.ExecuteNonQuery();
                sda.Fill(dt);
            }
            return RedirectToAction("ListEmployee");
        }

        //public ActionResult select()
        //{ }




        [HttpGet]
        public ActionResult EditEmployee()
        {
            return View(new Employee());
        }


            [HttpPost]

            public ActionResult EditEmployee(Employee e)
        {
            DataTable dt = new DataTable();
            using (con)
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_EDITEMP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                   
                    cmd.Parameters.AddWithValue("@Deptid", e.Deptid);
                    cmd.Parameters.AddWithValue("@EmpName", e.EmpName);

            

                    cmd.ExecuteNonQuery();
                sda.Fill(dt);
            }
                return RedirectToAction("ListEmployee");
            }


            //// GET: newEmpController/Delete/5
            //public ActionResult Delete(int id)
            //{
            //    return View();
            //}

            //// POST: newEmpController/Delete/5
            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public ActionResult Delete(int id, IFormCollection collection)
            //{
            //    try
            //    {
            //        return RedirectToAction(nameof(Index));
            //    }
            //    catch
            //    {
            //        return View();
            //    }

            // }
        

    }
}
