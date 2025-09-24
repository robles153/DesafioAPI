using MediatR;
using DesafioAPI.Dominio.Entidades.Usuario;
using DesafioAPI.Dominio.Repositorio;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioAPI.Aplicacao.Usuarios.AtualizarUsuario
{
    public class AtualizarUsuarioHandler : IRequestHandler<AtualizarUsuarioCommand, bool>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ILogger<AtualizarUsuarioHandler> _logger;

        public AtualizarUsuarioHandler(IUsuarioRepositorio usuarioRepositorio, ILogger<AtualizarUsuarioHandler> logger)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _logger = logger;
        }

        public async Task<bool> Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = new Usuario
                {
                    Id = request.Id,
                    Email = request.Email,
                    Telefone = request.Telefone,
                    Celular = request.Celular,
                    FotoUrl = request.FotoUrl,
                    Nacionalidade = request.Nacionalidade
                };

                var atualizado = await _usuarioRepositorio.AtualizarUsuarioAsync(usuario);

                if (!atualizado)
                    _logger.LogWarning("Usuário não encontrado para atualização: {Id}", request.Id);
                else
                    _logger.LogInformation("Usuário atualizado com sucesso: {Id}", request.Id);

                return atualizado;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar usuário: {Id}", request.Id);
                throw;
            }
        }
    }
}
