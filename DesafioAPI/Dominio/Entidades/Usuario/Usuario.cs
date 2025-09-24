using System.ComponentModel.DataAnnotations;
using DesafioAPI.Dominio.Enuns;

namespace DesafioAPI.Dominio.Entidades.Usuario
{
    public class Usuario
    {
        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public string Sobrenome { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string NomeUsuario { get; set; } = string.Empty;

        [Required]
        public string Pais { get; set; } = string.Empty;

        [Required]
        public Genero Genero { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        public string Telefone { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;
        public string FotoUrl { get; set; } = string.Empty;
        public string Nacionalidade { get; set; } = string.Empty;

        public void AtualizarDadosUsuario(string email, string telefone, string celular, string fotoUrl, string nacionalidade)
        {
            Email = email;
            Telefone = telefone;
            Celular = celular;
            FotoUrl = fotoUrl;
            Nacionalidade = nacionalidade;
        }
    }
}
