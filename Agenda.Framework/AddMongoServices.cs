using Agenda.Mongodb.Repository;
using Agenda.Mongodb.Service;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Hub2b.MagazineLuiza.Auth.Framework
{
    public static class AddMongoServices
    {
        public static IServiceCollection AddMongoDependencies(this IServiceCollection services)
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            services.AddSingleton<IMongoClient>(_ => mongoClient);
            services.AddScoped<IMongoRepository, MongoRepository>();
            services.AddScoped<IMongoService, MongoService>();
            return services;
        }
    }
}
