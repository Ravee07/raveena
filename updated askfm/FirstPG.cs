using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskFM.Controllers;
namespace AskFM.Models
{
    public class FirstPG
    {
        public int userId { get; set; }
        public string userName { get; set; }

        public int queId { get; set; }

        public string question { get; set; }
        public int TopicId { get; set; }
     

        public string topicName { get; set; }

    }
}
