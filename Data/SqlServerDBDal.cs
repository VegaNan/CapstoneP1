using AspNetCore.Identity.Mongo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegaN_Capstone.Interfaces;
using VegaN_Capstone.Models;

namespace VegaN_Capstone.Data
{
    public class SqlServerDBDal : IDal
    {
        private readonly ISqlDBContext Context;
        public SqlServerDBDal(ISqlDBContext context)
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
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
