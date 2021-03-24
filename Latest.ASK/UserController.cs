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
using System.IO;

namespace AskFM.Controllers
{
    public class UserController : Controller
    {



        SqlConnection con = new SqlConnection("Server = DESKTOP-OK1P17M\\MSSQLSERVERNEW; Database = ASKFM; integrated security =True");

        //private List<UserDetail> UserDetails = new List<UserDetail>();

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
                    // DataTable ds = new DataTable();
                    SqlCommand cmd = new SqlCommand("SP_LOGIN", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@email", ud.email);

                    cmd.Parameters.AddWithValue("@password", ud.password);

                    // object Session = null;
                    //  Session = ud.email;
                    cmd.ExecuteNonQuery();
                    sda.Fill(ds);


                    bool loginSuccessful = ((ds.Tables.Count > 0) & (ds.Tables[0].Rows.Count > 0));

                    if (loginSuccessful)
                    {
                        Session = ud.email;
                        HttpContext.Session.SetString("email", email);
                        // HttpContext.Current.Session["email"] = ud.email;
                        // Console.WriteLine("Success!");
                        ViewBag.Message = "login Sucessfull";
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




























        //  SqlConnection con = new SqlConnection("Server = DESKTOP-OK1P17M\\MSSQLSERVERNEW; Database = ASKFM; integrated security =True");
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

                    //  HttpContext.Session.SetString("queid", queid);
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
            {
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
                    //message = "LOGOUT SUCCESSFUL";
                    //return RedirectToAction("First");
                }
            }
            //ViewBag.Message = message;
            return RedirectToAction("READ", "READONLY");

        }

        [HttpGet]
        // public ActionResult Detail(int id)
        public ActionResult Detail(int id)
        {

            List<UserDetail> userDetails = new List<UserDetail>();

            // DataSet ds = new DataSet();
            //  DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            //  UserDetail ObjMaster = new UserDetail();
            using (con)


            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_Details", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@queId", id);
                    //  HttpContext.Session.SetString("queid", queid);
                    cmd.ExecuteNonQuery();
                    sda.Fill(ds);

                    //    using (SqlDataReader sdr = cmd.ExecuteReader())
                    //    {
                    //        while (sdr.Read())
                    //        {
                    //            userDetails.Add(new UserDetail
                    //            {
                    //                question = sdr["question"].ToString(),
                    //                answer = sdr["answer"].ToString(),
                    //                userName = sdr["userName"].ToString(),
                    //                //Country = sdr["Country"].ToString()
                    //            });
                    //        }
                    //    }
                    //    con.Close();

                    //}

                }


                // con.Open();
                //// var objDetails = SqlMapper.QueryMultiple(con, "Detail", commandType: CommandType.StoredProcedure);
                //  SqlCommand cmd = new SqlCommand("SP_Details", con);
                //   cmd.CommandType = CommandType.StoredProcedure;
                //  SqlDataAdapter sda = new SqlDataAdapter(cmd);

                //// cmd.Parameters.AddWithValue("@queId", id);
                //  cmd.ExecuteNonQuery();
                // sda.Fill(ds);
                // var o = ds;
                //ObjMaster.ans = o.Read<Answer>().ToList();
                //ObjMaster.que = o.Read<Question>().ToList();


                //  SqlDataReader sda = cmd.ExecuteReader();
                //dt.Load(sda)t;


                //    foreach (DataRow dr in ds.Tables[0].Rows)

                //    {

                //        UserDetails.Add(new UserDetail() { question = dr[1].ToString(),   answer = dr[2].ToString(), userName = dr[3].ToString() });

                //    }

                //}

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }

            }
            // return userDetails;
            return View(ds);
        }











        //[HttpPost]

        //public ActionResult AddAnswer1(Answer b)
        //{
        //    DataTable dt = new DataTable();
        //    using (con)
        //    {
        //        try
        //        {
        //            con.Open();

        //            SqlCommand cmd = new SqlCommand("SP_ADD_ANSWER", con);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            SqlDataAdapter sda = new SqlDataAdapter(cmd);

        //            cmd.Parameters.AddWithValue("@answer", b);
        //            //cmd.Parameters.AddWithValue("@question", b);
        //            // cmd.Parameters.AddWithValue("@topicName", q.topicName);
        //            if (HttpContext.Session.GetString("email") != null)
        //            {
        //                string em = HttpContext.Session.GetString("email");
        //                cmd.Parameters.AddWithValue("@email", em);
        //                // cmd.Parameters.AddWithValue("@email", HttpContext.Session.GetString("email"));
        //                //cmd.Parameters.AddWithValue("@email", HttpContext.Session.GetString("email"));
        //                //cmd.Parameters.AddWithValue("@email", Session);
        //                cmd.ExecuteNonQuery();
        //                sda.Fill(dt);




        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.Message);

        //        }
        //    }
        //    return View();
        //}



        [HttpGet]
        public ActionResult info(int id)
        {
            SqlConnection con = new SqlConnection("Server = DESKTOP-OK1P17M\\MSSQLSERVERNEW; Database = ASKFM; integrated security =True");

         
           // DataTable dt = new DataTable();
             DataSet ds = new DataSet();
            //  UserDetail ObjMaster = new UserDetail();
            using (con)


            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_Details", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@queId", id);
                    //  HttpContext.Session.SetString("queid", queid);
                    cmd.ExecuteNonQuery();
                    sda.Fill(ds);






                }

             

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }



                return View(ds);


            }


        }


    }
}

