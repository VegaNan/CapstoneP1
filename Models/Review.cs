using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegaN_Capstone.Models
{
    public class Review : BsonDocument
    {
        public int ReviewId { get; set; }
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string ReviewText { get; set; }
        public DateTime Date { get; set; }

        public Review() { }
    }
}
