using AskFM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;



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
            DataTable dt = new DataTable();
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


                    cmd.ExecuteNonQuery();
                    sda.Fill(ds);


                    bool loginSuccessful = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

                    if (loginSuccessful)
                    {
                       // Console.WriteLine("Success!");
                        return RedirectToAction("RegisterUser");
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

            return View();
        }
        




        [HttpGet]
        public ActionResult RegisterUser()
        {
            return View();
        }


        [HttpPost]

        public ActionResult RegisterUser(UserDetail ud)
        {
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
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }

            }
           return RedirectToAction("LOGIN");
        }












































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
        [ValidateAntiForgeryToken]
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
    }
}
