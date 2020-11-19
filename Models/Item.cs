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

    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public double Price { get; set; }
        public double Rating { get; set; }

        public string Types { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public IEnumerable<DateTime> UnavailableDates { get; set; }
        public IEnumerable<Image> Images { get; set; }


        public Item()
        {
            Reviews = new List<Review>();
            UnavailableDates = new List<DateTime>();
            Images = new List<Image>();
        }

    }
    


}
