using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegaN_Capstone.Models
{
    public class Announcement
    {

        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string ID { get; }
        public string Name { get; set; }
        public string Review{ get; set; }
        public DateTime Date { get; set; }


        public Announcement(string id, string name, string review, DateTime date)
        {
            ID = id;
            Name = name;
            Review = review;
            Date = date;
        }
    }
}
