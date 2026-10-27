using MongoDB.Driver;
using ShortMyUrl.Domain.Entities;
using ShortMyUrl.Domain.Interfaces.Repositories;

namespace ShortMyUrl.Data.Repositories
{
    public class UrlRepository : BaseRepository<Url>, IUrlRepository
    {
        public UrlRepository(IMongoDatabase database) : base(database)
        {
        }

        public virtual Task<Url?> GetByUrlOrigin(string urlOriginal)
        {
            var filter = Builders<Url>.Filter.Eq(item => item.UrlOriginal, urlOriginal);
            return _collection.Find(filter).FirstOrDefaultAsync();
        }

        public virtual Task<Url?> GetByUrlNova(string urlNova)
        {
            var filter = Builders<Url>.Filter.Eq(item => item.UrlNova, urlNova);
            return _collection.Find(filter).FirstOrDefaultAsync();
        }
    }
}
