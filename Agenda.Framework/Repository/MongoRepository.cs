using Agenda.Framework.Model;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Agenda.Mongodb.Repository
{
    public class MongoRepository : IMongoRepository
    {
        private IMongoCollection<BsonAgenda> agendaCollection;
        private IMongoClient client;

        public MongoRepository( IMongoClient client)
        {
            this.agendaCollection = client.GetDatabase("Agenda").GetCollection<BsonAgenda>("Eventos");
            this.client = client;
        }


        public async Task<List<BsonAgenda>> GetDocumentsAsync(FilterDefinition<BsonAgenda> filter)
        {
            var documents = await agendaCollection.FindAsync(filter);
            return await documents.ToListAsync();
        }

        public async Task InsertDocumentAsync(BsonAgenda bson)
        {
            await agendaCollection.InsertOneAsync(bson);
        }

        public async Task DeleteByIdAsync(ObjectId id)
        {
            await agendaCollection.DeleteOneAsync<BsonAgenda>(_ => _.Id == id);
        }

        public async Task<BsonAgenda> GetSingleDocumentAsync(FilterDefinition<BsonAgenda> filter)
        {
            var documents = await agendaCollection.FindAsync(filter);
            return await documents.FirstOrDefaultAsync();
        }

        public async Task<BsonAgenda> FindAndReplaceOneAsync(FilterDefinition<BsonAgenda> filter, BsonAgenda bson)
        {
            return await agendaCollection.FindOneAndReplaceAsync(filter, bson);
        }
    }
}
