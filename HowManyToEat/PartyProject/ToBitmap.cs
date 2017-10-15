using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace HowManyToEat
{
    public static class ToBitmap
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="project"></param>
        /// <param name="font"></param>
        /// <param name="brush"></param>
        /// <returns></returns>
        public static Bitmap DumpBitmap(this PartyProject project, Font font, Pen pen, Brush brush)
        {
            if (project == null) { return null; }

            const int width = 827, height = 1169;// A4
            const int x = 10, y = 10;
            var bitmap = new Bitmap(width, height);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.PageUnit = GraphicsUnit.Pixel;
                // bounds
                for (int i = 1; i < 3; i++)
                {
                    graphics.DrawRectangle(pen, x * i, y * i, width - x * i * 2, height - y * i * 2);
                }
                // left + right dishes
                {
                    string leftDishes = GetDishesString(project.LeftDishList);
                    SizeF leftSize = graphics.MeasureString(leftDishes, font);
                    string rightDishes = GetDishesString(project.RightDishList);
                    SizeF rightSize = graphics.MeasureString(rightDishes, font);
                    float maxWidth = leftSize.Width > rightSize.Width ? leftSize.Width : rightSize.Width;
                    float maxHeight = leftSize.Height > rightSize.Height ? leftSize.Height : rightSize.Height;
                    graphics.DrawString(leftDishes, font, brush, x * 2, y * 2);
                    graphics.DrawRectangle(pen, x * 2, y * 2, maxWidth, maxHeight);
                    graphics.DrawString(rightDishes, font, brush, x * 2 + maxWidth, y * 2);
                    graphics.DrawRectangle(pen, x * 2 + maxWidth, y * 2, maxWidth, maxHeight);
                }

                int leftCount = project.LeftDishList.Count;
                int rightCount = project.RightDishList.Count;
                int maxCount = leftCount >= rightCount ? leftCount : rightCount;
            }

            return bitmap;
        }

        private static string GetDishesString(WeightedDishList weightedDishList)
        {
            var builder = new StringBuilder();
            if (weightedDishList != null && weightedDishList.Count > 0)
            {
                for (int i = 0; i < weightedDishList.Count - 1; i++)
                {
                    builder.Append(weightedDishList[i].Dish.Name);
                    builder.AppendLine();
                }
                builder.Append(weightedDishList[weightedDishList.Count - 1].Dish.Name);
            }

            return builder.ToString();
        }
    }
}
