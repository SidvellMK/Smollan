using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LoginWebApp.Controllers
{
    public class ErrorController : Controller
    {
        [Route("500")]
        public IActionResult ServerError()
        {
            return View();
        }

        [Route("401")]
        public IActionResult UnauthorizedAccess()
        {
            return View();
        }

        [Route("403")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [Route("404")]
        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}