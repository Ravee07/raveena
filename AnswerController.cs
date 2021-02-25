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
    public class AnswerController : Controller
    {
        SqlConnection con = new SqlConnection("Server = DESKTOP-OK1P17M\\MSSQLSERVERNEW; Database = ASKFM; integrated security =True");

        // GET: AnswerController
        public ActionResult Index()
        {
            return View();
        }

      
        public ActionResult AddAnswer()
        {
            return View(new Answer());
        }

        
        [HttpPost]
       
        public ActionResult AddAnswer(Answer a)
        {
            DataTable dt = new DataTable();
            using (con)
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SP_ADD_ANSWER", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@answer ", a.answer);
                   // cmd.Parameters.AddWithValue("@topicName", q.topicName);

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

   
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AnswerController/Edit/5
        [HttpPost]

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

        // GET: AnswerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AnswerController/Delete/5
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
