using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegaN_Capstone.Models
{
    public class Review
    {

        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string ID { get; }

        public string Name { get; set; }
        public string ReviewString { get; set; }
        public DateTime Date { get; set; }

        public Review(string id, string name, string reviewString, DateTime date)
        {
            ID = id;
            Name = name;
            ReviewString = reviewString;
            Date = date;
        }
    }
}
