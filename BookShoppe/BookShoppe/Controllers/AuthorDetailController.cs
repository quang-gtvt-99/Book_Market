﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookShoppe.Controllers
{
    public class AuthorDetailController : Controller
    {
        public IActionResult AuthorDetail()
        {
            return View();
        }
    }
}