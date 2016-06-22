using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.Models;

namespace TaskManager.Controllers.Api
{
    public class ProjectsController : ApiController
    {
        private ApplicationDbContext _context;

        public ProjectsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/projects
        public IHttpActionResult GetProjects()
        {
            return Ok(_context.Projects.ToList());
        }

        // GET api/projects/1
        public IHttpActionResult GetProject(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            if (project == null)
                return NotFound();

            return Ok(project);
        }

        // POST api/projects
        [HttpPost]
        public IHttpActionResult CreateProject(Project project)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Projects.Add(project);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + project.Id), project);
        }

        //PUT api/projects/1
        [HttpPut]
        public IHttpActionResult EditProject(int id, Project project)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var projectInDb = _context.Projects.SingleOrDefault(p => p.Id == id);

            if (projectInDb == null)
                return NotFound();

            projectInDb.Name = project.Name;

            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/projects/1
        [HttpDelete]
        public IHttpActionResult DeleteProject(int id)
        {
            var projectInDb = _context.Projects.SingleOrDefault(p => p.Id == id);

            if (projectInDb == null)
                return NotFound();

            _context.Projects.Remove(projectInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
