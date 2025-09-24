using DesafioAPI.Aplicacao.DTOs;
using DesafioAPI.Aplicacao.Usuarios.AtualizarUsuario;
using TestDesafio.Builders.Usuarios;
using TestDesafio.Fakes;

namespace TestDesafio.Aplicacao.Usuarios.AtualizarUsuario
{
    [Trait(nameof(AtualizarUsuarioHandler), nameof(AtualizarUsuarioHandler.Handle))]
    public class AtualizarUsuarioHandlerTests
    {
        [Fact(DisplayName = "Handle - Sucesso ao atualizar usuário")]
        public async Task Handle_DeveRetornarTrue_QuandoUsuarioAtualizadoComSucesso()
        {
            // Arrange
            var usuarioId = Guid.NewGuid();
            var usuario = new UsuarioBuilder().ComId(usuarioId).Build();
            var fakeRepo = new FakeUsuarioRepositorio(usuario);
            var fakeLogger = new FakeLogger<AtualizarUsuarioHandler>();
            var handler = new AtualizarUsuarioHandler(fakeRepo, fakeLogger);

            var dto = new AtualizarUsuarioDto
            {
                Email = "valido@email.com",
                Telefone = "(011)-123-4567",
                Celular = "(011)-987-6543",
                FotoUrl = "http://foto.com/foto.jpg",
                Nacionalidade = "BR"
            };

            var validator = new AtualizarUsuarioDtoValidator();
            var validationResult = validator.Validate(dto);
            Assert.True(validationResult.IsValid);

            var command = new AtualizarUsuarioCommand(
                usuarioId,
                dto.Email!,
                dto.Telefone!,
                dto.Celular!,
                dto.FotoUrl!,
                dto.Nacionalidade!
            );

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Handle - Retorna false quando usuário não existe")]
        public async Task Handle_DeveRetornarFalse_QuandoUsuarioNaoExiste()
        {
            // Arrange
            var usuarioId = Guid.NewGuid();
            var fakeRepo = new FakeUsuarioRepositorio(new System.Collections.Generic.List<DesafioAPI.Dominio.Entidades.Usuario.Usuario>()); // lista vazia
            var fakeLogger = new FakeLogger<AtualizarUsuarioHandler>();
            var handler = new AtualizarUsuarioHandler(fakeRepo, fakeLogger);

            var dto = new AtualizarUsuarioDto
            {
                Email = "valido@email.com",
                Telefone = "(011)-123-4567",
                Celular = "(011)-987-6543",
                FotoUrl = "http://foto.com/foto.jpg",
                Nacionalidade = "BR"
            };

            var command = new AtualizarUsuarioCommand(
                usuarioId,
                dto.Email!,
                dto.Telefone!,
                dto.Celular!,
                dto.FotoUrl!,
                dto.Nacionalidade!
            );

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result);
        }
    }
}
