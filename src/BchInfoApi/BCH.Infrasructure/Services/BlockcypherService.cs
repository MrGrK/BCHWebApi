using BCH.Domain;
using BCH.Infrasructure.Models;
using BCH.Infrasructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BCH.Infrasructure.Services
{
    internal class BlockcypherService : IBlockcypherService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        private readonly Dictionary<BlockchainType, string> URIES = new Dictionary<BlockchainType, string>()
        {
            {BlockchainType.BTC, "/v1/btc/main"},
            {BlockchainType.ETH, "/v1/eth/main"},
            {BlockchainType.Dash, "/v1/dash/main"}
        };

        public BlockcypherService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            if (_httpClient.BaseAddress == null)
                throw new InvalidOperationException($"HttpClient.BaseAddress is not configured.");

            _jsonOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            _jsonOptions.Converters.Add(new JsonStringEnumConverter());
        }


        public async Task<BCHModel> GetBCHAsync(BlockchainType type, CancellationToken cancellationToken)
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
