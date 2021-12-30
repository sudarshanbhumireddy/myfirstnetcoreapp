using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myfirstnetcoreapp.Views.Home.ViewModels
{
    public class LogInViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="User Name")]
        public string Email { get; set; }
        [Required]
        [Display(Name ="User Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Remember me")]
        public bool Rememberme { get; set; }
    }
}
