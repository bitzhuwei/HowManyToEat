using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HowManyToEat
{
    /// <summary>
    /// 食材或工具（碗筷桌椅等）。
    /// </summary>
    public class Ingredient
    {
        private const string strName = "Name";
        /// <summary>
        /// 名称。如“盐”，“猪肉”。
        /// </summary>
        public string Name { get; set; }

        private const string strCategory = "Category";
        /// <summary>
        /// 类别，如“作料”，“菜”，“肉”。
        /// </summary>
        public IngredientCategory Category { get; set; }

        private const string strUnitName = "UnitName";
        /// <summary>
        /// 单位名词，如“斤”，“两”，“克”，“个”。
        /// </summary>
        public IngredientUnit UnitName { get; set; }

        private const string strPrice = "Price";
        /// <summary>
        /// 单价。
        /// </summary>
        public int Price { get; set; }

        public XElement ToXElement()
        {
            return new XElement(typeof(Ingredient).Name,
                new XAttribute(strName, this.Name),
                new XAttribute(strCategory, this.Category.Name),
                new XAttribute(strUnitName, this.UnitName.UnitName),
                new XAttribute(strPrice, this.Price));
        }

        public static Ingredient Parse(XElement xml)
        {
            if (xml == null || xml.Name != typeof(Ingredient).Name) { throw new ArgumentException(); }

            string name = xml.Attribute(strName).Value;
            IngredientCategory category = IngredientCategory.Select(xml.Attribute(strCategory).Value);
            IngredientUnit unitName = IngredientUnit.Select(xml.Attribute(strUnitName).Value);
            int price = int.Parse(xml.Attribute(strPrice).Value);

            return new Ingredient() { Name = name, Category = category, UnitName = unitName, Price = price };
        }

        private static readonly Dictionary<string, Ingredient> dictionary = new Dictionary<string, Ingredient>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        public static void LoadDatabase(string filename)
        {
            XElement xml = XElement.Load(filename);
            if (xml == null || xml.Name != typeof(Ingredient).Name) { throw new ArgumentException(); }

            foreach (var item in xml.Elements(typeof(Ingredient).Name))
            {
                Ingredient category = Ingredient.Parse(xml);
                if (dictionary.ContainsKey(category.Name))
                { throw new Exception(string.Format("发现重复的菜品[{0}]！", category.Name)); }

                dictionary.Add(category.Name, category);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal static Ingredient Select(string name)
        {
            Ingredient result;
            if (dictionary.TryGetValue(name, out result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException(string.Format("数据库中没有指定的[{0}]食材(工具)！", name), "name");
            }
        }
    }
}
