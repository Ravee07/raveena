using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using SampleProject.Models;
using SampleProject.NewFolder;

namespace SampleProject.Controllers
{
    public class empcontroller : Controller
    {


        NewFolder.UseDB use = new NewFolder.UseDB();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListEmployee()
        {

            DataSet ds = use.ListEmployee();
            ViewBag.emp = ds.Tables[0];


              return View();
        }
    }
}
