using BCH.Application.Commands.Create;
using BCH.Application.Interfaces.Clients;
using BCH.Domain.Primitives;
using BCH.Application.Models;
using MediatR;
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
        protected readonly ISender Sender;

        public BchController(ILogger<BchController> logger, IBlockcypherClient client, ISender sender)
        {
            Sender = sender;
            _logger = logger;
            _client = client;
        }

        [HttpGet]
        [Route("get")]
        public async Task<BCHModel> GetAsync(BlockchainType type, CancellationToken cancellationToken)
        {
            var command = new CreateBchInfoCommand()
            {
                CreateAt = DateTime.UtcNow,
                Type = type
            };

            return await Sender.Send(command, cancellationToken);
            //    await _client.GetBCHAsync(type);
        }
    }
}
