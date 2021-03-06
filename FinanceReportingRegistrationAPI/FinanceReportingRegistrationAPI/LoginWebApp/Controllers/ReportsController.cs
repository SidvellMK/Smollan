﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginWebApp.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreditCard()
        {
            return PartialView("_CreditCard");
        }

        [HttpPost]
        public IActionResult UploadReport(IFormFile file)
        {
            if (file == null)
            {
                return View();
            }

            return View();
        }

        [HttpGet]
        public IActionResult UploadReport()
        {
            return PartialView("_UploadReport");
        }

        [HttpGet]
        public IActionResult Cellular()
        {
            return PartialView("_Cellular");
        }

        [HttpGet]
        public IActionResult Fleet()
        {
            return PartialView("_Fleet");
        }

        [HttpGet]
        public IActionResult Payroll()
        {
            return PartialView("_Payroll");
        }

        [HttpGet]
        public IActionResult Procurement()
        {
            return PartialView("_Procurement");
        }

        [HttpGet]
        public IActionResult Travel()
        {
            return PartialView("_Travel");
        }
    }
}