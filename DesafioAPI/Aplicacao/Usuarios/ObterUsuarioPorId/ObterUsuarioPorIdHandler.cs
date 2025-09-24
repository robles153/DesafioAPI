using MediatR;
using DesafioAPI.Dominio.Repositorio;
using DesafioAPI.Aplicacao.Usuarios.UsuarioViewModels;
using Microsoft.Extensions.Logging;

namespace DesafioAPI.Aplicacao.Usuarios.ObterUsuarioPorId
{
    public class ObterUsuarioPorIdHandler : IRequestHandler<ObterUsuarioPorIdQuery, UsuarioViewModel?>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ILogger<ObterUsuarioPorIdHandler> _logger;

        public ObterUsuarioPorIdHandler(IUsuarioRepositorio usuarioRepositorio, ILogger<ObterUsuarioPorIdHandler> logger)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _logger = logger;
        }

        public async Task<UsuarioViewModel?> Handle(ObterUsuarioPorIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Buscando usuário por ID: {Id}", request.Id);

                var usuario = await _usuarioRepositorio.ObterPorIdAsync(request.Id);

                if (usuario == null)
                {
                    _logger.LogWarning("Usuário não encontrado para o ID: {Id}", request.Id);
                    return null;
                }

                _logger.LogInformation("Usuário encontrado: {Email}", usuario.Email);
                return new UsuarioViewModel(usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar usuário por ID: {Id}", request.Id);
                throw;
            }
        }
    }
}
