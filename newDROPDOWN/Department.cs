using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Models
{
    public class Department
    {
        internal List<Department> Departments;

        public int Deptid { get; set; }

         public string DeptName { get; set; }
        
         public int Empid { get; set;}


        //public List<SelectListItem> Departments {​ get; set; }​



        //public List<Department> Departments { get; set; }
    }
}
