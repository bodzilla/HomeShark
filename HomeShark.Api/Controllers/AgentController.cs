using HomeShark.Core.Contracts.Services;
using HomeShark.Core.Dtos.Requests;
using HomeShark.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeShark.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgentController : ControllerBase
    {
        private readonly ILogger<AgentController> _logger;
        private readonly IAgentService _service;

        public AgentController(ILogger<AgentController> logger, IAgentService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                return Ok(await _service.GetAllAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting all {nameof(Agent)}");
                return BadRequest();
            }
        }

        [HttpGet("search/id/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var agent = await _service.GetByIdAsync(id);
                if (agent == null) return NotFound();
                return Ok(agent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting {nameof(Agent)} by ID");
                return BadRequest();
            }
        }

        [HttpGet("search/name/{name}")]
        public async Task<IActionResult> GetAllByContainsNameAsync(string name)
        {
            try
            {
                var agents = await _service.GetAllByContainsNameAsync(name);
                if (!agents.Any()) return NotFound();
                return Ok(await _service.GetAllByContainsNameAsync(name));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting {nameof(Agent)} by {nameof(Agent.Name)}");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddAgentRequest request)
        {
            try
            {
                return Ok(await _service.AddAsync(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding {nameof(Agent)}");
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateAgentRequest request)
        {
            try
            {
                return Ok(await _service.UpdateAsync(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating {nameof(Agent)}");
                return BadRequest();
            }
        }

        [HttpPatch("deactivate")]
        public async Task<IActionResult> SetInactiveAsync(int id)
        {
            try
            {
                return Ok(await _service.SetInactiveAsync(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error setting inactive {nameof(Agent)}");
                return BadRequest();
            }
        }
    }
}