using MongoDB.Driver;
using ShortMyUrl.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortMyUrl.Data.Repositories
{
    public abstract class BaseRepository<TModel> : IBaseRepository<TModel>
        where TModel : class
    {
        protected readonly IMongoCollection<TModel> _collection;

        protected BaseRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<TModel>(typeof(TModel).Name);
        }

        public virtual async Task AddAsync(TModel model)
        {
            await _collection.InsertOneAsync(model);
        }

        public async Task DeleteAsync(string nomeUrlOriginal)
        {
            var filter = Builders<TModel>.Filter.Eq("UrlOriginal", nomeUrlOriginal);
            await _collection.DeleteOneAsync(filter);
        }
    }
}
