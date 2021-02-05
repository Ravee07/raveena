using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using sammple.Models;
using sammple.Controllers;
using System.Data.SqlClient;

namespace sammple.data_Access_Layer
{
    public class db
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-HT3QBIT\\SQLEXPRESS;Database=EmployeeDB;integrated security=true");

        public DataSet Showdata()
        {
            SqlCommand com = new SqlCommand("SP_Showdataa", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;


        }

        public void Insert(Models.Employee emp, Models.Department dept)
        {
            SqlCommand com = new SqlCommand("SP_Insert", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            com.Parameters.AddWithValue("@EmpName", emp.EmpName);
            com.Parameters.AddWithValue("@DeptName", dept.DeptName);

            DataSet ds = new DataSet();
            da.Fill(ds);


        }

    }
}
