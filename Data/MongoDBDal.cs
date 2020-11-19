using AspNetCore.Identity.Mongo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VegaN_Capstone.Interfaces;
using VegaN_Capstone.Models;

namespace VegaN_Capstone.Data
{
    public class MongoDBDal
    {
        private readonly IMongoDBContext Context;
        public MongoDBDal(IMongoDBContext context)
        {
            Context = context;
        }


        public bool AddUser(MongoUser user)
        {
            Context.UserCollection.InsertOne(user);
            FilterDefinition<MongoUser> f = Builders<MongoUser>
                .Filter.Where(x => x == user);
            if (Context.UserCollection.Find(f).FirstOrDefault<MongoUser>() == user) {
                return true;
            }
            return false;
        }

       

        public bool DeleteUser(string id)
        {
            ObjectId ObjID;
            ObjectId.TryParse(id, out ObjID);
            FilterDefinition<MongoUser> filter = Builders<MongoUser>
                .Filter.Where(x => x.Id == (ObjID));

            Context.UserCollection.DeleteOne(filter);

            return (Context.UserCollection.FindAsync(filter) == null);
        }


        public IEnumerable<MongoUser> GetUsers()
        {
            IEnumerable<MongoUser> userList;
            bool continueRead = true;
            IAsyncCursor<MongoUser> users = Context.UserCollection.FindAsync(FilterDefinition<MongoUser>.Empty).Result;
            do{
                userList = users.Current;
                continueRead = users.MoveNext();
            }
            while (continueRead) ;
            return userList; 
        }


        public bool UpdateUser(MongoUser user)
        {
            DeleteUser(user.Id.ToString());
            AddUser(user);
            FilterDefinition<MongoUser> f = Builders<MongoUser>
                .Filter.Where(x => x == user);
            if (Context.UserCollection.Find(f).FirstOrDefault<MongoUser>() == user)
            {
                return true;
            }
            return false;
        }
        
    }
}
