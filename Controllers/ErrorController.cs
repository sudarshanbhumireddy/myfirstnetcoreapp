using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
//using myfirstnetcoreapp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myfirstnetcoreapp.Controllers
{
    public class ErrorController : Controller
    {
        private ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
            
        }
        [Route("Error/HttpStatusCodeHandler/{statusCode}")]
        public ActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Requested Item cannot found please check url";
                    _logger.LogError($"Requested Item cannot found please check url status code is {statusCode}");
                    break;
            }
                
            return View("NotFound");
        }
        [Route("Error/Error")]
        [AllowAnonymous]
        public ViewResult Error()
        {
            var ExceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.ExceptionPath = ExceptionDetails.Path;
            ViewBag.ExceptionMessage = ExceptionDetails.Error.Message;
            ViewBag.ExceptionStack = ExceptionDetails.Error.StackTrace;
            return View("Error");
        }
    }
}
