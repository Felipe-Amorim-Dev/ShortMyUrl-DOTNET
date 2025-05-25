using ShortMyUrl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortMyUrl.Domain.Interfaces.Repositories
{
    public interface IUrlRepository : IBaseRepository<Url>
    {
        Task<Url> GetByUrlOrigin(string urlOriginal);
    }
}
