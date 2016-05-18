using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Canducci.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppCoreRC2.Controllers
{
    public class EstudosController : Controller
    {
        public IActionResult Index()
        {               
            return View();
        }

        public IActionResult Radio()
        {
           
            var items = new object[]
            {
                new {Name = "Item 1", Value = 1},
                new {Name = "Item 2", Value = 2},
                new {Name = "Item 3", Value = 3},
                new {Name = "Item 4", Value = 4},
                new {Name = "Item 5", Value = 5},
            };
            ViewData["status"] = new RadioButtonList(items, "Value", "Name", 3);
            return View();
        }
    }
}