using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myfirstnetcoreapp.Models
{
    public class ApplicationUser:IdentityUser
    {
       
        public string city { get; set; }
    }
}
