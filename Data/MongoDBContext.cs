using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegaN_Capstone.Data
{
    public class MongoDBContext : IMongoDBContext
    {
        private IMongoDatabase DB { get; set; }
        private MongoClient MongoClient { get; set; }
        public IClientSessionHandle Session { get; set; }

        public MongoDBContext(IOptions<Mongosettings> configuration)
        {
            MongoClient = new MongoClient(configuration.Value.Connection);
            DB = MongoClient.GetDatabase(configuration.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return DB.GetCollection<T>(name);
        }

    }
}
