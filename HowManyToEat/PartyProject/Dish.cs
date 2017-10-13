using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HowManyToEat
{
    /// <summary>
    /// 一道菜由若干食材组成。
    /// </summary>
    public class Dish : List<WeightedIngredient>
    {
        /// <summary>
        /// 打印时隐藏（即不打印出来）
        /// </summary>
        public bool HiddenWhenPrinting { get; set; }

        private const string strName = "Name";
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public XElement ToXElement()
        {
            return new XElement(typeof(Dish).Name,
                new XAttribute(strName, this.Name),
                from item in this select item.ToXElement());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static Dish Parse(XElement xml)
        {
            if (xml == null || xml.Name != typeof(Dish).Name) { throw new ArgumentException(); }

            Dish result = new Dish() { Name = xml.Attribute(strName).Value };
            foreach (var item in xml.Elements(typeof(WeightedIngredient).Name))
            {
                WeightedIngredient ingredient = WeightedIngredient.Parse(item);
                result.Add(ingredient);
            }

            return result;
        }

        private static Dictionary<string, Dish> dictionary = new Dictionary<string, Dish>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        public static void LoadDatabase(string filename)
        {
            XElement xml = XElement.Load(filename);
            if (xml == null || xml.Name != typeof(Dish).Name) { throw new ArgumentException(); }

            foreach (var item in xml.Elements(typeof(Dish).Name))
            {
                Dish dish = Dish.Parse(item);
                if (dictionary.ContainsKey(dish.Name))
                { throw new Exception(string.Format("发现重复的食材[{0}]！", dish.Name)); }

                dictionary.Add(dish.Name, dish);
            }
        }

        public static IDictionary<string, Dish> GetAll()
        {
            return dictionary;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal static Dish Select(string name)
        {
            Dish result;
            if (dictionary.TryGetValue(name, out result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException(string.Format("数据库中没有指定的[{0}]菜品！", name), "name");
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
