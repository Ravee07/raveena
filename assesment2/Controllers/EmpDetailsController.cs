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
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ListEmployeeDetail", con);
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
        public ActionResult CreateEmployeeDetail()
        {
            return View(new EmployeeDetail());
        }

       
        [HttpPost]

        public ActionResult CreateEmployeeDetail(EmployeeDetail ed)
        {
            DataTable dt = new DataTable();
            using (con)
            {
                try
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
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }

            }
            return RedirectToAction("ListEmployeeDetails");
        }








        [HttpGet]
       
        public ActionResult EditEMpDetail(int id)
        {
            return View(new EmployeeDetail());
        }

      
        [HttpPost]
      
        public ActionResult EditEmpDetail(EmployeeDetail ed)
        {
            DataTable dt = new DataTable();
            using (con)
            {
                try
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
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
            }
            return RedirectToAction("ListEmployeeDetails");
        }

       

      
        [HttpGet]
       
        public ActionResult DeleteEmployeeDetails(int id)
        {
            using (con)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_DeleteEmpDetail", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@EmpDetailid", id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }

            }

            return RedirectToAction("ListEmployeeDetails");

        }
      



    }
}
