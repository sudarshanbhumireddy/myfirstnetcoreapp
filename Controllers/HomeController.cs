using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myfirstnetcoreapp.Models;
using myfirstnetcoreapp.Views.Home;
using myfirstnetcoreapp.Views.Home.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// Json(new { id = 1001 , name ="HellofromJson" })
namespace myfirstnetcoreapp.Controllers
{
    // [Route("Home")]
    public class HomeController : Controller
    {
        private readonly IManageEmployeeDB _manageEmployeeDB;
        private ILogger<HomeController> _logger;

        private readonly IWebHostEnvironment _hostingEnvironment;
        public HomeController(IManageEmployeeDB manageEmployeeDB, IWebHostEnvironment hostingEnvironment,
                               ILogger<HomeController> logger)
        {
            this._hostingEnvironment = hostingEnvironment;
            _manageEmployeeDB = manageEmployeeDB;
            _logger = logger;
        }

        //  [Route("Index")]
        // [Route("")]
        [AllowAnonymous]
        public ActionResult List()
        {
            IEnumerable<Employee> employees = _manageEmployeeDB.GetAllEmployees();
            return View(employees);
        }
        //   [Route("Details/{id?}")]
       
        public ActionResult Details(int? id)
        {
            //_logger.LogTrace("Trace log");
            //_logger.LogDebug("Debug log");
            //_logger.LogInformation("Information log");
            //_logger.LogWarning("Warning log");
            //_logger.LogError("Error log");
            //_logger.LogCritical("Critical log");


            //     throw new Exception("Exception occured");
            Employee model   = _manageEmployeeDB.GetEmployee(id.Value);
           
            
            if (model == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound",id);
            }
            //ViewData["Employee"] = _manageEmployee.GetEmployee(101);
         //   ViewBag.Employee = _manageEmployeeDB.GetEmployee((int)id);
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
       [Authorize]
        public ActionResult Create(EmployeeCreateViewModel model)
        {
            string uniquefileName = null;
            string uploadfilepath = null;
            if (model.Photo != null)
            {
                string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Images");

                uniquefileName = new Guid().ToString() + "_" + model.Photo.FileName;
                uploadfilepath = Path.Combine(filePath, uniquefileName);
                model.Photo.CopyTo(new FileStream(uploadfilepath, FileMode.Create));

            }
            Employee employee = new Employee();
            if (ModelState.IsValid)
            {

                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Department = model.Department;
                employee.FilePath = uniquefileName;
                _manageEmployeeDB.AddEmployee(employee);

                return RedirectToAction("Details", new { Id = employee.Id });
            }

            else
            {
                return View();
            }
        }
        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            Employee employee = _manageEmployeeDB.GetAllEmployees().FirstOrDefault(x => x.Id == id);
            EmployeeEditViewModel employeeEdit = new EmployeeEditViewModel();
            employeeEdit.Id = employee.Id;
            employeeEdit.Name = employee.Name;
            employeeEdit.Email = employee.Email;
            employeeEdit.Department = employee.Department;
            
            employeeEdit.ExistingPhoto = employee.FilePath;

            return View(employeeEdit);
        }
        [HttpPost]
        [Authorize]
        public ActionResult Edit(EmployeeEditViewModel model)
        {
            {
                 
                Employee employeefromDB = _manageEmployeeDB.GetAllEmployees().FirstOrDefault(x => x.Id == model.Id);
                if (ModelState.IsValid)
                {

                    employeefromDB.Name = model.Name;
                    employeefromDB.Email = model.Email;
                    employeefromDB.Department = model.Department;
                    if (model.Photo != null)
                    {
                        if (model.ExistingPhoto != null)
                        {
                            string filepath = Path.Combine(_hostingEnvironment.WebRootPath, "Images", model.ExistingPhoto);
                            System.IO.File.Delete(filepath);
                        }
                        employeefromDB.FilePath = FileUploadProcess(model);
                    }
                    _manageEmployeeDB.UpdateEmployee(employeefromDB);

                    return RedirectToAction("Details", new { Id = employeefromDB.Id });
                }

                else
                {
                    return View();
                }
            }

        }

        private string FileUploadProcess(EmployeeCreateViewModel model)
        {
            string uniquefileName = null;
            string uploadfilepath = null;
            if (model.Photo != null)
            {
                string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Images");

                uniquefileName = new Guid().ToString() + "_" + model.Photo.FileName;
                uploadfilepath = Path.Combine(filePath, uniquefileName);
                model.Photo.CopyTo(new FileStream(uploadfilepath, FileMode.Create));

            }

            return uniquefileName;
        }

        
       
       
    }

}
