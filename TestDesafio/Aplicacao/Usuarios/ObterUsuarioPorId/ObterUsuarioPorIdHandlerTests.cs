using DesafioAPI.Aplicacao.Usuarios.ObterUsuarioPorId;
using TestDesafio.Builders.Usuarios;
using TestDesafio.Fakes;

namespace TestDesafio.Aplicacao.Usuarios.ObterUsuarioPorId
{
    [Trait(nameof(ObterUsuarioPorIdHandler), nameof(ObterUsuarioPorIdHandler.Handle))]
    public class ObterUsuarioPorIdHandlerTests
    {
        [Fact(DisplayName = "Handle - Sucesso ao buscar usuário por ID")]
        public async Task Handle_DeveRetornarUsuarioViewModel_QuandoUsuarioExiste()
        {
            // Arrange
            var usuarioId = Guid.NewGuid();
            var usuario = new UsuarioBuilder().ComId(usuarioId).Build();
            var fakeRepo = new FakeUsuarioRepositorio(usuario);
            var fakeLogger = new FakeLogger<ObterUsuarioPorIdHandler>();
            var handler = new ObterUsuarioPorIdHandler(fakeRepo, fakeLogger);
            var request = new ObterUsuarioPorIdQuery(usuarioId);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(usuarioId, result!.Id);
            Assert.Equal(usuario.Email, result.Email);
            Assert.Equal(usuario.Nome, result.Nome);
            Assert.Equal(usuario.Sobrenome, result.Sobrenome);
        }

        [Fact(DisplayName = "Handle - Retorna null quando usuário não encontrado")]
        public async Task Handle_DeveRetornarNull_QuandoUsuarioNaoExiste()
        {
            // Arrange
            var usuarioId = Guid.NewGuid();
            var fakeRepo = new FakeUsuarioRepositorio(new List<DesafioAPI.Dominio.Entidades.Usuario.Usuario>()); // Lista vazia
            var fakeLogger = new FakeLogger<ObterUsuarioPorIdHandler>();
            var handler = new ObterUsuarioPorIdHandler(fakeRepo, fakeLogger);
            var request = new ObterUsuarioPorIdQuery(usuarioId);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Null(result);
        }
    }
}
