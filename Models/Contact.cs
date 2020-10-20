using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegaN_Capstone.Validator;

namespace VegaN_Capstone.Models
{
    [Contact]
    public class Contact
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string ID { get; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int[] PhoneNumber { get; set; }
        public string Email { get; set; }

        public Contact(string id, string name, string address, int[] phoneNumber, string email)
        {
            ID = id;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
