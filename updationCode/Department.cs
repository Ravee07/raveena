using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace sammple.Models
{
    public class Department
    {
        public List<Department> Departments { get; set; }
        public int Deptid { get; set;}
        public string DeptName { get; set; }
        public int Empid { get; set; }
    }
}
