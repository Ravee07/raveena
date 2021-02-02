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
        public long AccountNo { get; set; }
         
         public long BasicSalary { get; set; }
        public long HRA { get; set; }
        public long OtherAllowances { get; set; }

        public long GrossSalary { get; set; }

        public long PF { get; set; }
        public long MedicalPremium { get; set; }
        public long TDS { get; set; }

         public long NetSalary { get; set; }

        public int Empid { get; set; }

    }
}
