using MediatR;
using DesafioAPI.Dominio.Entidades.Usuario;
using DesafioAPI.Aplicacao.Mappers;
using DesafioAPI.Dominio.Repositorio;
using DesafioAPI.Aplicacao.Servicos;
using Microsoft.Extensions.Logging;

namespace DesafioAPI.Aplicacao.Usuarios.ImportarUsuario
{
    public class ImportarUsuarioRandomHandler : IRequestHandler<ImportarUsuarioRandomCommand, Usuario>
    {
        private readonly RandomUserService _randomUserService;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ILogger<ImportarUsuarioRandomHandler> _logger;

        public ImportarUsuarioRandomHandler(
            RandomUserService randomUserService,
            IUsuarioRepositorio usuarioRepositorio,
            ILogger<ImportarUsuarioRandomHandler> logger)
        {
            _randomUserService = randomUserService;
            _usuarioRepositorio = usuarioRepositorio;
            _logger = logger;
        }

        public async Task<Usuario> Handle(ImportarUsuarioRandomCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Iniciando importação de usuário aleatório.");

                var randomUserDto = await _randomUserService.GetRandomUserAsync();
                if (randomUserDto == null)
                {
                    _logger.LogWarning("Não foi possível obter usuário da API.");
                    throw new Exception("Não foi possível obter usuário da API.");
                }

                var usuario = UsuarioMapper.FromRandomUserDto(randomUserDto);
                await _usuarioRepositorio.AdicionarAsync(usuario);

                _logger.LogInformation("Usuário importado com sucesso: {Email}", usuario.Email);

                return usuario;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao importar usuário aleatório.");
                throw; 
            }
        }
    }
}
