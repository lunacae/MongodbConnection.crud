using Agenda.Framework.Model;
using Agenda.Mongodb.Repository;
using Agenda.Mongodb.Service;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Moq;

namespace Agenda.Tests
{
    public class Mocks
    {
        public static BsonAgenda bsonAgendaFake => new()
        {
            CreationDate= DateTime.Now,
            EventDate = "25-03-2023",
            Description = "Fake test",
            Duration = 2,
            EventHour = "14",
            EventName = "Fake test",
            Guests = new List<string>()
            {
                "Teste"
            }
        };

        public static Mock<IMongoRepository> AuthMongoMock()
        {
            var mockDbaMongo = new Mock<IMongoRepository>();

            mockDbaMongo.Setup(x => x.FindAndReplaceOneAsync(
                It.IsAny<FilterDefinition<BsonAgenda>>(), bsonAgendaFake))
                .Returns(Task.FromResult(bsonAgendaFake));

            List<BsonAgenda> list = new List<BsonAgenda>
            {
                bsonAgendaFake
            };

            mockDbaMongo.Setup(x => x.GetDocumentsAsync(
                It.IsAny<FilterDefinition<BsonAgenda>>()))
                .Returns(Task.FromResult(list));

            mockDbaMongo.Setup(x => x.InsertDocumentAsync(
                It.IsAny<BsonAgenda>()));

            return mockDbaMongo;
        }

        public static IServiceProvider BuildServiceProvider(Mock<IMongoRepository> mockAuthMongo)
        {
            var mockMongoClient = new Mock<IMongoClient>();

            IServiceCollection services = new ServiceCollection();
            services.AddLogging();
            services.AddScoped<IMongoRepository>(x => mockAuthMongo.Object);
            services.AddScoped<IMongoClient>(c => mockMongoClient.Object);
            services.AddScoped<IMongoService, MongoService>();
            services.AddMemoryCache();

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
