using DesafioAPI.Dominio.Entidades.Usuario;
using MediatR;

namespace DesafioAPI.Aplicacao.Usuarios.ListarUsuarios
{
    public class ListarUsuariosQuery : IRequest<List<Usuario>>
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
