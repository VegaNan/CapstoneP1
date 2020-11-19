using AspNetCore.Identity.Mongo.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegaN_Capstone.Models;

namespace VegaN_Capstone.Interfaces
{
    public interface IMongoDBContext
    {

        IMongoDatabase Database { get; }
        IMongoCollection<MongoUser> UserCollection { get; }

    }
}
