using System;
using System.Collections.Generic;
using System.Drawing;
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

        private const string strForeColor = "ForeColor";
        /// <summary>
        /// 
        /// </summary>
        public Color ForeColor { get; set; }

        private const string strPrice = "Price";
        /// <summary>
        /// 单价。
        /// </summary>
        public float Price { get; set; }

        private const string strPriority = "Priority";
        /// <summary>
        /// 数量越小越优先。
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Ingredient() { this.Id = Guid.NewGuid(); this.ForeColor = Color.Black; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public Ingredient(Guid id) { this.Id = id; }

        public override string ToString()
        {
            return string.Format("{0}", this.Name);//, this.Unit);
        }

        public XElement ToXElement()
        {
            return new XElement(typeof(Ingredient).Name,
                new XAttribute(strId, this.Id),
                new XAttribute(strName, this.Name),
                new XAttribute(strCategory, this.Category.Id),
                new XAttribute(strUnitName, this.Unit.Id),
                new XAttribute(strForeColor, string.Format("{0},{1},{2}", this.ForeColor.R, this.ForeColor.G, this.ForeColor.B)),
                new XAttribute(strPrice, this.Price),
                new XAttribute(strPriority, this.Priority));
        }

        public static Ingredient Parse(XElement xml)
        {
            if (xml == null || xml.Name != typeof(Ingredient).Name) { throw new ArgumentException(); }

            Guid id = new Guid(xml.Attribute(strId).Value);
            string name = xml.Attribute(strName).Value;
            IngredientCategory category = IngredientCategory.Select(new Guid(xml.Attribute(strCategory).Value));
            IngredientUnit unit = IngredientUnit.Select(new Guid(xml.Attribute(strUnitName).Value));
            Color color;
            var colorAttr = xml.Attribute(strForeColor);
            if (colorAttr != null)
            {
                string[] parts = colorAttr.Value.Split(',');
                int r = int.Parse(parts[0]), g = int.Parse(parts[1]), b = int.Parse(parts[2]);
                color = Color.FromArgb(r, g, b);
            }
            else
            {
                color = Color.Black;
            }
            float price = float.Parse(xml.Attribute(strPrice).Value);

            int priority = 0;
            {
                XAttribute attr = xml.Attribute(strPriority);
                if (attr != null) { priority = int.Parse(attr.Value); }
            }
            return new Ingredient(id) { Name = name, Category = category, Unit = unit, ForeColor = color, Price = price, Priority = priority };
        }

        private static readonly Dictionary<Guid, Ingredient> dictionary = new Dictionary<Guid, Ingredient>();

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
                if (dictionary.ContainsKey(ingredient.Id))
                { throw new Exception(string.Format("发现重复的食材【{0}】！", ingredient.Name)); }

                dictionary.Add(ingredient.Id, ingredient);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IDictionary<Guid, Ingredient> GetAll()
        {
            return dictionary;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal static Ingredient Select(Guid id)
        {
            Ingredient result;
            if (dictionary.TryGetValue(id, out result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException(string.Format("数据库中没有指定的【{0}】食材(工具)！", id), "name");
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
