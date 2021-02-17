using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AskFM.Models
{
    public class UserDetail
    {
        public int userId { get; set; }

       
        public string userName { get; set; }


        [Required(ErrorMessage = "Please Enter password")]
        [Display(Name = "Password")]
        public string password { get; set; }


        [Required(ErrorMessage = "Please Enter email")]
        [Display(Name = "email")]
        public string email { get; set; }

        public DateTime createdOn { get; set; }

        public DateTime lastLoginDate { get; set; }

        public DateTime isActive { get; set; }

        public int empId { get; set; }

    }
}
