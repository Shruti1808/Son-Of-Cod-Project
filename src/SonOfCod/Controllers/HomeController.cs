﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SonOfCod.Controllers
{
    public class HomeController : Controller
    {
      [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}
