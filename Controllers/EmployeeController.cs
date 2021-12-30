using Microsoft.AspNetCore.Mvc;
using myfirstnetcoreapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myfirstnetcoreapp.Controllers
{
    public class EmployeeController : Controller
    {
        private IManageEmployeeDB _manageEmployee;
        public EmployeeController(IManageEmployeeDB manageEmployee)
        {
            _manageEmployee = manageEmployee;
        }
        public IActionResult Index()
        {
            _manageEmployee.GetAllEmployees();
            return View(_manageEmployee.GetAllEmployees());
        }
        public ViewResult Details()
        {
          
            return View("View");
        }

    }
}
