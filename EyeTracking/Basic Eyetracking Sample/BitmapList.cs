using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicEyetrackingSample
{
    public class BitmapList
    {
        public List<Bitmap> Bitmaps { get; set; }

        public BitmapList()
        {
            Bitmaps = new List<Bitmap>();
        }
    }
}
