using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegaN_Capstone.Areas.Identity.Data;
using VegaN_Capstone.Interfaces;
using VegaN_Capstone.Models;

namespace VegaN_Capstone.Data
{
    class DBDal : IDal
    {
        private readonly IMongoDBContext Context;
        private readonly IMongoCollection<Item> ItemCollection;
        private readonly IMongoCollection<User> UserCollection;
        private readonly IMongoCollection<Announcement> AnnouncementCollection;
        private readonly IMongoCollection<Booking> BookingCollection;



        //setting our context
        public DBDal(IMongoDBContext context)
        {
            Context = context;
            ItemCollection = Context.GetCollection<Item>(typeof(Item).Name);
            UserCollection = Context.GetCollection<User>(typeof(User).Name);
            AnnouncementCollection = Context.GetCollection<Announcement>(typeof(Announcement).Name);
            BookingCollection = Context.GetCollection<Booking>(typeof(Booking).Name);
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
            throw new NotImplementedException();
        }

        public bool AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAnnouncement(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBooking(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Booking> FindBooking(Dictionary<string, string[]> KeyValues)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> FindItems(Dictionary<string, string[]> KeyValues)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> FindUsers(Dictionary<string, string[]> KeyValues)
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

        public Item GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
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

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
