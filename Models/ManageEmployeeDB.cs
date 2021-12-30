using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myfirstnetcoreapp.Models
{
    public class ManageEmployeeDB : IManageEmployeeDB
    {
        private AppDbContext context;
        private ILogger<ManageEmployeeDB> _logger;

        public ManageEmployeeDB(AppDbContext dbContext,ILogger<ManageEmployeeDB> logger)
        {
            this.context = dbContext;
            _logger = logger;
        }
        public void AddEmployee(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            
        }

        public Employee DeleteEmployee(int? id)
        {
           Employee employee= context.Employees.FirstOrDefault(x => x.Id == id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            _logger.LogTrace("Trace log");
            _logger.LogDebug("Debug log");
            _logger.LogInformation("Information log");
            _logger.LogWarning("Warning log");
            _logger.LogError("Error log");
            _logger.LogCritical("Critical log");
            return context.Employees;
        }

        public Employee GetEmployee(int? id)
        {
            Employee employee = context.Employees.FirstOrDefault(x => x.Id == id);
            return employee;
        }

        public Employee UpdateEmployee(Employee employeeChanges)
        {
            //   context.Update(employeeChanges);
          var employee=  context.Employees.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employeeChanges;
        }
    }
}
