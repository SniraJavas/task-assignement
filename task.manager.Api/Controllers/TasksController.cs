using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task.manager.Data.Interfaces;
using Task.Project.Data.Interfaces;

namespace task.manager.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IManagerRepository _managerRepository;
        private readonly IProjectRepository _projectRepossitory;

        public TasksController(ITaskRepository taskRepository, IManagerRepository managerRepository, IProjectRepository projectRepossitory)
        {
            _taskRepository = taskRepository;
            _managerRepository = managerRepository;
            _projectRepossitory = projectRepossitory;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<task.manager.data.Models.Task>>> GetTasks()
        {
            return await _taskRepository.getTasks();
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<task.manager.data.Models.Task>> GetTask(int id)
        {
            var task = await _taskRepository.GetTaskById(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        // PUT: api/Tasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, task.manager.data.Models.Task task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            var projectExist = _projectRepossitory.Exist(task.ProjectId);
            var managerExist = _managerRepository.Exist(task.ManagerId);

            if (!projectExist || !managerExist)
            {
                return BadRequest(" Manager/Project selected do not exist. Ensure to pass existing Ids");
            }


            try
            {
                var result = await _taskRepository.updateTask(task);
                if (result != null)
                {
                    return Ok(task);
                }
                else {
                    return BadRequest();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_taskRepository.Exist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Tasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<task.manager.data.Models.Task>> PostTask(task.manager.data.Models.Task task)
        {
            
            try
            {
                var projectExist = _projectRepossitory.Exist(task.ProjectId);
                var managerExist = _managerRepository.Exist(task.ManagerId);

                if (!projectExist || !managerExist) {
                    return BadRequest(" Manager/Project selected do not exist. Ensure to pass existing Ids");
                }
                
                task = await _taskRepository.createTask(task);
                if (task != null)
                {
                    return CreatedAtAction("GetTask", new { id = task.Id }, task);
                }
                else {
                    return BadRequest();
                }

            }
            catch (DbUpdateException)
            {
                if (_taskRepository.Exist(task.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var worker = await _taskRepository.deleteTask(id);
            if (worker == null)
            {
                return NotFound();
            }

            return Ok(worker);
        }
    }
}
