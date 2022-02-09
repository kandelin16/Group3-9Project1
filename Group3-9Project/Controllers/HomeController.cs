using Group3_9Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Quadrant()
        {
            var TaskEntries = TeContext.TaskEntries
                .Include(x => x.Category)
                .Where(x => x.Completed == false)
                .ToList();

            return View(TaskEntries);
        }

        [HttpGet]
        public IActionResult Edit(int taskid)
        {
            ViewBag.Category = TeContext.Category.ToList();
            var task = TeContext.TaskEntries.Single(x => x.TaskId == taskid);
            return View("Add", task);
        }

        [HttpPost]
        public IActionResult Edit (TaskEntry te)
        {
            TeContext.Update(te);
            TeContext.SaveChanges();
            return RedirectToAction("Quadrant");

        }

    }
}
