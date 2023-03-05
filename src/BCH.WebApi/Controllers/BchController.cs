using BCH.Application.Commands.Create;
using BCH.Application.Interfaces.Clients;
using BCH.Domain.Primitives;
using BCH.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BCH.Application.Queries.GetByDateTime;
using BCH.WebApi.Request;
using BCH.Application.Queries.GetAll;

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

        /// <summary>
        /// Get blockchain info by type in desc order
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get")]
        public async Task<ActionResult> GetByTypeAsync(BlockchainType type, CancellationToken cancellationToken)
        {
            var query = new GetByTypeQuery()
            {
                Type = type
            };

            var result = await Sender.Send(query, cancellationToken);
            return result.Count() > 0 ? Ok(result): NotFound();
        }

        /// <summary>
        /// Get all blockchain info in desc order
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get/all")]
        public async Task<ActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var query = new GetAllQuery();

            var result = await Sender.Send(query, cancellationToken);
            return result.Count() > 0 ? Ok(result) : NotFound();
        }
    }
}
