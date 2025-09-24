using MediatR;
using DesafioAPI.Aplicacao.Usuarios.UsuarioViewModels;
using System;

namespace DesafioAPI.Aplicacao.Usuarios.ObterUsuarioPorId
{
    public class ObterUsuarioPorIdQuery : IRequest<UsuarioViewModel?>
    {
        public Guid Id { get; }

        public ObterUsuarioPorIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
