using MediatR;

namespace DesafioAPI.Aplicacao.Usuarios.RemoverUsuario
{
    public class RemoverUsuarioCommand : IRequest<bool>
    {
        public Guid Id { get; }

        public RemoverUsuarioCommand(Guid id)
        {
            Id = id;
        }
    }
}
