﻿using Microsoft.AspNetCore.Mvc;

namespace WebStore.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
