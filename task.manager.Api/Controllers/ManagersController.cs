using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task.manager.Data.Interfaces;
using Task.manager.Data.Models;

namespace task.manager.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        private readonly IManagerRepository _managerRepository;
        public ManagersController(IManagerRepository managerRepository )
        {
            _managerRepository = managerRepository;
        }

        // GET: api/Managers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manager>>> GetManagers()
        {
            return await _managerRepository.getManagers();
        }

        // GET: api/Managers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manager>> GetManager(int id)
        {
            var manager = await _managerRepository.getManagerById(id);

            if (manager == null)
            {
                return NotFound();
            }

            return manager;
        }

        // PUT: api/Managers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManager(int id, Manager manager)
        {
            if (id != manager.Id)
            {
                return BadRequest();
            }

            try
            {
                await _managerRepository.updateManager(manager);
                return Ok(manager);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_managerRepository.Exist(manager.Id))
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

        // POST: api/Managers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Manager>> PostManager(Manager manager)
        {
           
            try
            {
                await _managerRepository.createManager(manager);
            }
            catch (DbUpdateException)
            {
                if (_managerRepository.Exist(manager.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetManager", new { id = manager.Id }, manager);
        }

        // DELETE: api/Managers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManager(int id)
        {
            var manager = await _managerRepository.deleteManager(id);
            if (manager == null)
            {
                return NotFound();
            }

            return Ok(manager);
        }
    }
}
