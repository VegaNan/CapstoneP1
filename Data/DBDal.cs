using AspNetCore.Identity.Mongo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegaN_Capstone.Interfaces;
using VegaN_Capstone.Models;

namespace VegaN_Capstone.Data
{
    class DBDal : IDal
    {
        private readonly IMongoDBContext Context;
        public DBDal(IMongoDBContext context)
        {
            Context = context;
        }

        public bool AddAnnouncement(Announcement announcement)
        {
            throw new NotImplementedException();
        }

        public bool AddBooking(Booking booking)
        {
            throw new NotImplementedException();
        }

        public bool AddItem(Item item)
        {
            Context.ItemCollection.InsertOne(item);
            FilterDefinition<Item> filter = Builders<Item>
                .Filter.Where(x=> x.ID == item.ID);
            return (Context.ItemCollection.FindAsync(filter) != null);
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

        public bool DeleteAnnouncement(string id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBooking(string id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(string id)
        {
            FilterDefinition<Item> filter = Builders<Item>
                .Filter.Where(x => x.ID == id);
            Context.ItemCollection.DeleteOne(filter);
            return (Context.ItemCollection.FindAsync(filter) == null);
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

        public IEnumerable<Booking> FindBooking(Dictionary<string, string[]> KeyValues)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Item> FindItems(double priceMin, double priceMax, double rating, IEnumerable<string> types)
        {
            List<FilterDefinition<Item>> filters = new List<FilterDefinition<Item>>();
            filters.Add(Builders<Item>.Filter.Where(i => i.PriceMin.CompareTo(priceMin) >= 0));
            filters.Add(Builders<Item>.Filter.Where(i => i.PriceMax.CompareTo(priceMax) <= 0));
            filters.Add(Builders<Item>.Filter.Where(i => i.Rating.CompareTo(rating) >= 0));
            foreach (string t in types)
            {
                filters.Add(Builders<Item>.Filter.Where(i=> i.Types.ToList().Contains(t)));
            }

            FilterDefinition<Item> filter = Builders<Item>
                .Filter.And(filters);

            IEnumerable<Item> items = Context.ItemCollection.FindAsync(filter).Result.ToList();
            return items;
        }

        public IEnumerable<Announcement> GetAnnouncements()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Booking> GetBookings()
        {
            throw new NotImplementedException();
        }

        public Item GetItem(string id)
        {
            FilterDefinition<Item> filter = Builders<Item>
                .Filter.Where(x => x.ID == id);
            Item item = Context.ItemCollection.FindAsync(filter).Result.FirstOrDefault();
            return item;
        }

        public IEnumerable<Item> GetItems()
        {
            IEnumerable<Item> itemList;
            IAsyncCursor<Item> Items = Context.ItemCollection.FindAsync(FilterDefinition<Item>.Empty).Result;
            do
            {
                itemList = Items.Current;

            }
            while (Items.MoveNext());
            return itemList;
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

        public IEnumerable<Item> SearchItem(string containsString)
        {
            IEnumerable<Item> allItemsList;
            IAsyncCursor<Item> Items = Context.ItemCollection.FindAsync(FilterDefinition<Item>.Empty).Result;
            do
            {
                allItemsList = Items.Current;
            }
            while (Items.MoveNext());
            IEnumerable<Item> itemList = allItemsList.Where(I => I.Name.Contains(containsString));
            return itemList;
        }

        public bool UpdateAnnouncement(Announcement announcement)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBooking(Booking booking)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItem(Item item)
        {
            DeleteItem(item.ID);
            AddItem(item);
            FilterDefinition<Item> f = Builders<Item>
                .Filter.Where(x => x == item);
            if (Context.ItemCollection.Find(f).FirstOrDefault<Item>() == item)
            {
                return true;
            }
            return false;
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
