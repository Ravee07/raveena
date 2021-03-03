using AskFM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AskFM.Models;
using AskFM.Controllers;




namespace AskFM.Controllers
{
    public class UserController : Controller
    {

       

        SqlConnection con = new SqlConnection("Server = DESKTOP-OK1P17M\\MSSQLSERVERNEW; Database = ASKFM; integrated security =True");

        [HttpGet]
        public ActionResult LOGIN()
        {
            return View();
        }

        [HttpPost]

        public ActionResult LOGIN(UserDetail ud)
        {
         
            object Session = null;
            using (con)
            {
                try
                {
                    con.Open();
                    string email = ud.email.ToString();
                    string password = ud.password.ToString();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_LOGIN", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@email", ud.email);

                    cmd.Parameters.AddWithValue("@password", ud.password);

                   // object Session = null;
                   // Session = ud.email;
                    cmd.ExecuteNonQuery();
                    sda.Fill(ds);
                    

                    bool loginSuccessful = ((ds.Tables.Count > 0) & (ds.Tables[0].Rows.Count > 0));

                    if (loginSuccessful)
                    {
                       // Session = ud.email;
                        HttpContext.Session.SetString("email", email);
                       // Console.WriteLine("Success!");
                        return RedirectToAction("First1");
                    }
                    else
                    {
                       // Console.WriteLine("Invalid username or password");
                        ViewBag.Message = string.Format("incorrect email {0} and password{1}", email, password);

                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }

            }

            return RedirectToAction();
        }



            


        [HttpGet]
        public ActionResult RegisterUser()
        {
            return View();
        }


        [HttpPost]

        public ActionResult RegisterUser(UserDetail ud)
        {
            bool status;
            DataTable dt = new DataTable();
            using (con)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_RegisterUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("userName", ud.userName);
                    cmd.Parameters.AddWithValue("@password", ud.password);
                    cmd.Parameters.AddWithValue("@email", ud.email);


                   



                     cmd.ExecuteNonQuery();
                     sda.Fill(dt);
                    status = Convert.ToBoolean(cmd.ExecuteScalar());
                    string message = string.Empty;

                    if (status == true)
                    {
                        // ViewBag.Message = string.Format("email already exist please provide another email" );
                        ViewBag.message = "email already exist please provide another email"; 
                        return RedirectToAction("RegisterUser");
                    }
                    else
                    {
                        // Console.WriteLine("Invalid username or password");
                        //ViewBag.Message = string.Format("incorrect email {0} and password{1}", email, password);
                        //  ViewBag.Message = string.Format("Registerd successfully");
                        ViewBag.message = "Registerd successfully";

                    }

                  //  ViewBag.Message = message;
                    return View(ud);


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }

            }
           return RedirectToAction("LOGIN");
        }










        //public ActionResult logout()
        //{
        //    //Session.Remove("email");
        //    // Microsoft.AspNetCore.Session.Clear();
        //    if (HttpContext.Session.GetString("email") != null) ; 
        //    HttpContext.Session.Remove("email");

        //    return View();
        //}




















        //protected void Page_Load(object sender, EventArgs e, object Session)
        //{
        //    if (Session["email"]
        //        == null)
        //        Response.Redirect("FrmLogin.aspx");
        //    else
        //    {
        //       // String userid = Convert.ToString((int)Session["userid"]);
        //        String username = Session["email"].ToString();
        //        String userrole = Session["password"].ToString();

        //        lbluserInfo.Text = "Welcome, " + username + ". Your userid is " + userid + " and your role is " + userrole + ".";
        //    }
        //}
        //protected void btnLogout_Click(object sender, EventArgs e)
        //{
        //    Session["Name"] = null;
        //    Session["Role"] = null;
        //    Response.Redirect("FrmLogin.aspx");
        //}












        // GET: UserDetail
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserDetail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserDetail/Create
        [HttpPost]
     
        public ActionResult Create(IFormCollection collection)
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

        // GET: UserDetail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserDetail/Edit/5
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

        // GET: UserDetail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserDetail/Delete/5
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

         
        //SqlConnection con = new SqlConnection("Server = DESKTOP-OK1P17M\\MSSQLSERVERNEW; Database = ASKFM; integrated security =True");
        [HttpGet]
        public ActionResult First1()
        {
            // DataSet ds = new DataSet();
            DataSet ds = new DataSet();
            using (con)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("ShowQuestion", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);


                    cmd.ExecuteNonQuery();
                    sda.Fill(ds);



                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }

            }

            return View(ds);
        }

        public ActionResult logout()
        {
            //Session.Remove("email");
            // Microsoft.AspNetCore.Session.Clear();
            string message = string.Empty;
            if (HttpContext.Session.GetString("email") != null) ;
            DataTable dt = new DataTable();
            using (con)
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("logout", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@email", HttpContext.Session.GetString("email"));
                cmd.ExecuteNonQuery();
                sda.Fill(dt);
                HttpContext.Session.Remove("email");
                ViewBag.Message = string.Format("succesfylly logout");
                // message = "LOGOUT SUCCESSFUL";
                //return RedirectToAction("First");

            }
            //ViewBag.Message = message;
            return RedirectToAction("First");

        }
    }
}
