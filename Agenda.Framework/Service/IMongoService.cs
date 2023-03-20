using Agenda.Framework.Model;
using MongoDB.Bson;

namespace Agenda.Mongodb.Service
{
    public interface IMongoService
    {
        Task<List<BsonAgenda>> GetEventsByEventData(string data);
        Task<List<BsonAgenda>> GetEventsByCreationData(string data);
        Task InsertEventASync(BsonAgenda bson);
        Task DeleteEventAsync(ObjectId id);
        Task<BsonAgenda> UpdateEvent(BsonAgenda bson);
    }
}
