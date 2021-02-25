using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AskFM.Controllers
{
    public class FirstPG : Controller
    {
        SqlConnection con = new SqlConnection("Server = DESKTOP-OK1P17M\\MSSQLSERVERNEW; Database = ASKFM; integrated security =True");
      
        public ActionResult First()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            using (con)
            {
                try
                {
                    con.Open();
                   
                  
                    SqlCommand cmd = new SqlCommand("ShowQuestion", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    //cmd.Parameters.AddWithValue("@email", ud.email);

                    //cmd.Parameters.AddWithValue("@password", ud.password);


                    cmd.ExecuteNonQuery();
                    sda.Fill(dt);


                  
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }

            }

            return View();
        }

        // GET: FirstPG/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FirstPG/Create
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
