using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System.IO;

namespace VegaN_Capstone.Models
{

    //[BsonSerializer(typeof(ItemSerializer))]
    public class Item
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public double PriceMin { get; set; }
        public double PriceMax { get; set; }
        public double Rating { get; set; }
        public IEnumerable<string> Types { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public IEnumerable<DateTime> UnavailableDates { get; set; }

        public IEnumerable<byte[]> BinImages { get; set; }

        [BsonIgnore]
        public IEnumerable<Image> DecodedImages { get
            {
                IEnumerable<Image> images = new List<Image>();
                foreach(byte[] b in BinImages)
                {
                    Image img = (Image)new ImageConverter().ConvertFrom(b);
                    images.Append(img);
                }
                return images;
            } }

        public void AddImage(byte[] imageByteArr)
        {
            BinImages.Append(imageByteArr);
        }


        public Item(string iD, string name, IEnumerable<byte[]> images, string description, double priceMin, double priceMax, double rating, IEnumerable<string> types, IEnumerable<Review> reviews, IEnumerable<DateTime> unavailableDates)
        {
            ID = iD;
            Name = name;
            BinImages = images;
            Description = description;
            PriceMin = priceMin;
            PriceMax = priceMax;
            Rating = rating;
            Types = types;
            Reviews = reviews;
            UnavailableDates = unavailableDates;
        }

        public Item()
        {

        }

    }
    


}
