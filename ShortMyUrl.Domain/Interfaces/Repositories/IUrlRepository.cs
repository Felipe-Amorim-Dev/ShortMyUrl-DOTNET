using ShortMyUrl.Domain.Entities;

namespace ShortMyUrl.Domain.Interfaces.Repositories
{
    public interface IUrlRepository : IBaseRepository<Url>
    {
        Task<Url?> GetByUrlOrigin(string urlOriginal);
        Task<Url?> GetByUrlNova(string urlNova);
    }
}
