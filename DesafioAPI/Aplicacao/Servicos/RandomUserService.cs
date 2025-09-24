using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DesafioAPI.Aplicacao.DTOs;
using Microsoft.Extensions.Logging;

namespace DesafioAPI.Aplicacao.Servicos
{
    public class RandomUserService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<RandomUserService> _logger;

        public RandomUserService(HttpClient httpClient, ILogger<RandomUserService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<RandomUserDto?> GetRandomUserAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://randomuser.me/api/");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<RandomUserResponseDto>(content);

                return result?.Results.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao consumir a API Random User Generator.");
                throw;
            }
        }
    }
}
