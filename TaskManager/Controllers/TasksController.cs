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

            var priorities = _context.Priorities.ToList();
            var status = _context.Status.ToList();

            ViewBag.Priority = priorities;
            ViewBag.Status = status;


            ProjectTask task = new ProjectTask
            {
                ProjectId = id
            };

            return View("TaskForm", task);
        }

        public ActionResult Task(int id)
        {
            var task = _context.ProjectTasks.SingleOrDefault(t => t.Id == id);

            if (task == null)
                return HttpNotFound();

            var priorities = _context.Priorities.ToList();
            var status = _context.Status.ToList();

            ViewBag.Priority = priorities;
            ViewBag.Status = status;

            return View("TaskForm", task);
        }
    }
}