using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Proj.NewFolder
{
    public class UseDB
    {


        SqlConnection con = new SqlConnection("Server = DESKTOP-OK1P17M\\MSSQLSERVERNEW; Database = EmployeeDB; integrated security =True");

        public DataSet ListEmployee()
        {
            SqlCommand cmd = new SqlCommand("SP_ListEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            sda.Fill(ds);

            return ds;

        }
    }
}