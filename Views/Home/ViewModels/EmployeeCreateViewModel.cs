using Microsoft.AspNetCore.Http;
using myfirstnetcoreapp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myfirstnetcoreapp.Views.Home
{
    public class EmployeeCreateViewModel
    {
       
        [Required]
        [MaxLength(50, ErrorMessage = "Max length exeeded")]
        public string Name { get; set; }

        [Display(Name="Office Email")]
        [Required]
        public string Email { get; set; }

        [Required]
        public Depts Department { get; set; }

        public IFormFile Photo { get; set; }
    }
}
