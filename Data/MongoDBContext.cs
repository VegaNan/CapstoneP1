using AspNetCore.Identity.Mongo.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegaN_Capstone.Interfaces;
using VegaN_Capstone.Models;

namespace VegaN_Capstone.Data
{
    public class MongoDBContext : IMongoDBContext
    {
        private readonly Mongosettings mongosettings;
        public MongoDBContext(IOptions<Mongosettings> configuration)
        {
            mongosettings = configuration.Value;
        }

        public IMongoDatabase Database
        {
            get
            {
                MongoClientBase client = new MongoClient(mongosettings.Connection);
                IMongoDatabase database = client.GetDatabase(mongosettings.DatabaseName);
                return database;
            }
        }
        public IMongoCollection<Item> ItemCollection
        {
            get
            {
                return Database.GetCollection<Item>(mongosettings.ItemsCollectionName);
            }
        }
        public IMongoCollection<Booking> BookingCollection
        {
            get
            {
                return Database.GetCollection<Booking>(mongosettings.BookingsCollectionName);
            }
        }
        public IMongoCollection<Announcement> AnnouncementCollection
        {
            get
            {
                return Database.GetCollection<Announcement>(mongosettings.AnnouncementsCollectionName);
            }
        }
        public IMongoCollection<Review> ReviewCollection
        {
            get
            {
                return Database.GetCollection<Review>(mongosettings.ReviewsCollectionName);
            }
        }
        public IMongoCollection<MongoUser> UserCollection
        {
            get
            {
                return Database.GetCollection<MongoUser>(mongosettings.UsersCollectionName);
            }
        }

        public IMongoCollection<string> RoleCollection
        {
            get
            {
                return Database.GetCollection<string>(mongosettings.RolesCollectionName);
            }
        }

        public IMongoCollection<BsonDocument> BinImageCollection
        {
            get
            {
                return Database.GetCollection<BsonDocument>(mongosettings.ImageCollectionName);
            }
        }
    }
}
