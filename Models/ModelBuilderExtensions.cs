using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myfirstnetcoreapp.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
          new Employee() { Id = 2, Name = "Pilli Smith", Email = "pillismith@gmail.com", Department = Depts.PayRoll });
            modelBuilder.Entity<Employee>().HasData(
               new Employee() { Id = 3, Name = "Mary Kom", Email = "mary@gmail.com", Department = Depts.HR });
        }
    }
}
