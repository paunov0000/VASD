﻿using Microsoft.AspNetCore.Mvc;

namespace WebStore.MVC.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
