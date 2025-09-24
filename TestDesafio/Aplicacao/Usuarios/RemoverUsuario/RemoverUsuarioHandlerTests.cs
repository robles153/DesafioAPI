using DesafioAPI.Aplicacao.Usuarios.RemoverUsuario;
using TestDesafio.Builders.Usuarios;
using TestDesafio.Fakes;

namespace TestDesafio.Aplicacao.Usuarios.RemoverUsuario
{
    [Trait(nameof(RemoverUsuarioHandler), nameof(RemoverUsuarioHandler.Handle))]
    public class RemoverUsuarioHandlerTests
    {
        [Fact(DisplayName = "Handle - Sucesso ao remover usuário existente")]
        public async Task Handle_DeveRetornarTrue_QuandoUsuarioExiste()
        {
            // Arrange
            var usuarioId = Guid.NewGuid();
            var usuario = new UsuarioBuilder().ComId(usuarioId).Build();
            var fakeRepo = new FakeUsuarioRepositorio(new List<DesafioAPI.Dominio.Entidades.Usuario.Usuario> { usuario });
            var fakeLogger = new FakeLogger<RemoverUsuarioHandler>();
            var handler = new RemoverUsuarioHandler(fakeRepo, fakeLogger);
            var request = new RemoverUsuarioCommand(usuarioId);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.True(result);            
            var usuarioRemovido = await fakeRepo.ObterPorIdAsync(usuarioId);
            Assert.Null(usuarioRemovido);
        }

        [Fact(DisplayName = "Handle - Retorna false quando usuário não existe")]
        public async Task Handle_DeveRetornarFalse_QuandoUsuarioNaoExiste()
        {
            // Arrange
            var usuarioId = Guid.NewGuid();
            var fakeRepo = new FakeUsuarioRepositorio(new List<DesafioAPI.Dominio.Entidades.Usuario.Usuario>()); // lista vazia
            var fakeLogger = new FakeLogger<RemoverUsuarioHandler>();
            var handler = new RemoverUsuarioHandler(fakeRepo, fakeLogger);
            var request = new RemoverUsuarioCommand(usuarioId);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Handle - Lança exceção e loga erro ao falhar na remoção")]
        public async Task Handle_DeveLancarExcecao_QuandoRepositorioLancaExcecao()
        {
            // Arrange
            var usuarioId = Guid.NewGuid();
            var fakeRepo = new FakeUsuarioRepositorioException();
            var fakeLogger = new FakeLogger<RemoverUsuarioHandler>();
            var handler = new RemoverUsuarioHandler(fakeRepo, fakeLogger);
            var request = new RemoverUsuarioCommand(usuarioId);

            // Act & Assert
            var ex = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                handler.Handle(request, CancellationToken.None)
            );
            Assert.Equal("Erro simulado no repositório", ex.Message);
        }
    }
}
