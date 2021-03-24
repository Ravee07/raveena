using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AskFM.Models
{
    public class Question
    {
        public int queId { get; set; }
        public string question { get; set; }
        public int TopicId { get; set; }
         public int userId { get; set; }

        public HttpPostedFileBase postedFile { get; set; }
        public string topicName { get; set; }
    }
}
