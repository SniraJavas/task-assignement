using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Status.manager.Data.Interfaces;

namespace task.manager.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _statusRepository;

        public StatusController(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        // GET: api/Status
        [HttpGet]
        public async Task<ActionResult<IEnumerable<task.manager.data.Models.Status>>> GetStatuses()
        {
            return await _statusRepository.getStatuses();
        }

        // GET: api/Status/5
        [HttpGet("{id}")]
        public async Task<ActionResult<task.manager.data.Models.Status>> GetStatus(int id)
        {
            var status = await _statusRepository.GetStatusById(id);

            if (status.Value == null)
            {
                return NotFound();
            }

            return Ok(status);
        }

        // PUT: api/Status/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatus(int id, task.manager.data.Models.Status status)
        {
            if (id != status.Id)
            {
                return BadRequest();
            }

            try
            {
                _statusRepository.updateStatus(status);
                return Ok(status);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_statusRepository.Exist(status.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Status
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<task.manager.data.Models.Status>> PostStatus(task.manager.data.Models.Status status)
        {
      
            try
            {
                return await _statusRepository.createStatus(status);
            }
            catch (DbUpdateException)
            {
                if (_statusRepository.Exist(status.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
        }

        // DELETE: api/Status/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            var status = await _statusRepository.deleteStatus(id);
            if (status == null)
            {
                return NotFound();
            }

            return Ok(status);
        }
    }
}
