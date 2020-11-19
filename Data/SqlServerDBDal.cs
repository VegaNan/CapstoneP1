using AspNetCore.Identity.Mongo.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using VegaN_Capstone.Interfaces;
using VegaN_Capstone.Models;

namespace VegaN_Capstone.Data
{
    public class SqlServerDBDal
    {
        private readonly SqlServerDBContext Context;
        public SqlServerDBDal(SqlServerDBContext context)
        {
            Context = context;
        }

        //Announcements
        public void AddAnnouncement(Announcement announcement)
        {
            throw new NotImplementedException();

        }
        public void DeleteAnnouncement(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Announcement> GetAnnouncements()
        {
            throw new NotImplementedException();
        }
        public void UpdateAnnouncement(Announcement announcement)
        {
            throw new NotImplementedException();
        }


        //Booking
        public void AddBooking(Booking booking)
        {
            throw new NotImplementedException();
        }
        public void DeleteBooking(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Booking> FindBooking(Dictionary<string, string[]> KeyValues)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Booking> GetBookings()
        {
            throw new NotImplementedException();
        }
        public void UpdateBooking(Booking booking)
        {
            throw new NotImplementedException();
        }


        //Item
        public void AddItem(Item item)
        {
            using DbConnection msc = Context.connection();
            if (item != null)
            {
                Console.WriteLine("item is not null");
                string ItemString = string.Format("INSERT INTO [dbo].[Items] ([ItemId], [ItemName], [ItemDescription], [Price], [Rating]) VALUES({0},{1},{2},{3},{4},{5}) GO", item.ItemId, item.ItemName, item.ItemDescription, item.Price, item.ItemDescription, item.Rating);
            }
            if (item.Images.Count() > 0)
            {
                foreach (Models.Image i in item.Images)
                {
                    byte[] image;
                    ImageConverter ic = new ImageConverter();
                    image = (byte[])ic.ConvertTo(i, typeof(byte[]));
                }
            }

            if (item.Types != null)
            {
                string[] types = item.Types.Split(',');
                foreach (string t in types)
                {
                    int id;
                    int itemId;
                    //To upper first char, To lower the rest
                    //check if they are in the Types table
                    //if not, add them
                    //get their id
                    //add them to the itemtype table



                }

            }
        }
        public void DeleteItem(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Item> FindItems(double priceMin, double priceMax, double rating, IEnumerable<string> types)
        {
            throw new NotImplementedException();
        }
        public Item GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            List<Item> items = new List<Item>();
            using DbConnection connection = Context.connection();
            connection.Open();

            string SelectString = "SELECT [ItemId] FROM [dbo].[Items]";
            using(var SelectItemsCommand = connection.CreateCommand())
            {
                SelectItemsCommand.CommandText = SelectString;
                using(var itemReader = await SelectItemsCommand.ExecuteReaderAsync())
                {
                    while(await itemReader.ReadAsync())
                    {
                        Console.WriteLine("getting item");
                        Item i = GetItem(int.Parse(itemReader.GetString(0)));
                    }
                }
            }
            connection.Close();
            return items;
        }
        public IEnumerable<Item> SearchItem(string containsString)
        {
            throw new NotImplementedException();
        }
        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }


        //User
        public void AddUser(MongoUser user)
        {
            throw new NotImplementedException();
        }
        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<MongoUser> GetUsers()
        {
            throw new NotImplementedException();
        }
        public void UpdateUser(MongoUser user)
        {
            throw new NotImplementedException();
        }



    }
}
