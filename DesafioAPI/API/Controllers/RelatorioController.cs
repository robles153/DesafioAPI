using DesafioAPI.Aplicacao.Servicos;
using DesafioAPI.Aplicacao.Usuarios.ListarUsuarios;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RelatorioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("relatorio-excel")]
        public async Task<IActionResult> ExportarRelatorioExcel([FromServices] ExportacaoUsuarioExcelService excelService)
        {            
            var usuarios = await _mediator.Send(new ListarUsuariosQuery(1, int.MaxValue));

            var excelBytes = excelService.GerarExcel(usuarios);

            return File(excelBytes,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "relatorio-usuarios.xlsx");
        }
    }
}
