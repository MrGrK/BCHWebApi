using BCH.Domain;
using BCH.Infrasructure.Clients.Interfaces;
using BCH.Infrasructure.Models;
using BCH.Infrasructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace BCH.Infrasructure.Clients
{
    public class BlockcypherClient : IBlockcypherClient
    {
        //private readonly IBlockcypherService _blockcypherService;
        private readonly JsonSerializerOptions _jsonOptions;
        private readonly HttpClient _httpClient;
        private readonly Dictionary<BlockchainType, string> URIES = new Dictionary<BlockchainType, string>()
        {
            {BlockchainType.BTC, "/v1/btc/main"},
            {BlockchainType.ETH, "/v1/eth/main"},
            {BlockchainType.Dash, "/v1/dash/main"}
        };

        public Uri ApiBaseUri { get; private set; }

        public BlockcypherClient(HttpClient httpClient)
        {
            if (httpClient.BaseAddress == null)
                throw new InvalidOperationException($"HttpClient.BaseAddress is not configured.");

            _httpClient= httpClient;

            ApiBaseUri = httpClient.BaseAddress;


            _jsonOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            _jsonOptions.Converters.Add(new JsonStringEnumConverter());
        }

        public async Task<BCHModel?> GetBCHAsync(BlockchainType type, CancellationToken cancellationToken = default)
        {
            return
                await _httpClient.GetFromJsonAsync<BCHModel>(
                    URIES.GetValueOrDefault(type),
                    _jsonOptions,
                    cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
