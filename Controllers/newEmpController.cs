using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SampleProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
                  

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }

            }
            return View(dt);
        }

        //    [HttpGet]
        //    public ActionResult Create()
        //    {

        //        //   // return View(new makeEMP { NEWEMP = new NEWEMP(), Employee = new Employee() });
        //        return View(new NEWEMP());
        //}
        //public ActionResult reg(makeEMP ce)
        //{ return View(new makeEMP { NEWEMP = new NEWEMP(), Employee = new Employee() });

        //}
        [HttpGet]
        public ActionResult Create()
        {
            
            SqlCommand cmd = new SqlCommand("LIST", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();


            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            Employee d = new Employee();
            sda.Fill(ds);
            ViewBag.DeptName = ds.Tables[0];

 

            List<SelectListItem> getDeptName = new List<SelectListItem>();



            foreach (System.Data.DataRow dr in ViewBag.DeptName.Rows)
            {
                getDeptName.Add(new SelectListItem { Text = @dr["DeptName"].ToString(), Value = @dr["DeptName"].ToString() });

                //getDeptName.Add(new SelectListItem { Text = @dr["Deptid"].ToString(), Value = @dr["Deptid"].ToString() });

            }
            ViewBag.Department = getDeptName;
            con.Close();

            

            
            return View(new Employee());
        }

        [HttpPost]

   
        public ActionResult Create(Employee emp)
        {
            DataTable dt = new DataTable();
            Employee d = new Employee();
            //DataSet ds = new DataSet();
           
            using (con)
            {
                try
                {
                    con.Open();
                 
                    SqlCommand cmd = new SqlCommand("SP_InsertEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
           
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                
                    cmd.Parameters.AddWithValue("DeptName", emp.DeptName);
                    cmd.Parameters.AddWithValue("@EmpName", emp.EmpName);

                    cmd.ExecuteNonQuery();
                    sda.Fill(dt);

                    //List<Employee> DeptList = new List<Employee>();
                    //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //{
                    //    Employee dobj = new Employee();
                    //    dobj.Deptid = Convert.ToInt32(ds.Tables[0].Rows[i]["Deptid"].ToString());
                    //    dobj.DeptName = ds.Tables[0].Rows[i]["DeptName"].ToString();
                    //    DeptList.Add(dobj);
                    //}
                    //d.Departments= DeptList;


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
            }
            return View();
        }



        //ViewBag.DeptName = ds.Tables[0];



        //List<SelectListItem> getDeptName = new List<SelectListItem>();



        //foreach (System.Data.DataRow dr in ViewBag.DeptName.Rows)
        //{
        //    getDeptName.Add(new SelectListItem { Text = @dr["DeptName"].ToString(), Value = @dr["DeptName"].ToString() });



        //}
        //ViewBag.Department = getDeptName;
        //con.Close();












        //cmd.Parameters.AddWithValue("@EmpName", c.EmpName);


        //SqlDataAdapter sda = new SqlDataAdapter(cond);
        //sda.Fill(ds);







    //    List<Department> Deptlist = new List<Department>();
    //   // List<NEWEMP> Deptlist = new List<NEWEMP>();


    //    for (int i = 0; i< 1; i++)
    //    {

    //        NEWEMP dobj = new NEWEMP();
    //    dobj.Deptid = Convert.ToInt32(ds.Tables[0].Rows[1]["Deptid"].ToString());
    //        dobj.DeptName = ds.Tables[0].Rows[1]["DeptName"].ToString();
    //    Deptlist.Add(dobj);
    //    }
    //d.Departments = Deptlist;



    //    cmd.ExecuteNonQuery();
    //    sda.Fill(dt);

        //ViewBag.DeptName = ds.Tables[0];



        //List<SelectListItem> getDeptName = new List<SelectListItem>();



        //foreach (System.Data.DataRow dr in ViewBag.DeptName.Rows)
        //{
        //    getDeptName.Add(new SelectListItem { Text = @dr["DeptName"].ToString(), Value = @dr["DeptName"].ToString() });



        //}
        //ViewBag.Department = getDeptName;
        //con.Close();


        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.Message);

        //        }
        //    }
        //    return View();
        //}





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

            catch (Exception se)
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
