using MediatR;
using DesafioAPI.Aplicacao.Usuarios.UsuarioViewModels;

namespace DesafioAPI.Aplicacao.Usuarios.ListarUsuarios
{
    public class ListarUsuariosQuery : IRequest<List<UsuarioViewModel>>
    {
        public int PageNumber { get; }
        public int PageSize { get; }

        public ListarUsuariosQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
