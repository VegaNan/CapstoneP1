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

        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string ID { get; }
        public string Title { get; set; }
        public string AnnouncementText{ get; set; }
        public DateTime Date { get; set; }


        public Announcement(string id, string title, string announcementText, DateTime date)
        {
            ID = id;
            Title = title;
            AnnouncementText = announcementText;
            Date = date;
        }
    }
}
