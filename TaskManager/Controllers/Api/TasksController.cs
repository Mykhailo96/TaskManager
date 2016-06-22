using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.Models;
using System.Data.Entity;

namespace TaskManager.Controllers.Api
{
    public class TasksController : ApiController
    {
        private ApplicationDbContext _context;

        public TasksController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/tasks
        public IHttpActionResult GetTasks()
        {
            return Ok(_context.ProjectTasks.Include(t => t.Status).Include(t => t.Priority).ToList());
        }

        // GET api/tasks/1
        public IHttpActionResult GetTask(int id)
        {
            var task = _context.ProjectTasks.Include(t => t.Status).Include(t => t.Priority).SingleOrDefault(t => t.Id == id);

            if (task == null)
                return NotFound();

            return Ok(task);
        }

        // POST api/tasks
        [HttpPost]
        public IHttpActionResult CreateTask(ProjectTask task)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.ProjectTasks.Add(task);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + task.Id), task);
        }

        //PUT api/tasks/1
        [HttpPut]
        public IHttpActionResult EditTask(int id, ProjectTask task)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var taskInDb = _context.ProjectTasks.SingleOrDefault(t => t.Id == id);

            if (taskInDb == null)
                return NotFound();

            taskInDb.Name = task.Name;

            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/tasks/1
        [HttpDelete]
        public IHttpActionResult DeleteProject(int id)
        {
            var taskInDb = _context.ProjectTasks.SingleOrDefault(t => t.Id == id);

            if (taskInDb == null)
                return NotFound();

            _context.ProjectTasks.Remove(taskInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
