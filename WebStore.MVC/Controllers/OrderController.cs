﻿using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
