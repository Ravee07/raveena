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

      [HttpGet]
        public ActionResult AddAnswer( int id )
        {
           // Question q = new Question();
            Answer a = new Answer();


            DataTable dt = new DataTable();
            using (con)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("GetQue", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.SelectCommand.Parameters.AddWithValue("@queId", id);
                    // sda.SelectCommand.Parameters.AddWithValue("@question", id);
                    // sda.SelectCommand.Parameters.AddWithValue("@email", HttpContext.Session.GetString("email"));

                    cmd.ExecuteNonQuery();
                    sda.Fill(dt);
                    if (dt.Rows.Count == 1)
                    {
                          a.queId = Convert.ToInt32(dt.Rows[0][0]);
                        a.question = dt.Rows[0][1].ToString();
                        //a.answer = dt.Rows[0][2].ToString();
                        return View(a);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                     return RedirectToAction("AddAnswer");

                }

            }
            return View();
            //return View();
          //  return RedirectToAction("AddAnswer");
        }

        
        [HttpPost]
       
        public ActionResult AddAnswer( Answer b)
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

                    cmd.Parameters.AddWithValue("@queId", b.queId);
                    cmd.Parameters.AddWithValue("@question", b.question);
                    cmd.Parameters.AddWithValue("@answer", b.answer);
                    //cmd.Parameters.AddWithValue("@question", b);
                    // cmd.Parameters.AddWithValue("@topicName", q.topicName);
                    //if (HttpContext.Session.GetString("email") != null)
                    //{
                        string em = HttpContext.Session.GetString("email");
                        cmd.Parameters.AddWithValue("@email", em);
                        // cmd.Parameters.AddWithValue("@email", HttpContext.Session.GetString("email"));
                        //cmd.Parameters.AddWithValue("@email", HttpContext.Session.GetString("email"));
                        //cmd.Parameters.AddWithValue("@email", Session);
                        cmd.ExecuteNonQuery();
                        sda.Fill(dt);
                     
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
            }
            return RedirectToAction("First1", "User");
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
