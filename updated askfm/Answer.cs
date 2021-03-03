using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AskFM.Models
{
    public class Answer
    {
         public int ansId { get; set; }
        public string answer { get; set; }
        public int queId { get; set; }
        public int userId { get; set; }

         public string question { get; set; }
    }
}
