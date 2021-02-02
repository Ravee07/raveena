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
       [HttpGet]
        public ActionResult ListEmployee()
        {
            DataTable dt = new DataTable();
            using (con) 
            
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_listEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sda = cmd.ExecuteReader();
                    dt.Load(sda);
                    //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    // cmd.ExecuteNonQuery(); y();


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }

            }
            return View(dt);
        }

        [HttpGet]
        public ActionResult Create()
         {
      
        return View(new Employee());
        }

       
           [HttpPost]

        public ActionResult Create(Employee emp)
        {
            DataTable dt = new DataTable();
            using (con)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_InsertEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    //cmd.Parameters.AddWithValue("@Empid", ed.Empid);
                    cmd.Parameters.AddWithValue("@Deptid", emp.Deptid);
                    cmd.Parameters.AddWithValue("@EmpName", emp.EmpName);



                    cmd.ExecuteNonQuery();
                    sda.Fill(dt);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
            }
            return RedirectToAction("ListEmployee");
        }

      



        [HttpGet]
        public ActionResult EditEmployee( int id)
        { Employee e = new Employee();
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EMP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand.Parameters.AddWithValue("@Empid", id);
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {



                    e.Empid = Convert.ToInt32(dt.Rows[0][0]);
                    e.EmpName = dt.Rows[0][1].ToString();
                    e.Deptid = Convert.ToInt32(dt.Rows[0][2]);


                    //return View(EditEmployee(Empid, EmpName, Depid));
                    return View(e);
                }
                else
                {

                    return RedirectToAction("EditEmployee");
                }
            }

            catch (SqlException se)
            {
                return View();
            }
        }


        [HttpPost]

        public ActionResult EditEmployee(Employee e)
        {
            DataTable dt = new DataTable();
            using (con)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_EDITEMP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@Empid", e.Empid);

                    cmd.Parameters.AddWithValue("@EmpName",e.EmpName);
                    cmd.Parameters.AddWithValue("@Deptid", e.Deptid);



                    cmd.ExecuteNonQuery();
                    sda.Fill(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }

                return RedirectToAction("ListEmployee");
            }
        
            }





       

        [HttpGet]
        public ActionResult DeleteEmployee(int id)
        {
            using (con)
            {
                try
                {   
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_DeleteEmp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@Empid", id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }

            }

            return RedirectToAction("ListEmployee");
        }
    }
}
