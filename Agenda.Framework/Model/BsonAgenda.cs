using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Agenda.Framework.Model
{
    public class BsonAgenda
    {
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }

        public string EventDate { get; set; }
        public string EventHour { get; set; }
        public DateTime CreationDate { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public List<string>? Guests { get; set; }
    }
}
