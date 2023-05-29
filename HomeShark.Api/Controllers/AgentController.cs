using HomeShark.Core.Dtos.Requests;
using HomeShark.Core.Models;
using HomeShark.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeShark.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpGet("search/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                return Ok(await _service.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting {nameof(Agent)} by ID");
                return BadRequest();
            }
        }

        [HttpGet("search/{name}")]
        public async Task<IActionResult> GetAllByContainsNameAsync(string name)
        {
            try
            {
                return Ok(await _service.GetAllByContainsNameAsync(name));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting {nameof(Agent)} by {nameof(Agent.Name)}");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AgentRequest agentRequest)
        {
            try
            {
                return Ok(await _service.AddAsync(agentRequest));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding {nameof(Agent)}");
                return BadRequest();
            }
        }
    }
}