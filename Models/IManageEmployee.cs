﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myfirstnetcoreapp.Models
{
    public interface IManageEmployee
    {
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetAllEmployees();
        Employee AddEmployee(Employee employee);

        Employee DeleteEmployee(int id);

        Employee UpdateEmployee(Employee employee);
        
    }
}
