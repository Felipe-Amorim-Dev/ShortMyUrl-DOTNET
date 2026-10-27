using ShortMyUrl.Domain.DTOs;

namespace ShortMyUrl.Domain.Interfaces.Services
{
    public interface IUrlDomainService
    {
        Task<string> Encurtar(UrlDTO dto);
        Task<string> Deletar(UrlDTO dto);
        Task<string?> Resolver(string codigo);
    }
}
