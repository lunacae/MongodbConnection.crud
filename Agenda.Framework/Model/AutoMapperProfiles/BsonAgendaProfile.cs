using Agenda.Framework.Model;
using AutoMapper;

namespace Hub2bDatabaseApi.Models.Mappers.Images
{

    public class BsonAgendaProfile : Profile
    {
        public BsonAgendaProfile()
        {
            CreateMap<BsonAgenda, AgendaDto>()
                .ReverseMap();
            /*CreateMap<AgendaDto, BsonAgenda>()
                .ForMember(dst => dst.CreationDate,
                    map => DateTime.UtcNow.AddHours(-3));*/

            CreateMap<AgendaDto, BsonAgenda>()
                .ReverseMap();
        }
    }
}
