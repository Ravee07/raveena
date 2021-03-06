﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SampleProject.Controllers;
using System.Collections.Concurrent;
namespace SampleProject.Controllers
{
    public class employeeController : Controller
    {
        SqlConnection con = new SqlConnection("Server = DESKTOP-OK1P17M\\MSSQLSERVERNEW; Database = EmployeeDB; integrated security =True");

        // GET: employeeController
        //public ActionResult Index()
        //{
        public ActionResult GetEmployeeDepartment()
        {
            EmployeeDepartment ed = new EmployeeDepartment();
            ed.employee = GetEmployee();
            ed.department = GetDepartment();
            return View(ed);
        }

        public Employee GetEmployee()
        {
            DataTable dt = new DataTable();
            Employee d = new Employee();
            //  DataSet ds = new DataSet();

            using (con)
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SP_InsertEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@Deptid", d.Deptid);
                    cmd.Parameters.AddWithValue("@EmpName", d.EmpName);

                    cmd.ExecuteNonQuery();
                    sda.Fill(dt);
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }


                return d;

            }
        }


        public Department GetDepartment()
        {
            DataSet ds = new DataSet();
            Department d = new Department();
            List<Department> Deptlist = new List<Department>();
            SqlCommand cmd = new SqlCommand("LIST", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            for (int i = 0; i < 1; i++)
            {

                Department dobj = new Department();
                dobj.Deptid = Convert.ToInt32(ds.Tables[0].Rows[1]["Deptid"].ToString());
                dobj.DeptName = ds.Tables[0].Rows[1]["DeptName"].ToString();
                Deptlist.Add(dobj);
            }
            d.Departments = Deptlist;



            cmd.ExecuteNonQuery();
            sda.Fill(ds);
            return d;

        

















        //    return View();
        //}

        // GET: employeeController/Details/5
      
        }
    }

}
