using DesafioAPI.Dominio.Entidades.Usuario;

namespace DesafioAPI.Aplicacao.Usuarios.UsuarioViewModels
{
    public class UsuarioViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string NomeUsuario { get; set; } = string.Empty;
        public string Pais { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public string DataNascimento { get; set; } = string.Empty; // Alterado para string
        public string Telefone { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;
        public string FotoUrl { get; set; } = string.Empty;
        public string Nacionalidade { get; set; } = string.Empty;

        public UsuarioViewModel(Usuario usuario)
        {
            Id = usuario.Id;
            Nome = usuario.Nome;
            Sobrenome = usuario.Sobrenome;
            Email = usuario.Email;
            NomeUsuario = usuario.NomeUsuario;
            Pais = usuario.Pais;
            Genero = usuario.Genero.ToString();
            DataNascimento = usuario.DataNascimento.ToString("dd/MM/yyyy"); // Formatação aplicada
            Telefone = usuario.Telefone;
            Celular = usuario.Celular;
            FotoUrl = usuario.FotoUrl;
            Nacionalidade = usuario.Nacionalidade;
        }
    }
}
