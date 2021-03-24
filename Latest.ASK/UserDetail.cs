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


        [Required(ErrorMessage = "Please Enter UserName")]
        [Display(Name = "UserName")]
        public string userName { get; set; }


        [Required(ErrorMessage = "Please Enter password")]
        [Display(Name = "Password")]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$",
        ErrorMessage = "Passwords must be at least 8 characters and must contain  upper case (A-Z), lower case (a-z), number (0-9) and special character ")]
        public string password { get; set; }

       

        [Compare("password", ErrorMessage = "The passwords do not match.")]
        public string ConfirmPassword { get; set; }



        [Required(ErrorMessage = "Please Enter email")]
        [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$",
        ErrorMessage = "Please Enter Correct Email Address")]
        public string email { get; set; }

        public DateTime createdOn { get; set; }

        public DateTime lastLoginDate { get; set; }

        public DateTime isActive { get; set; }

        public int empId { get; set; }

        public int queId { get; set; }


        public int ansId { get; set; }
        public string answer { get; set; }
        public string question { get; set; }
        public string createdon { get; set; }

        public string createdby { get; set; }

        public string createon { get; set; }
        public string createby { get; set; }



        public List<Answer> ans { get; set; }
        public List<Question> que { get; set; }

    }
}
