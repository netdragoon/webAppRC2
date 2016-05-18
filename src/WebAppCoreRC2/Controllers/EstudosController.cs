using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace WebAppCoreRC2.Controllers
{
    public class EstudosController : Controller
    {
        public IActionResult Index()
        {               
            return View();
        }
    }
}