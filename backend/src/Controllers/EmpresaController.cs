using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.Services;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpPost("cadastro")]
        public IActionResult CadastrarEmpresa([FromBody] CadastroEmpresaRequest request)
        {
            try
            {
                var resposta = _empresaService.CadastrarEmpresa(request);
                return Ok(resposta);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
            catch (Exception ex)
            {
                // Aqui pode ser implementado log
                return StatusCode(500, new { erro = "Erro interno do servidor." });
            }
        }
    }
}
