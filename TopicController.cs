using AskFM.Models;
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
    public class TopicController : Controller
    {

        SqlConnection con = new SqlConnection("Server = DESKTOP-OK1P17M\\MSSQLSERVERNEW; Database = ASKFM; integrated security =True");
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateTopic()
        {
            return View(new Topic());
        }

        [HttpPost]
     
        public ActionResult CreateTopic (Topic t)
        {
            DataTable dt = new DataTable();
            using (con)
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SP_ADD_TOPIC", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("topicName", t.topicName);

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

        // GET: TopicController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TopicController/Edit/5
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

        // GET: TopicController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TopicController/Delete/5
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
