using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegaN_Capstone.Validator;

namespace VegaN_Capstone.Models
{
    [Booking]
    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public bool Accepted { get; set; }
        public IEnumerable<Item> Items { get; set; }

        public Booking()
        {

        }

    }
}
