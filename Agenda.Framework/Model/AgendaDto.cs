using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Framework.Model
{
    public class AgendaDto
    {
        public string EventDate { get; set; }
        public string EventHour { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public List<string>? Guests { get; set; }
    }
}
