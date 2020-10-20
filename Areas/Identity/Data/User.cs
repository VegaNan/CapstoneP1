using AspNetCore.Identity.Mongo.Model;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegaN_Capstone.Areas.Identity.Data
{
    public class User : MongoUser
    {


        [BsonRequired]
        [BsonElement("UName")]
        public string UName { get; set; }


        [BsonRequired]
        [BsonElement("Permissions")]
        public IEnumerable<string> Permissions { get; set; }




    }
}
