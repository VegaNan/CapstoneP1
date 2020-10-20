using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegaN_Capstone.Models
{
    public class Booking
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string ID { get; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public IEnumerable<int> ItemIds { get; set; }
        public Contact Contact { get; set; }
        public string Notes { get; set; }
        public bool Accepted { get; set; }

        public Booking(string iD, DateTime timeStart, DateTime timeEnd, IEnumerable<int> itemIds, Contact contact, string notes, bool accepted)
        {
            ID = iD;
            TimeStart = timeStart;
            TimeEnd = timeEnd;
            ItemIds = itemIds;
            Contact = contact;
            Notes = notes;
            Accepted = accepted;
        }

    }
}
