using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HowManyToEat
{
    /// <summary>
    /// 类别，如“作料”，“菜”，“肉”。
    /// </summary>
    public class IngredientCategory
    {
        private const string strName = "Name";
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        private const string strPriority = "Priority";
        /// <summary>
        /// 数量越小越优先。
        /// </summary>
        public int Priority { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }

            var right = obj as IngredientCategory;
            if (right == null) { return false; }

            return (this.Name == right.Name && this.Priority == right.Priority);
        }

        public override int GetHashCode()
        {
            return string.Format("{0}#{1}", this.Name, this.Priority).GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }

        public XElement ToXElement()
        {
            return new XElement(typeof(IngredientCategory).Name,
                new XAttribute(strName, this.Name),
                new XAttribute(strPriority, this.Priority));
        }

        public static IngredientCategory Parse(XElement xml)
        {
            if (xml == null || xml.Name != typeof(IngredientCategory).Name) { throw new ArgumentException(); }

            string name = xml.Attribute(strName).Value;
            int priority = int.Parse(xml.Attribute(strPriority).Value);

            return new IngredientCategory() { Name = name, Priority = priority };
        }

        private static readonly Dictionary<string, IngredientCategory> dictionary = new Dictionary<string, IngredientCategory>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        public static void LoadDatabase(string filename)
        {
            XElement xml = XElement.Load(filename);
            if (xml == null || xml.Name != typeof(IngredientCategory).Name) { throw new ArgumentException(); }

            foreach (var item in xml.Elements(typeof(IngredientCategory).Name))
            {
                IngredientCategory category = IngredientCategory.Parse(item);
                if (dictionary.ContainsKey(category.Name))
                { throw new Exception(string.Format("发现重复的食材类别【{0}】！", category.Name)); }

                dictionary.Add(category.Name, category);
            }
        }

        public static IDictionary<string, IngredientCategory> GetAll()
        {
            return dictionary;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal static IngredientCategory Select(string name)
        {
            IngredientCategory result;
            if (dictionary.TryGetValue(name, out result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException(string.Format("数据库中没有指定的【{0}】类别！", name), "name");
            }
        }

        internal static void SaveDatabase(string filename)
        {
            var xml = new XElement(typeof(IngredientCategory).Name,
                from item in dictionary.Values select item.ToXElement());

            if (!filename.ToLower().EndsWith(".xml"))
            {
                filename = filename + ".xml";
            }

            xml.Save(filename);
        }
    }
}
