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
            var mongoClient = new MongoClient("mongodb+srv://lunafortes:eQSkWaS3UGZTcKwP@testesluna.klyyulk.mongodb.net/?retryWrites=true&w=majority");
            services.AddSingleton<IMongoClient>(_ => mongoClient);
            services.AddScoped<IMongoRepository, MongoRepository>();
            services.AddScoped<IMongoService, MongoService>();
            return services;
        }
    }
}
