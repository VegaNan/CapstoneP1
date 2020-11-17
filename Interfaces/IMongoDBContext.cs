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
    interface IMongoDBContext
    {

        IMongoDatabase Database { get; }

        IMongoCollection<Item> ItemCollection { get; }

        IMongoCollection<Booking> BookingCollection { get; }

        IMongoCollection<Announcement> AnnouncementCollection { get; }

        IMongoCollection<Review> ReviewCollection { get; }
        IMongoCollection<MongoUser> UserCollection { get; }
        IMongoCollection<BsonDocument> BinImageCollection { get; }

    }
}
