using HomeShark.Core.Models;
using HomeShark.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace HomeShark.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;
        private readonly HomeSharkContext _context;

        public ApiController(ILogger<ApiController> logger, HomeSharkContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Property> Get()
        {
            throw new NotImplementedException();
        }
    }
}