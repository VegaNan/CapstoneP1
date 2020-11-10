using Microsoft.AspNetCore.Razor.Language;
using Microsoft.VisualBasic;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegaN_Capstone.Data
{
    public class Mongosettings
    {
        public string Connection { get; set; }
        public string DatabaseName { get; set; }
        public string UsersCollectionName { get; set; }
        public string ItemsCollectionName { get; set; }
        public string BookingsCollectionName { get; set; }
        public string AnnouncementsCollectionName { get; set; }
        public string ReviewsCollectionName { get; set; }
        public string RolesCollectionName { get; set; }


    }
}
