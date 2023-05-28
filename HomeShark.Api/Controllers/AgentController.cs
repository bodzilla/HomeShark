using HomeShark.Core.Models;
using HomeShark.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeShark.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgentController : ControllerBase
    {
        private readonly ILogger<AgentController> _logger;
        private readonly DbSet<Agent> _repository;

        public AgentController(ILogger<AgentController> logger, HomeSharkContext context)
        {
            _logger = logger;
            _repository = context.Agents;
        }

        [HttpGet]
        public IEnumerable<Property> Get()
        {
            throw new NotImplementedException();
        }
    }
}