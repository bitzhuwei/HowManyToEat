﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HowManyToEat
{
    /// <summary>
    /// 一道菜由若干食材组成。
    /// </summary>
    public class Dish// : List<WeightedIngredient>
    {
        private const string strId = "Id";
        /// <summary>
        /// 
        /// </summary>
        public Guid Id { get; private set; }

        private const string strName = "Name";
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        private List<WeightedIngredient> weightedIngredientList = new List<WeightedIngredient>();
        /// <summary>
        /// 
        /// </summary>
        public List<WeightedIngredient> WeightedIngredientList
        {
            get { return weightedIngredientList; }
        }

        private const string strPriority = "Priority";
        /// <summary>
        /// 数量越小越优先。
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dish() { this.Id = Guid.NewGuid(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public Dish(Guid id) { this.Id = id; }

        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public XElement ToXElement()
        {
            return new XElement(typeof(Dish).Name,
                new XAttribute(strId, this.Id),
                new XAttribute(strName, this.Name),
                new XAttribute(strPriority, this.Priority),
                from item in this.weightedIngredientList select item.ToXElement());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static Dish Parse(XElement xml)
        {
            if (xml == null || xml.Name != typeof(Dish).Name) { throw new ArgumentException(); }

            Guid id = new Guid(xml.Attribute(strId).Value);

            string name = xml.Attribute(strName).Value;

            int priority = 0;
            {
                XAttribute attr = xml.Attribute(strPriority);
                if (attr != null) { priority = int.Parse(attr.Value); }
            }
            Dish result = new Dish(id) { Name = name, Priority = priority };

            foreach (var item in xml.Elements(typeof(WeightedIngredient).Name))
            {
                WeightedIngredient ingredient = WeightedIngredient.Parse(item);
                result.weightedIngredientList.Add(ingredient);
            }

            return result;
        }

        private static Dictionary<Guid, Dish> dictionary = new Dictionary<Guid, Dish>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        public static void LoadDatabase(string filename)
        {
            if (!File.Exists(filename)) { return; }

            XElement xml = XElement.Load(filename);
            if (xml == null || xml.Name != typeof(Dish).Name) { throw new ArgumentException(); }

            foreach (var item in xml.Elements(typeof(Dish).Name))
            {
                Dish dish = Dish.Parse(item);
                if (dictionary.ContainsKey(dish.Id))
                { throw new Exception(string.Format("发现重复的食材【{0}】！", dish.Name)); }

                dictionary.Add(dish.Id, dish);
            }
        }

        public static IDictionary<Guid, Dish> GetAll()
        {
            return dictionary;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal static Dish Select(Guid id)
        {
            Dish result;
            if (dictionary.TryGetValue(id, out result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException(string.Format("数据库中没有指定的【{0}】菜品！", id), "name");
            }
        }

        internal static void SaveDatabase(string filename)
        {
            var xml = new XElement(typeof(Dish).Name,
                from item in dictionary.Values select item.ToXElement());

            if (!filename.ToLower().EndsWith(".xml"))
            {
                filename = filename + ".xml";
            }

            xml.Save(filename);
        }
    }
}
