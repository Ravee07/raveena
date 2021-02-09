using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Models
{
    public class EmployeeDepartment
    {
        public Employee employee { get; set; }
        public int Deptid { get; set; }
         public string EmpName { get; set; }

        public List<Department>Departments { get; set; }
       public Department department { get; set; }



    }
}
