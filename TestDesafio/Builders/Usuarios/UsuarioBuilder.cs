using DesafioAPI.Dominio.Entidades.Usuario;
using DesafioAPI.Dominio.Enuns;

namespace TestDesafio.Builders.Usuarios
{
    public class UsuarioBuilder
    {
        private Usuario _usuario = new Usuario
        {
            Id = Guid.NewGuid(),
            Nome = "Nome",
            Sobrenome = "Sobrenome",
            Email = "email@teste.com",
            NomeUsuario = "usuario",
            Pais = "Brasil",
            Genero = Genero.Masculino,
            DataNascimento = new DateTime(1990, 1, 1),
            Telefone = "123456789",
            Celular = "987654321",
            FotoUrl = "http://foto.com/foto.jpg",
            Nacionalidade = "BR"
        };

        public UsuarioBuilder ComId(Guid id)
        {
            _usuario.Id = id;
            return this;
        }

        public Usuario Build() => _usuario;
    }
}
