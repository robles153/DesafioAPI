using DesafioAPI.Aplicacao.Usuarios.ListarUsuarios;
using DesafioAPI.Dominio.Entidades.Usuario;
using TestDesafio.Builders.Usuarios;
using TestDesafio.Fakes;

namespace TestDesafio.Aplicacao.Usuarios.ListarUsuarios
{
    [Trait(nameof(ListarUsuariosHandler), nameof(ListarUsuariosHandler.Handle))]
    public class ListarUsuariosHandlerTests
    {
        [Fact(DisplayName = "Handle - Sucesso ao listar usuários")]
        public async Task Handle_DeveRetornarListaDeUsuarioViewModel_QuandoUsuariosExistem()
        {
            // Arrange
            var usuario1 = new UsuarioBuilder().ComId(Guid.NewGuid()).Build();
            var usuario2 = new UsuarioBuilder().ComId(Guid.NewGuid()).Build();
            var usuarios = new List<Usuario> { usuario1, usuario2 };

            var fakeRepo = new FakeUsuarioRepositorio(usuarios);
            var fakeLogger = new FakeLogger<ListarUsuariosHandler>();
            var handler = new ListarUsuariosHandler(fakeRepo, fakeLogger);
            var request = new ListarUsuariosQuery(pageNumber: 1, pageSize: 10);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal(usuario1.Id, result[0].Id);
            Assert.Equal(usuario2.Id, result[1].Id);
        }

        [Fact(DisplayName = "Handle - Retorna lista vazia quando não há usuários")]
        public async Task Handle_DeveRetornarListaVazia_QuandoNaoHaUsuarios()
        {
            // Arrange
            var fakeRepo = new FakeUsuarioRepositorio(new List<DesafioAPI.Dominio.Entidades.Usuario.Usuario>());
            var fakeLogger = new FakeLogger<ListarUsuariosHandler>();
            var handler = new ListarUsuariosHandler(fakeRepo, fakeLogger);
            var request = new ListarUsuariosQuery(pageNumber: 1, pageSize: 10);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}
