using MediatR;
using DesafioAPI.Dominio.Entidades.Usuario;

namespace DesafioAPI.Aplicacao.Usuarios.ImportarUsuario
{
    public class ImportarUsuarioRandomCommand : IRequest<Usuario>
    {
    }
}
