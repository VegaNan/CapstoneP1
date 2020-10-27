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
        private readonly MongoCollectionBase<Item> ItemCollection;
        private readonly MongoCollectionBase<Announcement> AnnouncementCollection;
        private readonly MongoCollectionBase<Booking> BookingCollection;



        //setting our context
        public DBDal(IMongoDBContext context)
        {
            Context = context;
            ItemCollection = (MongoCollectionBase<Item>)Context.GetCollection<Item>(typeof(Item).Name);
            AnnouncementCollection = (MongoCollectionBase<Announcement>)Context.GetCollection<Announcement>(typeof(Announcement).Name);
            BookingCollection = (MongoCollectionBase<Booking>)Context.GetCollection<Booking>(typeof(Booking).Name);
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
            ItemCollection.InsertOne(item);
            FilterDefinition<Item> filter = Builders<Item>
                .Filter.Where(x=> x.ID == item.ID);
            return (ItemCollection.FindAsync(filter) != null);
        }

        public bool AddUser(MongoUser user)
        {
            throw new NotImplementedException();
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
            ItemCollection.DeleteOne(filter);
            return (ItemCollection.FindAsync(filter) == null);
        }

        public bool DeleteUser(string id)
        {
            throw new NotImplementedException();
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

            IEnumerable<Item> items = ItemCollection.FindAsync(filter).Result.ToList();
            return items;
        }

        public IEnumerable<MongoUser> FindUsers(Dictionary<string, string[]> KeyValues)
        {
            throw new NotImplementedException();
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
            Item item = ItemCollection.FindAsync(filter).Result.FirstOrDefault();
            return item;
        }

        public IEnumerable<Item> GetItems()
        {
            IEnumerable<Item> itemList;
            IAsyncCursor<Item> Items = ItemCollection.FindAsync(FilterDefinition<Item>.Empty).Result;
            do
            {
                itemList = Items.Current;

            }
            while (Items.MoveNext());
            return itemList;
        }

        public IEnumerable<MongoUser> GetUsers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> SearchItem(string containsString)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public bool UpdateUser(MongoUser user)
        {
            throw new NotImplementedException();
        }

    }
}
