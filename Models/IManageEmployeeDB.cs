using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myfirstnetcoreapp.Models
{
   public interface IManageEmployeeDB
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployee(int? id);
      
        void AddEmployee(Employee employee);

        Employee DeleteEmployee(int? id);

        Employee UpdateEmployee(Employee employee);
    }
}
