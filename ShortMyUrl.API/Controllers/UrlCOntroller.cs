using Microsoft.AspNetCore.Mvc;
using ShortMyUrl.Domain.DTOs;
using ShortMyUrl.Domain.Interfaces.Services;

namespace ShortMyUrl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlCOntroller : ControllerBase
    {
        private readonly IUrlDomainService _urlDomainService;

        public UrlCOntroller(IUrlDomainService urlDomainService)
        {
            _urlDomainService = urlDomainService;
        }

        [HttpPost("encurtar")]
        public async Task<IActionResult> EncurtarUrl([FromBody] UrlDTO dto)
        {
            try
            {
                var url = await _urlDomainService.Encurtar(dto);
                return StatusCode(201, new { mensagem = "URL encurtada com sucesso.", url });
            }
            catch (ArgumentException exception)
            {
                return BadRequest(new { mensagem = exception.Message });
            }
        }

        [HttpGet("/r/{codigo}")]
        public async Task<IActionResult> Redirecionar(string codigo)
        {
            var original = await _urlDomainService.Resolver(codigo);

            if (original == null)
            {
                return NotFound(new { mensagem = "Link não encontrado." });
            }

            return RedirectPermanent(original);
        }

        [HttpDelete("excluir")]
        public async Task<IActionResult> DeletarUrl([FromBody] UrlDTO dto)
        {
            try
            {
                var mensagem = await _urlDomainService.Deletar(dto);
                return Ok(new { mensagem });
            }
            catch (ArgumentException exception)
            {
                return BadRequest(new { mensagem = exception.Message });
            }
        }
    }
}
