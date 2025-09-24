using System.Text.Json.Serialization;

namespace DesafioAPI.Aplicacao.DTOs
{
    public class RandomUserResponseDto
    {
        [JsonPropertyName("results")]
        public List<RandomUserDto> Results { get; set; } = new();
    }

    public class RandomUserDto
    {
        [JsonPropertyName("gender")]
        public string Gender { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public NameDto Name { get; set; } = new();

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("login")]
        public LoginDto Login { get; set; } = new();

        [JsonPropertyName("dob")]
        public DobDto Dob { get; set; } = new();

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = string.Empty;

        [JsonPropertyName("cell")]
        public string Cell { get; set; } = string.Empty;

        [JsonPropertyName("picture")]
        public PictureDto Picture { get; set; } = new();

        [JsonPropertyName("nat")]
        public string Nat { get; set; } = string.Empty;

        [JsonPropertyName("location")]
        public LocationDto Location { get; set; } = new();
    }

    public class NameDto
    {
        [JsonPropertyName("first")]
        public string First { get; set; } = string.Empty;

        [JsonPropertyName("last")]
        public string Last { get; set; } = string.Empty;
    }

    public class LoginDto
    {
        [JsonPropertyName("username")]
        public string Username { get; set; } = string.Empty;
    }

    public class DobDto
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
    }

    public class PictureDto
    {
        [JsonPropertyName("large")]
        public string Large { get; set; } = string.Empty;
    }

    public class LocationDto
    {
        [JsonPropertyName("country")]
        public string Country { get; set; } = string.Empty;
    }
}