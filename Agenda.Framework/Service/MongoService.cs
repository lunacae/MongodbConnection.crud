using Agenda.Framework.Model;
using Agenda.Mongodb.Repository;
using Framework.Agenda.Exceptions;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Agenda.Mongodb.Service
{
    public class MongoService : IMongoService
    {
        private readonly IMongoRepository _mongoRepository;

        public MongoService(IMongoRepository mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }

        public async Task DeleteEventAsync(ObjectId id)
        {
            await _mongoRepository.DeleteByIdAsync(id);
        }

        public Task<List<BsonAgenda>> GetEventsByCreationData(string data)
        {
            return null;
            /*var filter = Builders<BsonAgenda>.Filter.Eq(_ => _.CreationDate, data);
            var documents = _mongoRepository.GetDocumentsAsync(filter);
            if (documents != null)
                return documents;

            throw new DataNotFoundException();*/
        }

        public async Task<List<BsonAgenda>> GetEventsByEventData(string data)
        {
            var filter = Builders<BsonAgenda>.Filter.Eq(_ => _.EventDate, data);
            var documents = await _mongoRepository.GetDocumentsAsync(filter);
            if (documents != null)
                return documents;

            throw new DataNotFoundException();
        }

        public async Task InsertEventASync(BsonAgenda bson)
        {
            await _mongoRepository.InsertDocumentAsync(bson);
        }

        public async Task<BsonAgenda> UpdateEvent(BsonAgenda bson)
        {
            var eventDataFilter = Builders<BsonAgenda>.Filter.Eq(_ => _.EventDate, bson.EventDate)
                & Builders<BsonAgenda>.Filter.Eq(_ => _.EventName, bson.EventName);
            return await _mongoRepository.FindAndReplaceOneAsync(eventDataFilter, bson);
        }
    }
}
