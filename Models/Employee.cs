using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myfirstnetcoreapp.Models
{
    public class EmployeeMetaData
    {

    }
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="Max length exeeded")]
        public string Name { get; set; }


        [Required]
        public string Email{ get; set; }

        [Required]
        public Depts Department { get; set; }

        public string FilePath { get; set; }
        
    }
}
