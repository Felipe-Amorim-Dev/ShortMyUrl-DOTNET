using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> EncurtarUrl(UrlDTO dto)
        {
            var url = await _urlDomainService.Encurtar(dto);

            return StatusCode(201, new
            {
                menssagem = "Url encurtada com sucesso!",
                url
            });
        }

        [HttpDelete("excluir")]
        public async Task<IActionResult> DeletarUrl(UrlDTO dto)
        {
            var url = await _urlDomainService.Deletar(dto);

            return StatusCode(200, new
            {
                menssagem = "Url removida com sucesso!",
                url
            });
        }
    }
}
