using DesafioAPI.Dominio.Entidades.Usuario;
using DesafioAPI.Dominio.Repositorio;
using MediatR;
using Microsoft.Extensions.Logging;
using DesafioAPI.Aplicacao.Usuarios.UsuarioViewModels;

namespace DesafioAPI.Aplicacao.Usuarios.ListarUsuarios
{
    public class ListarUsuariosHandler : IRequestHandler<ListarUsuariosQuery, List<UsuarioViewModel>>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ILogger<ListarUsuariosHandler> _logger;

        public ListarUsuariosHandler(IUsuarioRepositorio usuarioRepositorio, ILogger<ListarUsuariosHandler> logger)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _logger = logger;
        }

        public async Task<List<UsuarioViewModel>> Handle(ListarUsuariosQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Listando usuários. Página: {PageNumber}, Tamanho: {PageSize}", request.PageNumber, request.PageSize);

            var usuarios = await _usuarioRepositorio.ListarTodosAsync(request.PageNumber, request.PageSize);

            _logger.LogInformation("Total de usuários retornados: {Count}", usuarios.Count);

            return usuarios.Select(u => new UsuarioViewModel(u)).ToList();
        }
    }
}
