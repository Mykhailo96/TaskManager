using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class TasksController : Controller
    {
        private ApplicationDbContext _context;

        public TasksController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Tasks
        public ActionResult Index()
        {
            return View("List");
        }

        public ActionResult New(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            if (project == null)
                return HttpNotFound();

            List<Priority> priorities = _context.Priorities.ToList();
            var status = _context.Status.ToList();

            ViewBag.Priority = priorities;
            ViewBag.DefaultPriority = priorities[2];

            ViewBag.Status = status;
            ViewBag.DefaultStatus = status[2];

            ViewBag.PorjectId = id;

            return View("TaskForm");
        }
    }
}