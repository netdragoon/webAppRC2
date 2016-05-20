using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppCoreRC2.Models;
using Canducci.Helpers;

namespace WebAppCoreRC2.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        protected void AddViewData()
        {
            var items = new object[]
            {
                new { Id = 1 , Name = "Ativo" },
                new { Id = 2 , Name = "Inativo" },
                new { Id = 3 , Name = "Bloqueado" }
            };
            var itemsSuper = new object[]
            {
                new { Id = 1 , Name = "Ativo" },
                new { Id = 2 , Name = "Inativo" },
                new { Id = 3 , Name = "Bloqueado" }
            };
            ViewData["Status"] = new RadioButtonList(items, "Id", "Name");
            ViewData["StatusSuper"] = new RadioButtonList(itemsSuper, "Id", "Name", 3);
        }

        [HttpGet()]
        public IActionResult Edit(int id)
        {
            Pessoa p = new Pessoa() { Id = 1, Nome = "People", Status = 1 };
            AddViewData();
            return View(p);
        }

        [HttpPost()]
        public IActionResult Edit(Pessoa p)
        {
            AddViewData();
            return View(p);
        }
    }
}