using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DesafioAPI.Aplicacao.DTOs;

namespace DesafioAPI.Aplicacao.Servicos
{
    public class RandomUserService
    {
        private readonly HttpClient _httpClient;

        public RandomUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RandomUserDto?> GetRandomUserAsync()
        {
            var response = await _httpClient.GetAsync("https://randomuser.me/api/");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RandomUserResponseDto>(content);

            return result?.Results.FirstOrDefault();
        }
    }
}
