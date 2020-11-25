﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOTEST.Controllers
{
    [Route("/me")]
    public class MeController : Controller
    {
        private IoContext Database;
        public MeController(IoContext userContext)
        {
            Database = userContext;
        }
        public async Task<ActionResult> IndexAsync()
        {
            DataControl control = new DataControl(HttpContext.Request.Cookies);
            if (!control.IsOk || !(await Database.Users.Where(x => x.Id == control.UserData.Id).AnyAsync())) { HttpContext.Response.Redirect("/login"); return View("Empty"); }

            ViewData.Add("Title", $"Тест - Личный кабинет");
            ViewData.Add("ParalaxOn", true);
            ViewData.Add("CSS", new List<string> { "css/Test.css" });
            ViewData.Add("JSU", new List<string> {  "js/VueComp.js" });
            ViewData.Add("JSD", new List<string> { "js/Me.js" });
            ViewData.Add("User", control.UserData);

            return View("Me");
        }

    }
}
