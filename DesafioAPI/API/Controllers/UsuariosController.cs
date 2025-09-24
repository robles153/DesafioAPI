using Microsoft.AspNetCore.Mvc;
using MediatR;
using DesafioAPI.Aplicacao.Usuarios.ImportarUsuario;
using DesafioAPI.Aplicacao.Usuarios.ListarUsuarios;
using DesafioAPI.Dominio.Entidades.Usuario;

namespace DesafioAPI.API.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuariosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("importar-random")]
        public async Task<ActionResult<Usuario>> ImportarRandom()
        {
            var usuario = await _mediator.Send(new ImportarUsuarioRandomCommand());
            return Ok(usuario);
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> ListarUsuarios([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var usuarios = await _mediator.Send(new ListarUsuariosQuery(pageNumber, pageSize));
            return Ok(usuarios);
        }
    }
}
