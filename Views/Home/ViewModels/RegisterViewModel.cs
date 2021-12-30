using Microsoft.AspNetCore.Mvc;
using myfirstnetcoreapp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myfirstnetcoreapp.Views.Home.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Remote(action: "IsEmailInUse", controller:"Account")]
        [ValidEmailDomain(allowedDomain:"pragimtech.com", ErrorMessage ="Email domain must match pragimtech.com")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("Password",ErrorMessage ="Password and Confirm Password not match")]
        public string ConfirmPassword { get; set; }

        public string city { get; set; }
    }
}
