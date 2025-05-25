using MongoDB.Driver;
using ShortMyUrl.Domain.Entities;
using ShortMyUrl.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortMyUrl.Data.Repositories
{
    public class UrlRepository : BaseRepository<Url>, IUrlRepository
    {
        public UrlRepository(IMongoDatabase database) : base(database) 
        {
            
        }

        public virtual async Task<Url> GetByUrlOrigin(string urlOriginal)
        {
            var filter = Builders<Url>.Filter.Eq("UrlOriginal", urlOriginal);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }
    }
}
