using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace VegaN_Capstone.Models
{
    public class Item
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string ID { get; }
        public IEnumerable<Image> Images { get; set; }
        public string Description { get; set; }
        public double PriceMin { get; set; }
        public double PriceMax { get; set; }
        public double Rating { get; set; }
        public IEnumerable<string> Types { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public IEnumerable<DateTime> UnavailableDates { get; set; }
        public Item(string iD, IEnumerable<Image> images, string description, double priceMin, double priceMax, double rating, IEnumerable<string> types, IEnumerable<Review> reviews, IEnumerable<DateTime> unavailableDates)
        {
            ID = iD;
            Images = images;
            Description = description;
            PriceMin = priceMin;
            PriceMax = priceMax;
            Rating = rating;
            Types = types;
            Reviews = reviews;
            UnavailableDates = unavailableDates;
        }

    }
}
