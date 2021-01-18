using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using SampleProject.Models;
using SampleProject.NewFolder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;

namespace SampleProject.Controllers
{
    public class EmpController : Controller
    {


        NewFolder.UseDB use = new NewFolder.UseDB();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult showdata()
        {

            DataSet ds = use.showdata();
            ViewBag.emp = ds.Tables[0];


            return View();
        }
       



       
        public IActionResult Add()
        {
            Employee emp = new Employee();
           // emp.EmpName = fc["EmpName"];
            //Department dept = new Department();
            //dept.DeptName = fc["DeptName"];
            //EmployeeDetail ed = new EmployeeDetail();
            //ed.DateOfBirth = Convert.ToInt32(fc["DateOfBirth"]);
            //ed.DateOfJoining = Convert.ToInt32(fc["DateOfJoining"]);
            //ed.DateOfBirth = Convert.ToInt32(fc["DateOfBirth"]);
            //ed.Designation = fc["Designation"];
            //ed.Degree = fc["Degree"];
            //ed.PassOutYear = fc["PssOutYear"];
            //BankDetail bd = new BankDetail();
            //bd.BankName = fc["BankName"];
            //bd.AccountNo = Convert.ToInt32(fc["AccountNo"]);
            //bd.BasicSalary = Convert.ToInt32(fc["BasicSalary"]);
            //bd.HRA = Convert.ToInt32(fc["HRA"]);
            //bd.OtherAllowances = Convert.ToInt32(fc["OtherAllowances"]);
            //bd.PF = Convert.ToInt32(fc["PF"]);
            //bd.MedicalPremium = Convert.ToInt32(fc["MedicalPremium"]);
            //bd.TDS = Convert.ToInt32(fc["TDS"]);

            //use.Add(emp, dept,ed,bd);

            use.Add(emp);

            return View();

        }

        //public ActionResult Update(int id)
        //{
        //    return View();
                
        //}


        //[HttpPost]
        //public ActionResult Update(int id ,FormCollection fc)
        //{
        //    Employee emp = new Employee();
        //    emp.Deptid = id;
        //    emp.EmpName = fc["EmpName"];
        //    Department dept = new Department();
        //    dept.DeptName = fc["DeptName"];
        //    EmployeeDetail ed = new EmployeeDetail();
        //    ed.DateOfBirth = Convert.ToInt32(fc["DateOfBirth"]);
        //    ed.DateOfJoining = Convert.ToInt32(fc["DateOfJoining"]);
        //    ed.DateOfBirth = Convert.ToInt32(fc["DateOfBirth"]);
        //    ed.Designation = fc["Designation"];
        //    ed.Degree = fc["Degree"];
        //    ed.PassOutYear = fc["PssOutYear"];
        //    BankDetail bd = new BankDetail();
        //    bd.BankName = fc["BankName"];
        //    bd.AccountNo = Convert.ToInt32(fc["AccountNo"]);
        //    bd.BasicSalary = Convert.ToInt32(fc["BasicSalary"]);
        //    bd.HRA = Convert.ToInt32(fc["HRA"]);
        //    bd.OtherAllowances = Convert.ToInt32(fc["OtherAllowances"]);
        //    bd.PF = Convert.ToInt32(fc["PF"]);
        //    bd.MedicalPremium = Convert.ToInt32(fc["MedicalPremium"]);
        //    bd.TDS = Convert.ToInt32(fc["TDS"]);

        //    use.Update(emp, dept, ed, bd);



        //    return View();

        //}








    }
}
