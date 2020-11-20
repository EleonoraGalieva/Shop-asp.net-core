using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BakeryShop.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]   
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.Message = "Sorry, the page is not found."; break;
                default:
                    ViewBag.Message = "Something went wrong..."; break;
            }
            return View("ErrorPage");
        }
        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.ExceptionMessage = exceptionDetails.Error.Message;
            return View("Error");
        }
    }
}
