using MongoDB.Driver;

namespace ShortMyUrl.API.Extensions
{
    /// <summary>
    /// Classe de extensão para configurar a conexão de banco de dados
    /// do MongoDB (capturando a connectionstring)
    /// </summary>
    public static class MongoDBExtension
    {
        public static void AddMongoDB(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["MongoDbSettings:ConnectionString"];
            var databaseName = configuration["MongoDbSettings:Database"];

            var mongoClient = new MongoClient(connectionString);

            services.AddSingleton<IMongoClient>(mongoClient);
            services.AddSingleton(sp =>
                mongoClient.GetDatabase(databaseName));
        }        
    }
}
