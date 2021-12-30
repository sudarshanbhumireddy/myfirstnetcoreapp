using Microsoft.AspNetCore.Identity;
using myfirstnetcoreapp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myfirstnetcoreapp.Views.Home.ViewModels
{
    public class EditRoleModel
    {
        public EditRoleModel()
        {
            users = new List<string>();
        }
        [Required]
        public string RoleName { get; set; }
        public string RoleId { get; set; }

        public List<string> users { get; set; }
    }
}
