using DesafioAPI.Aplicacao.DTOs;
using DesafioAPI.Aplicacao.Usuarios.AtualizarUsuario;
using DesafioAPI.Aplicacao.Usuarios.ImportarUsuario;
using DesafioAPI.Aplicacao.Usuarios.ListarUsuarios;
using DesafioAPI.Aplicacao.Usuarios.ObterUsuarioPorId;
using DesafioAPI.Aplicacao.Usuarios.RemoverUsuario;
using DesafioAPI.Aplicacao.Usuarios.UsuarioViewModels;
using DesafioAPI.Dominio.Entidades.Usuario;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("importar-usuario")]
        public async Task<ActionResult<Usuario>> ImportarRandom()
        {
            var usuario = await _mediator.Send(new ImportarUsuarioRandomCommand());
            return Ok(usuario);
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioViewModel>>> ListarUsuarios([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var usuarios = await _mediator.Send(new ListarUsuariosQuery(pageNumber, pageSize));
            return Ok(usuarios);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UsuarioViewModel>> ObterPorId(Guid id)
        {
            var usuario = await _mediator.Send(new ObterUsuarioPorIdQuery(id));
            if (usuario == null)
                return NotFound(new { mensagem = "Usuário não encontrado ou não existe." });
            return Ok(usuario);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] AtualizarUsuarioDto dto)
        {
            var command = new AtualizarUsuarioCommand(
                id,
                dto.Email ?? string.Empty,
                dto.Telefone ?? string.Empty,
                dto.Celular ?? string.Empty,
                dto.FotoUrl ?? string.Empty,
                dto.Nacionalidade ?? string.Empty
            );

            var atualizado = await _mediator.Send(command);
            if (!atualizado)
                return NotFound(new { mensagem = "Usuário não encontrado ou não existe." });
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            var removido = await _mediator.Send(new RemoverUsuarioCommand(id));
            if (!removido)
                return NotFound(new { mensagem = "Usuário não encontrado ou não existe." });

            return Ok(new { mensagem = $"Usuário de id {id} foi removido com sucesso." });
        }
    }
}
