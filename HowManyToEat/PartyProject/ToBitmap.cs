using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace HowManyToEat
{
    public static class ToBitmap
    {
        public static Bitmap DumpBitmap(this PartyProject project, Font font, Brush brush)
        {
            if (project == null) { return null; }

            const int factor = 10;
            int width = 210 * factor, height = 297 * factor;// A4: 210mm x 297mm
            var bitmap = new Bitmap(width, height);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                int leftCount = project.LeftDishList.Count;
                int rightCount = project.RightDishList.Count;
                int maxCount = leftCount >= rightCount ? leftCount : rightCount;
            }

            throw new NotImplementedException();
        }
    }
}
