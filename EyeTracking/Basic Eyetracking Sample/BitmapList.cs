using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicEyetrackingSample
{
    class BitmapList
    {
        public List<Bitmap> bitmapList = new List<Bitmap>();

        public void ClearBitmapList()
        {
            bitmapList.Clear();
        }

        public void AddNewElementToBitmapList(Bitmap bitmap)
        {
            bitmapList.Add(bitmap);
        }

        public List<Bitmap> GetBitmaps()
        {
            return bitmapList;
        } 
    }
}
