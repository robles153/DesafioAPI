using MediatR;
using DesafioAPI.Dominio.Repositorio;
using Microsoft.Extensions.Logging;

namespace DesafioAPI.Aplicacao.Usuarios.RemoverUsuario
{
    public class RemoverUsuarioHandler : IRequestHandler<RemoverUsuarioCommand, bool>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ILogger<RemoverUsuarioHandler> _logger;

        public RemoverUsuarioHandler(IUsuarioRepositorio usuarioRepositorio, ILogger<RemoverUsuarioHandler> logger)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _logger = logger;
        }

        public async Task<bool> Handle(RemoverUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Tentando remover usuário com ID: {Id}", request.Id);
                var removido = await _usuarioRepositorio.RemoverUsuarioAsync(request.Id);
                if (!removido)
                    _logger.LogWarning("Usuário não encontrado para remoção: {Id}", request.Id);
                else
                    _logger.LogInformation("Usuário removido com sucesso: {Id}", request.Id);
                return removido;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao remover usuário: {Id}", request.Id);
                throw;
            }
        }
    }
}
