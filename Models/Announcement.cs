using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegaN_Capstone.Models
{
    public class Announcement
    {
        public string ID { get; }
        public string AnnouncementTitle { get; set; }
        public string AnnouncementText{ get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public Announcement() { }
    }
}
