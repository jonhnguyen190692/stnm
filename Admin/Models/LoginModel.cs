using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Nhập User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Nhập password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}