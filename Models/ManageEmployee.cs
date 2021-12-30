using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myfirstnetcoreapp.Models
{
    public class ManageEmployee : IManageEmployee
    {
        private  List<Employee> _emplist;
        public ManageEmployee()
        {
            _emplist = new List<Employee>()
            {
                new Employee(){Id=101,Name="Pavan",Email="pavan@gmail.com",Department=Depts.IT},
                new Employee(){Id=102,Name="Raju",Email="raju@gmail.com",Department=Depts.PayRoll},
                new Employee(){Id=103,Name="Vinay",Email="vinay@gmail.com",Department=Depts.IT},
                new Employee(){Id=104,Name="Siva",Email="siva@gmail.com",Department=Depts.HR}
            };
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _emplist;
        }

        public Employee GetEmployee(int id)
        {
            return _emplist.FirstOrDefault(emp => emp.Id == id);
            
        }

        public  Employee AddEmployee(Employee employee)
        {
            employee.Id = this._emplist.Max(x => x.Id + 1);
            _emplist.Add(employee);
            return employee;
        }

        public Employee DeleteEmployee(int id)
        {
           Employee emp= _emplist.Find(x => x.Id == id);
            if (emp != null)
            {
                _emplist.Remove(emp);
            }
            return emp;
        }

        public Employee UpdateEmployee(Employee employeechanges)
        {
            Employee emp = _emplist.Find(x => x.Id == employeechanges.Id);
            if (emp != null)
            {
                emp.Name = employeechanges.Name;
                emp.Email = employeechanges.Email;
                emp.Department = employeechanges.Department;
            }
            return emp;
        }
    }
}
