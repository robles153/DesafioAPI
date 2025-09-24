using DesafioAPI.Aplicacao.DTOs;
using DesafioAPI.Aplicacao.Usuarios.ImportarUsuario;
using DesafioAPI.Dominio.Entidades.Usuario;
using TestDesafio.Fakes;

namespace TestDesafio.Aplicacao.Usuarios.ImportarUsuarioRandom
{
    [Trait(nameof(ImportarUsuarioRandomHandler), nameof(ImportarUsuarioRandomHandler.Handle))]
    public class ImportarUsuarioRandomHandlerTests
    {
        [Fact(DisplayName = "Handle - Sucesso ao importar usuário aleatório")]
        public async Task Handle_DeveRetornarUsuario_QuandoRandomUserDtoValido()
        {
            // Arrange
            var randomUserDto = new RandomUserDto
            {
                Gender = "male",
                Name = new NameDto { First = "John", Last = "Doe" },
                Email = "john.doe@email.com",
                Login = new LoginDto { Username = "johndoe" },
                Dob = new DobDto { Date = DateTime.Parse("1990-01-01") },
                Phone = "123456789",
                Cell = "987654321",
                Picture = new PictureDto { Large = "http://foto.com/foto.jpg" },
                Nat = "BR",
                Location = new LocationDto { Country = "Brasil" }
            };

            var fakeRandomUserService = new FakeRandomUserService(randomUserDto);
            var fakeRepo = new FakeUsuarioRepositorio(new System.Collections.Generic.List<Usuario>());
            var fakeLogger = new FakeLogger<ImportarUsuarioRandomHandler>();
            var handler = new ImportarUsuarioRandomHandler(fakeRandomUserService, fakeRepo, fakeLogger);
            var request = new ImportarUsuarioRandomCommand();

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(randomUserDto.Email, result.Email);
            Assert.Equal(randomUserDto.Name.First, result.Nome);
            Assert.Equal(randomUserDto.Name.Last, result.Sobrenome);
            Assert.Equal(randomUserDto.Login.Username, result.NomeUsuario);
            Assert.Equal(randomUserDto.Location.Country, result.Pais);
            Assert.Equal(randomUserDto.Nat, result.Nacionalidade);
        }

        [Fact(DisplayName = "Handle - Lança exceção quando RandomUserService retorna null")]
        public async Task Handle_DeveLancarExcecao_QuandoRandomUserServiceRetornaNull()
        {
            // Arrange
            var fakeRandomUserService = new FakeRandomUserService(null); // retorna null
            var fakeRepo = new FakeUsuarioRepositorio(new System.Collections.Generic.List<DesafioAPI.Dominio.Entidades.Usuario.Usuario>());
            var fakeLogger = new FakeLogger<ImportarUsuarioRandomHandler>();
            var handler = new ImportarUsuarioRandomHandler(fakeRandomUserService, fakeRepo, fakeLogger);
            var request = new ImportarUsuarioRandomCommand();

            // Act & Assert
            var ex = await Assert.ThrowsAsync<Exception>(() => handler.Handle(request, CancellationToken.None));
            Assert.Equal("Não foi possível obter usuário da API.", ex.Message);
        }
    }
}
