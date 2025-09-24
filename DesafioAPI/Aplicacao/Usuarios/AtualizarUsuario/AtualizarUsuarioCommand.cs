using MediatR;
using System;

namespace DesafioAPI.Aplicacao.Usuarios.AtualizarUsuario
{
    public class AtualizarUsuarioCommand : IRequest<bool>
    {
        public Guid Id { get; }
        public string Email { get; }
        public string Telefone { get; }
        public string Celular { get; }
        public string FotoUrl { get; }
        public string Nacionalidade { get; }

        public AtualizarUsuarioCommand(Guid id, string email, string telefone, string celular, string fotoUrl, string nacionalidade)
        {
            Id = id;
            Email = email;
            Telefone = telefone;
            Celular = celular;
            FotoUrl = fotoUrl;
            Nacionalidade = nacionalidade;
        }
    }
}
