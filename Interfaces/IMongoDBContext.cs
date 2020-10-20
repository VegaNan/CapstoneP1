using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegaN_Capstone.Data
{
    interface IMongoDBContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
