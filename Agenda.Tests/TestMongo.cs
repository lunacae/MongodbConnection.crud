using Agenda.Mongodb.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Agenda.Tests
{
    public class TestMongo
    {
        [Fact]
        public async Task TestInsert()
        {
            var mockAuthMongo = Mocks.AuthMongoMock();
            IServiceProvider serviceProvider = Mocks.BuildServiceProvider(mockAuthMongo);
            var mongoService = serviceProvider.GetRequiredService<IMongoService>();
            var documents = await mongoService.GetEventsByEventData("01-01-2020");
            Assert.NotNull(documents);
        }
    }
}