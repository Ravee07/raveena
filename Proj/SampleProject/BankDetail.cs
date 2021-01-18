using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Models
{
    public class BankDetail
    {

         public int Bankid { get; set; }
        public string BankName { get; set; }
        public int AccountNo { get; set; }
         
         public int BasicSalary { get; set; }
        public int HRA { get; set; }
        public int OtherAllowances { get; set; }

        public int GrossSalary{ get; set; }

        public int PF { get; set; }
        public int MedicalPremium{ get; set; }
        public int TDS { get; set; }

         public int NetSalary { get; set; }

        public int Empidid { get; set; }

    }
}
