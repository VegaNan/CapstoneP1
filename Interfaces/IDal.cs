using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegaN_Capstone.Areas.Identity.Data;
using VegaN_Capstone.Models;

namespace VegaN_Capstone.Interfaces
{
    public interface IDal
    {

        public IEnumerable<Item> GetItems();
        public bool AddItem(Item item);
        public bool DeleteItem(int id);
        public bool UpdateItem(Item item);
        public Item GetItem(int id);
        public IEnumerable<Item> FindItems(Dictionary<string, string[]> KeyValues);
        public IEnumerable<Item> SearchItem(string containsString);

        public IEnumerable<User> GetUsers();
        public bool UpdateUser(User user);
        public bool DeleteUser(int id);
        public bool AddUser(User user);
        public IEnumerable<User> FindUsers(Dictionary<string, string[]> KeyValues);

        public IEnumerable<Announcement> GetAnnouncements();
        public bool UpdateAnnouncement(Announcement announcement);
        public bool DeleteAnnouncement(int id);
        public bool AddAnnouncement(Announcement announcement);

        public IEnumerable<Booking> GetBookings();
        public bool UpdateBooking(Booking booking);
        public bool DeleteBooking(int id);
        public bool AddBooking(Booking booking);
        public IEnumerable<Booking> FindBooking(Dictionary<string, string[]> KeyValues);

    }
}
