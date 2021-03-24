using AskFM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AskFM.Controllers
{
    public class QuestionController : Controller
    {
        SqlConnection con = new SqlConnection("Server = DESKTOP-OK1P17M\\MSSQLSERVERNEW; Database = ASKFM; integrated security =True");
        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult Details(int id)
        {
            return View();
        }

      [HttpGet]
        public ActionResult CreateQuestion()
        {
            {
                SqlCommand cmd = new SqlCommand("LIST_TOPIC", con);
                cmd.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();


                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                // Employee d = new Employee();
                sda.Fill(ds);
                ViewBag.topicName = ds.Tables[0];



                List<SelectListItem> gettopicName = new List<SelectListItem>();



                foreach (System.Data.DataRow dr in ViewBag.topicName.Rows)
                {
                    gettopicName.Add(new SelectListItem { Text = @dr["topicName"].ToString(), Value = @dr["topicName"].ToString() });



                }


                ViewBag.Topic = gettopicName;
                con.Close();
            }
            return View(new Question());
        }

        // POST: QuestionController/Create
        [HttpPost]
     
        public ActionResult CreateQuestion(Question  q)

             //HttpPostedFileBase postedFile

        {
            DataTable dt = new DataTable();
            using (con)
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SP_ADD_QUESTION", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@question", q.question);
                    cmd.Parameters.AddWithValue("@topicName", q.topicName);
                    string em = HttpContext.Session.GetString("email");
                    cmd.Parameters.AddWithValue("@email", em);
                  //  cmd.Parameters.AddWithValue("@FileUpload", Path.GetFileName(postedFile.FileName));

                    // cmd.Parameters.AddWithValue("@email", HttpContext.Session.GetString("email"));
                    cmd.ExecuteNonQuery();
                    sda.Fill(dt);
                    ViewBag.Message ="Question added ";


                }
                catch (Exception e)
                {
                            Console.WriteLine(e.Message);

                }
            }
            return RedirectToAction("First1","User");
        }


        // GET: QuestionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QuestionController/Edit/5
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

        // GET: QuestionController/Delete/5
        public ActionResult Delete(int id)
        {
            return RedirectToAction("First1");
        }

        // POST: QuestionController/Delete/5
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
