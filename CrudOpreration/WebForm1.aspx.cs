using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace PhoneBookAppp
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter sda = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();





        protected void Page_Load(object sender, EventArgs e)
        {
            con.ConnectionString = "Data Source=DESKTOP-OK1P17M\\MSSQLSERVERNEW;Initial Catalog=PhoneBookDB;Integrated Security=True";
            con.Open();

            if (!Page.IsPostBack)
            {
                DataShow();

            }

        }

        protected void add_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "Insert into TbPhoneBook(Name, PhoneNum,Address)values('" + txtName.Text.ToString() + "', '" + tctNum.Text.ToString() + "', '" + txtAdd.Text.ToString() + "')";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();

        }

        public void DataShow()
        {
            ds = new DataSet();
            cmd.CommandText = "Select * from TbPhoneBook";
            cmd.Connection = con;
            sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            GridView1.DataSource = ds;
            GridView1.DataBind();
            con.Close();



        }

        protected void update_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "update TbPhoneBook  set PhoneNum='" + tctNum.Text.ToString() + "' ,Address='" + txtAdd.Text.ToString() +"' where Name='"+txtName.Text.ToString()+"' ";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            //con.Close();
            DataShow();
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "Delete from TbPhoneBook    where Name= '" + txtName.Text.ToString() + "'  ";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();

        }

        protected void DeleteAll_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = " delete  from TbPhoneBook ";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();
             
        }
    }
}