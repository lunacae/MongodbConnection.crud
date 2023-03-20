using Agenda.Framework.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Agenda.Mongodb.Repository
{
    public interface IMongoRepository
    {
        Task<List<BsonAgenda>> GetDocumentsAsync(FilterDefinition<BsonAgenda> filter);
        Task<BsonAgenda> GetSingleDocumentAsync(FilterDefinition<BsonAgenda> filter);
        Task InsertDocumentAsync(BsonAgenda bson);
        Task DeleteByIdAsync(ObjectId id);
        Task<BsonAgenda> FindAndReplaceOneAsync(FilterDefinition<BsonAgenda> filter, BsonAgenda bson);
    }
}
