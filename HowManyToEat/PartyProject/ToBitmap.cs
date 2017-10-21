﻿using System;
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
                var groupedIngredients = from item in list
                                         group item by item.Ingredient.Category into g
                                         select g;
                var chunkList = new List<ChunkBase>();
                foreach (var group in groupedIngredients)
                {
                    {
                        string str = string.Format("{0}:", group.Key.Name);
                        var chunk = new StringChunk(str, font) { Tag = group.Key };
                        chunkList.Add(chunk);
                        chunkList.Add(new NewLineChunk());
                    }
                    foreach (var weighted in group)
                    {
                        string str = string.Format(
                            "{0}:{1}{2}, ",
                            weighted.Ingredient.Name, weighted.Weight * tableCount, weighted.Ingredient.Unit);
                        var chunk = new StringChunk(str, font) { Tag = weighted };
                        chunkList.Add(chunk);
                    }
                    chunkList.Add(new NewLineChunk());
                }
                var page0 = new Page(width - x * 2 - (int)Math.Ceiling(maxWidth) * 2 - x * 2, (int)Math.Ceiling(maxHeight));
                page0.Left = x * 2 + (int)Math.Ceiling(maxWidth) * 2;
                page0.Top = y * 2;
                var page1 = new Page(width - x * 2, height - y * 2 - (int)Math.Ceiling(maxHeight));
                page1.Left = x * 2;
                page1.Top = y * 2 + (int)Math.Ceiling(maxHeight);
                var context = new PagesContext(page0, page1);
                foreach (var item in chunkList)
                {
                    item.Put(context);
                }

                foreach (var item in chunkList)
                {
                    SizeF bigSize = graphics.MeasureString(item.Text, font);
                    Bitmap bigImage = new Bitmap((int)bigSize.Width, (int)bigSize.Height);
                    if (item.Tag is IngredientCategory)
                    {
                        using (var g = Graphics.FromImage(bigImage))
                        { g.DrawString(item.Text, font, brush, 0, 0); }
                    }
                    else if (item.Tag is WeightedIngredient)
                    {
                        var weighted = item.Tag as WeightedIngredient;
                        var ingredientBrush = new SolidBrush(weighted.Ingredient.ForeColor);
                        using (var g = Graphics.FromImage(bigImage))
                        { g.DrawString(item.Text, font, ingredientBrush, 0, 0); }
                        ingredientBrush.Dispose();
                    }

                    graphics.DrawImage(bigImage,
                        new RectangleF(
                            item.LeftTop.X + context.Pages[item.PageIndex].Left,
                            item.LeftTop.Y + context.Pages[item.PageIndex].Top,
                            item.TheSize.Width,
                            item.TheSize.Height),
                        new RectangleF(
                            (bigImage.Width - item.TheSize.Width) / 2,
                            0,
                            item.TheSize.Width,
                            item.TheSize.Height),
                        GraphicsUnit.Pixel);
                    bigImage.Dispose();
                }
            }

            return bitmap;
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

            var list = (from item in ingredientDict.Values
                        orderby item.Ingredient.Category.Priority ascending
                        select item).ToList();
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
                    if (!weightedDishList[i].HiddenWhenPrinting)
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
