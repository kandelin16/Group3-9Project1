using Group3_9Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Group3_9Project.Controllers
{
    public class HomeController : Controller
    {
      
        private TaskEntryContext TeContext { get; set; }
        public HomeController(TaskEntryContext someName)
        {
            TeContext = someName;
        }

       

        public IActionResult Index()
        {
            return View();
        }
       
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Category = TeContext.Category.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Add(TaskEntry te)
        {
            if (ModelState.IsValid)
            {
                TeContext.Add(te);
                TeContext.SaveChanges();
                return View("Confirmation", te);
            } else
            {
                ViewBag.Category = TeContext.Category.ToList();
                return View(te);
            }
        }


    }
}
