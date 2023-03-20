using Agenda.Framework.Model;
using AutoMapper;
using Hub2b.MagazineLuiza.Auth.Client.Exceptions;
using MongoDB.Bson;

namespace Agenda.Mongodb.Service
{
    public class AgendaService : IAgendaService
    {
        private readonly IMongoService mongoService;
        private readonly IMapper _mapper;

        public AgendaService(IMongoService mongoService, IMapper mapper)
        {
            this.mongoService = mongoService;
            _mapper = mapper;
        }

        public async Task DeleteByIdAsync(ObjectId id)
        {
            await mongoService.DeleteEventAsync(id);
        }

        public async Task<BsonAgenda> FindAndReplaceOneAsync(BsonAgenda bson)
        {
            return await mongoService.UpdateEvent(bson);
        }

        public async Task<List<BsonAgenda>> GetEventsbyCreationDateAsync(string date)
        {
            return await mongoService.GetEventsByCreationData(date);
        }

        public async Task<List<AgendaDto>> GetEventsbyDateAsync(string date)
        {
            var documents =  await mongoService.GetEventsByEventData(date);
            var result = MapToDtoList(documents);
            return result;
        }

        public async Task InsertEventAsync(AgendaDto eventDto)
        {
            try
            {
                var bson = MapToBson(eventDto);
                await mongoService.InsertEventASync(bson);
            }
            catch(Exception ex)
            {
                throw new MongodbException($"Error while trying to insert data on mongoDB, error message: {ex.Message}");
            }
        }

        private BsonAgenda MapToBson(AgendaDto agendaEvent)
        {
            var bson = _mapper.Map<AgendaDto, BsonAgenda>(agendaEvent);
            bson.CreationDate = DateTime.UtcNow.AddHours(-3);

            return bson;
        }

        private List<AgendaDto> MapToDtoList(List<BsonAgenda> documents)
        {
            List<AgendaDto> result = new List<AgendaDto>();

            foreach(var document in documents)
                result.Add(_mapper.Map<BsonAgenda, AgendaDto>(document));

            return result;
        }
    }
}
