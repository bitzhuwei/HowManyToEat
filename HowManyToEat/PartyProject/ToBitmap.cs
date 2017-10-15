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
        public static Bitmap DumpBitmap(this PartyProject project, int tableCount, Font font, Pen pen, Brush brush)
        {
            if (project == null) { return null; }

            const int width = 827, height = 1169;// A4
            const int x = 10, y = 10;
            var bitmap = new Bitmap(width, height);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.PageUnit = GraphicsUnit.Pixel;
                // 边线
                DrawBounds(pen, width, height, x, y, graphics);
                // 左右两列菜品
                float maxWidth, maxHeight;
                DrawDishes(project, font, pen, brush, x, y, graphics, out maxWidth, out maxHeight);
                // 所有的食材
                List<WeightedIngredient> list = GetIngredientList(project);
                // 找到右侧陈列的食材（最后一个食材的索引）
                int lastIndex = GetLastIndex(font, width, x, y, graphics, maxWidth, maxHeight, list);
                DrawRightIngrendients(tableCount, font, brush, width, x, y, graphics, maxWidth, maxHeight, list, lastIndex);
                DrawDownIngredients(tableCount, font, brush, width, x, y, graphics, maxHeight, list, lastIndex);
            }

            return bitmap;
        }

        private static void DrawDownIngredients(int tableCount, Font font, Brush brush, int width, int x, int y, Graphics graphics, float maxHeight, List<WeightedIngredient> list, int lastIndex)
        {
            var builder = new StringBuilder();
            for (int i = lastIndex + 1; i < list.Count - 1; i++)
            {
                WeightedIngredient weighted = list[i];
                builder.Append(string.Format(
                    "{0}:{1}{2}", weighted.Ingredient.Name, weighted.Weight * tableCount, weighted.Ingredient.Unit));
                builder.Append(", ");
            }

            if (list.Count > 0 && lastIndex + 1 < list.Count)
            {
                builder.Append(list[list.Count - 1]);
            }

            string str = builder.ToString();
            SizeF size = graphics.MeasureString(str, font, width - x * 2 - y * 2);
            graphics.DrawString(str, font, brush, new RectangleF(
                x * 2, y * 2 + maxHeight, size.Width, size.Height));
        }

        private static void DrawRightIngrendients(int tableCount, Font font, Brush brush, int width, int x, int y, Graphics graphics, float maxWidth, float maxHeight, List<WeightedIngredient> list, int lastIndex)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < lastIndex + 1; i++)
            {
                WeightedIngredient weighted = list[i];
                builder.Append(string.Format(
                    "{0}:{1}{2}", weighted.Ingredient.Name, weighted.Weight * tableCount, weighted.Ingredient.Unit));
                builder.Append(", ");
            }

            string str = builder.ToString();
            graphics.DrawString(str, font, brush, new RectangleF(
                x * 2 + maxWidth * 2, y * 2,
                width - x * 2 - (int)Math.Ceiling(maxWidth) * 2 - y * 2, maxHeight));
        }

        private static int GetLastIndex(Font font, int width, int x, int y, Graphics graphics, float maxWidth, float maxHeight, List<WeightedIngredient> list)
        {
            int lastIndex = -1;

            var builder = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                builder.Append(list[i]); builder.Append(", ");
                string str = builder.ToString();
                SizeF size = graphics.MeasureString(str, font, width - x * 2 - (int)Math.Ceiling(maxWidth) * 2 - y * 2);
                if (maxHeight < size.Height)
                {
                    lastIndex = i - 1;
                    break;
                }
            }
            return lastIndex;
        }

        private static List<WeightedIngredient> GetIngredientList(PartyProject project)
        {
            var ingredientDict = new Dictionary<string, WeightedIngredient>();
            foreach (var weightedDish in project.LeftDishList)
            {
                Calculate(ingredientDict, weightedDish);
            }
            foreach (var weightedDish in project.RightDishList)
            {
                Calculate(ingredientDict, weightedDish);
            }

            var list = ingredientDict.Values.ToList();
            list.OrderBy(t => t.Ingredient.Category.Name);
            return list;
        }

        private static void DrawDishes(PartyProject project, Font font, Pen pen, Brush brush, int x, int y, Graphics graphics, out float maxWidth, out float maxHeight)
        {
            string leftDishes = GetDishesString(project.LeftDishList);
            SizeF leftSize = graphics.MeasureString(leftDishes, font);
            string rightDishes = GetDishesString(project.RightDishList);
            SizeF rightSize = graphics.MeasureString(rightDishes, font);
            maxWidth = leftSize.Width > rightSize.Width ? leftSize.Width : rightSize.Width;
            maxHeight = leftSize.Height > rightSize.Height ? leftSize.Height : rightSize.Height;
            graphics.DrawString(leftDishes, font, brush, x * 2, y * 2);
            graphics.DrawRectangle(pen, x * 2, y * 2, maxWidth, maxHeight);
            graphics.DrawString(rightDishes, font, brush, x * 2 + maxWidth, y * 2);
            graphics.DrawRectangle(pen, x * 2 + maxWidth, y * 2, maxWidth, maxHeight);
        }

        private static void DrawBounds(Pen pen, int width, int height, int x, int y, Graphics graphics)
        {
            for (int i = 1; i < 3; i++)
            {
                graphics.DrawRectangle(pen, x * i, y * i, width - x * i * 2, height - y * i * 2);
            }
        }

        private static void Calculate(Dictionary<string, WeightedIngredient> ingredientDict, WeightedDish weightedDish)
        {
            int count = weightedDish.Count;
            foreach (var weightedIngredient in weightedDish.Dish)
            {
                WeightedIngredient current;
                if (ingredientDict.TryGetValue(weightedIngredient.Ingredient.Name, out current))
                {
                    current.Weight += (count * weightedIngredient.Weight);
                }
                else
                {
                    current = new WeightedIngredient() { Ingredient = weightedIngredient.Ingredient, Weight = count * weightedIngredient.Weight };
                    ingredientDict.Add(current.Ingredient.Name, current);
                }
            }
        }

        private static string GetDishesString(WeightedDishList weightedDishList)
        {
            var builder = new StringBuilder();
            if (weightedDishList != null && weightedDishList.Count > 0)
            {
                for (int i = 0; i < weightedDishList.Count - 1; i++)
                {
                    if (!weightedDishList[i].Dish.HiddenWhenPrinting)
                    {
                        builder.Append(weightedDishList[i].Dish.Name);
                    }
                    builder.AppendLine();
                }
                builder.Append(weightedDishList[weightedDishList.Count - 1].Dish.Name);
            }

            return builder.ToString();
        }
    }
}
