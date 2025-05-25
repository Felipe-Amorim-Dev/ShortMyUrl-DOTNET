using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortMyUrl.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TModel>
        where TModel : class
    {
        Task AddAsync(TModel model);        

        Task DeleteAsync(string nomeUrlOriginal);
    }
}
