using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: Projects
        public ActionResult Index()
        {
            return View("List");
        }

        public ActionResult New()
        {
            return View("ProjectForm");
        }

        public ActionResult Project(int? id)
        {
            return View(id);
        }
    }
}