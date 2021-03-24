using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AskFM.Models;
namespace AskFM.Controllers
{
    public class READONLY : Controller
    {
        SqlConnection con = new SqlConnection("Server = DESKTOP-OK1P17M\\MSSQLSERVERNEW; Database = ASKFM; integrated security =True");
        [HttpGet]
        public ActionResult READ()
        {
            DataSet ds = new DataSet();
           // DataTable ds = new DataTable();
            using (con)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("ShowQuestion",con);
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
            if (HttpContext.Session.GetString("email") != null) 
           // DataTable dt = new DataTable();
            using (con)
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("logout", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@email", HttpContext.Session.GetString("email"));
                cmd.ExecuteNonQuery();
               // sda.Fill(dt);
                HttpContext.Session.Remove("email");
                ViewBag.Message = string.Format("succesfylly logout");
                // message = "LOGOUT SUCCESSFUL";
                //return RedirectToAction("First");

            }
            //ViewBag.Message = message;
            return RedirectToAction("First");
                 


        }
























        // GET: FirstPG/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FirstPG/Create1
        public ActionResult Create()
        {
            return View();
        }

        // POST: FirstPG/Create
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

        // GET: FirstPG/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FirstPG/Edit/5
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

        // GET: FirstPG/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FirstPG/Delete/5
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
