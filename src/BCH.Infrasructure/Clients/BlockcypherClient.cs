using BCH.Application.Models;
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
using BCH.Domain.Primitives;
using BCH.Application.Interfaces.Clients;
using BCH.Infrasructure.Configuration.Options;

namespace BCH.Infrasructure.Clients
{
    public class BlockcypherClient : IBlockcypherClient
    {
        private readonly JsonSerializerOptions _jsonOptions;
        private readonly HttpClient _httpClient;
        private readonly Dictionary<BlockchainType, string> _uries;

        public BlockcypherClient(HttpClient httpClient, BlockcyApiSettings settings)
        {
            if (httpClient.BaseAddress == null)
                throw new InvalidOperationException($"HttpClient.BaseAddress is not configured.");

            _httpClient= httpClient;

            _uries = new Dictionary<BlockchainType, string>()
            {
                {BlockchainType.BTC, settings.Btc},
                {BlockchainType.ETH, settings.Eth},
                {BlockchainType.Dash, settings.Dash}
            };

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
                    _uries.GetValueOrDefault(type),
                    _jsonOptions,
                    cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
