using Agenda.Framework.Model;
using MongoDB.Bson;

namespace Agenda.Mongodb.Service
{
    public interface IAgendaService
    {
        Task<List<AgendaDto>> GetEventsbyDateAsync(string date);
        Task<List<BsonAgenda>> GetEventsbyCreationDateAsync(string date);
        Task InsertEventAsync(AgendaDto bson);
        Task DeleteByIdAsync(ObjectId id);
        Task<BsonAgenda> FindAndReplaceOneAsync(BsonAgenda bson);
    }
}
