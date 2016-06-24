using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.Models;
using TaskManager.Models.Dto;
using System.Data.Entity;
using AutoMapper;

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
            var projects = _context.Projects.ToList();

            return Ok(projects);
        }

        // GET api/projects/1
        public IHttpActionResult GetProject(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            if (project == null)
                return NotFound();

            var projectApi = new Project
            {
                Id = project.Id,
                Name = project.Name
            };

            var tasksInDb = _context.ProjectTasks
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .Where(t => t.Project.Id == id)
                .ToList();

            var tasks = tasksInDb.Select(Mapper.Map<ProjectTask, ProjectTaskDto>);

            projectApi.Tasks = tasks;

            return Ok(projectApi);
        }

        // POST api/projects
        [HttpPost]
        public IHttpActionResult CreateProject(Project project)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var newProject = new Project
            {
                Name = project.Name
            };

            _context.Projects.Add(newProject);
            _context.SaveChanges();

            return Ok();
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
