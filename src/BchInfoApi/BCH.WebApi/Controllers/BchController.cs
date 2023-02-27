using BCH.Domain;
using BCH.Infrasructure.Clients.Interfaces;
using BCH.Infrasructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BCH.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BchController : ControllerBase
    {

        private readonly ILogger<BchController> _logger;
        private readonly IBlockcypherClient _client;

        public BchController(ILogger<BchController> logger, IBlockcypherClient client)
        {
            _logger = logger;
            _client = client;
        }

        [HttpGet]
        [Route("get")]
        public async Task<BCHModel> GetAsync(BlockchainType type)
        {
            return await _client.GetBCHAsync(type);
        }
    }
}
