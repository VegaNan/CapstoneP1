using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegaN_Capstone.Data
{
    public class Mongosettings
    {
        public string Connection { get; set; }
        public string UsersCollection { get; set; }
        public string BookingsCollection { get; set; }
        public string ItemsCollection { get; set; }
    }
}
