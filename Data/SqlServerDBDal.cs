using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
        public async void AddItem(Item item)
        {
            using DbConnection connection = Context.connection();
            bool connectionWasOpen = (connection.State == System.Data.ConnectionState.Open);
            if (!connectionWasOpen)
            {
                connection.Open();
            }

            int itemId = -1;

            if (item != null)
            {
                string ItemString = string.Format("INSERT INTO [dbo].[Items] ([ItemName], [ItemDescription], [Price], [Rating]) VALUES('{0}','{1}',{2},{3})", item.ItemName, item.ItemDescription, item.Price, item.Rating);
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = ItemString;
                    await command.ExecuteNonQueryAsync();
                }

                string idString = string.Format("SELECT [ItemId] FROM[dbo].[Items] WHERE ItemName = '{0}' AND ItemDescription = '{1}' AND Price = '{2}'", item.ItemName, item.ItemDescription, item.Price);
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = idString;
                    DbDataReader reader = command.ExecuteReaderAsync().Result;
                    reader.Read();
                    itemId = reader.GetInt32(0);
                }

            }

            connection.Close();
            if (item.Images.Count() > 0)
            {
                connection.Open();
                Console.WriteLine("there are images");
                foreach (Models.Image i in item.Images)
                {
                    Console.WriteLine("For each image");
                    System.Drawing.Image imageC = i.ImageContent;

                    byte[] data = ImageToByteArray(imageC);

                    if (data == null || data.Length == 0)
                    {
                        Console.WriteLine("no image data!");
                    }
                    else
                    {
                        foreach (byte b in data)
                        {
                            Console.Write(b);
                        }
                    }
                    //insert each image
                    //int imageId = -1;
                    string ItemString = string.Format("INSERT INTO [dbo].[Images] ([Image], [ItemId]) VALUES(@data,{0})", itemId);
                    Console.WriteLine(ItemString);

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = @ItemString;

                        DbParameter dataCom = command.CreateParameter();
                        dataCom.ParameterName = "@data";
                        dataCom.DbType = System.Data.DbType.Binary;
                        dataCom.Value = data;

                        command.Parameters.Add(dataCom);
                        await command.ExecuteNonQueryAsync();
                    }

                }
                connection.Close();
            }
            if (item.Types != null)
            {
                string[] types = item.Types.Split(',');
                foreach (string t in types)
                {
                    connection.Open();
                    int id = -1;
                    //To upper first char, To lower the rest

                    string type = t.Trim();
                    type = (char.ToUpper(type[0]) + type.Substring(1).ToLower());
                    if(type.Contains(" "))
                    {
                        throw new Exception("Something went wrong! The type is:" + type);
                    }
                    //check if they are in the Types table
                    string TypesTableCHeck = string.Format("SELECT [TypeId] FROM[dbo].[Types] WHERE TypeText = '{0}' ", type);
                    Console.WriteLine(TypesTableCHeck);

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = TypesTableCHeck;
                        DbDataReader reader = command.ExecuteReader();
                        try
                        {
                            reader.Read();

                            id = reader.GetInt32(0);
                        }
                        catch (Exception e)
                        {
                        }
                    }
                    connection.Close();
                    connection.Open();
                    //if not, add them
                    //get their id
                    if (id == -1)
                    {
                        string insertTypeString = string.Format("INSERT INTO [dbo].[Types] ([TypeText]) VALUES('{0}')", type);
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = insertTypeString;
                            await command.ExecuteNonQueryAsync();
                        }
                        connection.Close();

                        connection.Open();
                        TypesTableCHeck = string.Format("SELECT [TypeId] FROM[dbo].[Types] WHERE TypeText = '{0}'", type);
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = TypesTableCHeck;
                            DbDataReader reader = command.ExecuteReader();
                            try
                            {
                                reader.Read();
                                id = reader.GetInt32(0);
                            }
                            catch (Exception e)
                            {
                            }
                        }

                    }
                    connection.Close();
                    connection.Open();
                    //add them to the itemtype table
                    string InsertItemTypeString = string.Format("INSERT INTO [dbo].[ItemType] ([ItemId], [TypeId]) VALUES({0},{1})", itemId, id);
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = InsertItemTypeString;
                        await command.ExecuteNonQueryAsync();
                    }

                    connection.Close();
                }
            }

            if (!connectionWasOpen)
            {
                connection.Close();
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
        public async Task<Item> GetItem(int id)
        {
            Item i = new Item();
            using DbConnection connection = Context.connection();
            bool connectionWasOpen = (connection.State == System.Data.ConnectionState.Open);
            if (!connectionWasOpen)
            {
                connection.Open();
            }
            Console.WriteLine("Getting item with id:" + id);

            string SelectString = string.Format("SELECT * FROM [dbo].[Items] WHERE ItemId={0}", id);
            using (var SelectItemsCommand = connection.CreateCommand())
            {
                SelectItemsCommand.CommandText = SelectString;
                using (var itemReader = await SelectItemsCommand.ExecuteReaderAsync())
                {
                    while (await itemReader.ReadAsync())
                    {
                        i.ItemId = itemReader.GetInt32(0);
                        i.ItemName = itemReader.GetString(1);
                        i.ItemDescription = itemReader.GetString(2);
                        i.Price = decimal.ToDouble(itemReader.GetDecimal(3));
                        i.Rating = decimal.ToDouble(itemReader.GetDecimal(4));
                    }
                }
            }
            if (!connectionWasOpen)
            {
                connection.Close();
            }

            i.Images = getImages(i.ItemId).Result;
            i.Types = getTypes(i.ItemId).Result;

            return i;
        }

        private async Task<IEnumerable<Models.Image>> getImages(int ItemId)
        {
            using DbConnection connection = Context.connection();
            bool connectionWasOpen = (connection.State == System.Data.ConnectionState.Open);
            if (!connectionWasOpen)
            {
                connection.Open();
            }
            List<Models.Image> images = new List<Models.Image>();
            string SelectString = string.Format("SELECT * FROM [dbo].[Images] WHERE ItemId={0}", ItemId);
            Console.WriteLine(SelectString);

            using (var SelectItemsCommand = connection.CreateCommand())
            {
                SelectItemsCommand.CommandText = SelectString;
                using (var itemReader = await SelectItemsCommand.ExecuteReaderAsync())
                {
                    while (await itemReader.ReadAsync())
                    {
                        Console.WriteLine("Image id:" + itemReader.GetInt32(0));
                        Models.Image i = new Models.Image();
                        Console.WriteLine("getting image");

                        i.ImageId = itemReader.GetInt32(0);
                        i.ImageContent = ByteArrayToImage(itemReader.GetFieldValue<byte[]>(1));
                        i.ItemId = itemReader.GetInt32(2);
                        images.Add(i);
                    }
                }
            }
            if (!connectionWasOpen)
            {
                connection.Close();
            }
            return images;
        }

        private async Task<string> getTypes(int ItemId)
        {
            string types = "";
            using (DbConnection connection = Context.connection()){

                List<int> typeIds = new List<int>();

                string SelectString = string.Format("SELECT [TypeId] FROM [dbo].[ItemType] WHERE ItemId={0}", ItemId);
                Console.WriteLine(SelectString);
                using (var SelectStringCommand = connection.CreateCommand())
                {
                    connection.Open();
                    SelectStringCommand.CommandText = SelectString;
                    using (var itemReader = await SelectStringCommand.ExecuteReaderAsync())
                    {
                        while (await itemReader.ReadAsync())
                        {
                            int TypeId = itemReader.GetInt32(0);
                            typeIds.Add(TypeId);
                        }
                    }
                    connection.Close();
                }
                foreach (int TypeId in typeIds)
                {
                    connection.Open();
                    string SelectString2 = string.Format("SELECT [TypeText] FROM [dbo].[Types] WHERE TypeId={0}", TypeId);
                    Console.WriteLine(SelectString2);
                    using (var SelectString2Command = connection.CreateCommand())
                    {
                        SelectString2Command.CommandText = SelectString2;
                        using (var reader = await SelectString2Command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                string type = reader.GetString(0);
                                if (types.Length > 0)
                                {
                                    types = types + ", " + type;
                                }
                                else
                                {
                                    types = type;
                                }
                            }
                        }
                    }
                    connection.Close();
                }
            };
            return types;
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            List<Item> items = new List<Item>();
            using DbConnection connection = Context.connection();
            bool connectionWasOpen = (connection.State == System.Data.ConnectionState.Open);
            if (!connectionWasOpen)
            {
                connection.Open();
            }

            string SelectString = "SELECT [ItemId] FROM [dbo].[Items]";
            Console.WriteLine(SelectString);
            using (var SelectItemsCommand = connection.CreateCommand())
            {
                SelectItemsCommand.CommandText = SelectString;
                using (var itemReader = await SelectItemsCommand.ExecuteReaderAsync())
                {
                    while (await itemReader.ReadAsync())
                    {
                        int ItemId = itemReader.GetInt32(0);
                        Item i = GetItem(ItemId).Result;
                        Console.WriteLine(i.ItemId + " " + i.ItemName + " " + i.ItemDescription);
                        items.Add(i);
                    }
                }
            }

            if (!connectionWasOpen)
            {
                connection.Close();
            }
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


        private byte[] ImageToByteArray(System.Drawing.Image image)
        {
            using (var ms = new MemoryStream())
            {
                try
                {
                    Console.WriteLine("before save");
                    image.Save(ms, image.RawFormat);
                    Console.WriteLine("after save");
                    return ms.ToArray();

                }
                catch (Exception e)
                {
                    return ms.ToArray();
                }

            }
            //return null;
        }

        private System.Drawing.Image ByteArrayToImage(byte[] byteArrayIn)
        {
            if(byteArrayIn == null ||byteArrayIn.Length == 0)
            {
                throw new Exception("The image byte array is null");
            }
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Bitmap returnImage = new Bitmap(System.Drawing.Image.FromStream(ms, true, true), 100, 100);
            return returnImage;
        }
    }
}
