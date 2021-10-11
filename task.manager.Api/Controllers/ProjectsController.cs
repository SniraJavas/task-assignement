using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task.manager.data.Models;
using Task.manager.Data.Interfaces;
using Task.Project.Data.Interfaces;

namespace task.project.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IManagerRepository _managerRepository;

        public ProjectsController(IProjectRepository projectRepository, IManagerRepository managerRepository)
        {
            _projectRepository = projectRepository;
            _managerRepository = managerRepository;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            return await _projectRepository.getProjects();
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            var project = await _projectRepository.getProjectrById(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        // PUT: api/Projects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, Project project)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }

            var manager = _managerRepository.getManagerById(project.Id);

            if (manager == null) {
                return BadRequest("The selected Manager does not exist");
            }

            try { 
            
              
                await _projectRepository.updateProject(project);
                return Ok(project);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_projectRepository.Exist(project.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();

        }

        // POST: api/Projects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(Project project)
        {
            try
            {

                var manager = _managerRepository.getManagerById(project.Id);
                if (manager != null)
                {
                    await _projectRepository.createProject(project);
                    return Ok(project);
                }
                else {
                    return BadRequest("The selected Manager does not exist");
                }
                
            }
            catch (DbUpdateException)
            {
                if (_projectRepository.Exist(project.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProject", new { id = project.Id }, project);
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _projectRepository.deleteProject(id);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }


    }
}
