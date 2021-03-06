﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IOTEST.Controllers
{
    [Route("/login")]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            ViewData.Add("Title", "IOTEST Login");
            ViewData.Add("ParalaxOn", true);
            ViewData.Add("CSS", new List<string> { "css/Install.css" });
            ViewData.Add("JSU", new List<string> { "js/VueComp.js" });
            ViewData.Add("JSD", new List<string> { "js/Login.js" });
            return View("Login");
        }
    }
}