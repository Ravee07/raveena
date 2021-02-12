using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Models
{
    public class mymodel
    {
        public Employee Employee { get; set; }
        public Department department { get; set; }
        public int Deptid { get; set; }
         public string EmpName { get; set; }
        public string DeptName { get; set; }

        public List<Department> Department { get; set; }


    }
}
