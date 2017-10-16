using System;
using System.Collections.Generic;
using System.IO;
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
        private const string strId = "Id";
        /// <summary>
        /// 
        /// </summary>
        public Guid Id { get; private set; }

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
        public IngredientUnit Unit { get; set; }

        private const string strPrice = "Price";
        /// <summary>
        /// 单价。
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Ingredient() { this.Id = Guid.NewGuid(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public Ingredient(Guid id) { this.Id = id; }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Unit);
        }

        public XElement ToXElement()
        {
            return new XElement(typeof(Ingredient).Name,
                new XAttribute(strId, this.Id),
                new XAttribute(strName, this.Name),
                new XAttribute(strCategory, this.Category.Name),
                new XAttribute(strUnitName, this.Unit.Name),
                new XAttribute(strPrice, this.Price));
        }

        public static Ingredient Parse(XElement xml)
        {
            if (xml == null || xml.Name != typeof(Ingredient).Name) { throw new ArgumentException(); }

            Guid id = new Guid(xml.Attribute(strId).Value);
            string name = xml.Attribute(strName).Value;
            IngredientCategory category = IngredientCategory.Select(xml.Attribute(strCategory).Value);
            IngredientUnit unitName = IngredientUnit.Select(xml.Attribute(strUnitName).Value);
            float price = float.Parse(xml.Attribute(strPrice).Value);

            return new Ingredient(id) { Name = name, Category = category, Unit = unitName, Price = price };
        }

        private static readonly Dictionary<string, Ingredient> dictionary = new Dictionary<string, Ingredient>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        public static void LoadDatabase(string filename)
        {
            if (!File.Exists(filename)) { return; }

            XElement xml = XElement.Load(filename);
            if (xml == null || xml.Name != typeof(Ingredient).Name) { throw new ArgumentException(); }

            foreach (var item in xml.Elements(typeof(Ingredient).Name))
            {
                Ingredient ingredient = Ingredient.Parse(item);
                if (dictionary.ContainsKey(ingredient.Name))
                { throw new Exception(string.Format("发现重复的食材【{0}】！", ingredient.Name)); }

                dictionary.Add(ingredient.Name, ingredient);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IDictionary<string, Ingredient> GetAll()
        {
            return dictionary;
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
                throw new ArgumentException(string.Format("数据库中没有指定的【{0}】食材(工具)！", name), "name");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        public static void SaveDatabase(string filename)
        {
            var xml = new XElement(typeof(Ingredient).Name,
                from item in dictionary.Values select item.ToXElement());

            if (!filename.ToLower().EndsWith(".xml"))
            {
                filename = filename + ".xml";
            }

            xml.Save(filename);
        }
    }
}
