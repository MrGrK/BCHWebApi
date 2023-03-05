using BCH.Application.Commands.Create;
using BCH.Application.Interfaces.Clients;
using BCH.Domain.Primitives;
using BCH.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BCH.Application.Queries.GetByDateTime;
using BCH.WebApi.Request;

namespace BCH.WebApi.Controllers
{
    [Route("api/bch")]
    [ApiController]
    public class BchController : ControllerBase
    {

        private readonly ILogger<BchController> _logger;
        protected readonly ISender Sender;

        public BchController(ILogger<BchController> logger, ISender sender)
        {
            Sender = sender;
            _logger = logger;
        }

        /// <summary>
        /// Get blockchain info from Blockcypher Client and store it in DB
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("fecth")]
        public async Task<BCHModel> FillAndFetchAsync(PutBchRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateBchInfoCommand()
            {
                CreateAt = DateTime.UtcNow,
                Type = request.BlockChainType
            };

            return await Sender.Send(command, cancellationToken);
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult> GetByTypeAsync(BlockchainType type, CancellationToken cancellationToken)
        {
            var command = new GetByTimestampQuery()
            {
                Type = type
            };

            var result = await Sender.Send(command, cancellationToken);
            return result.Count() > 0 ? Ok(result): NotFound();
        }
    }
}
