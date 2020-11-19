using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegaN_Capstone.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public int ItemId { get; set; }
        public System.Drawing.Image ImageContent { get; set; }

        public Image()
        {

        }

    }
}
