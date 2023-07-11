using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace User.Models
{
    public class NewUser
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "User Name:")]
        public String UserName { get; set; }

        [Display(Name = "Password:")]
        public String Password { get; set; }

        [Display(Name = "Upload Image:")]
        public byte[] Image { get; set; }
    }
}