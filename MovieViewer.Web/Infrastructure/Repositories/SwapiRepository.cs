using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieViewer.Web.Infrastructure.Repositories
{
    public class SwapiRepository : ISwapiRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<SwapiRepository> _logger;

        public SwapiRepository(IHttpClientFactory clientFactory, ILogger<SwapiRepository> logger)
        {
            _clientFactory = clientFactory;
            _logger = logger;
        }

        public async Task<SwapiResponse> GetMovies()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://swapi.dev/api/films/");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<SwapiResponse>(responseStream);
            }
            else
            {
                _logger.LogInformation($"Swapi request returned {response.StatusCode}.");
                throw new Exception("Api is not responding or incorrect url was provided.");
            }
        }
    }
}
