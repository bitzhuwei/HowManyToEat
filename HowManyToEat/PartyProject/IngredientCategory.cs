﻿using System;
using System.Collections.Generic;
using System.IO;
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

        private const string strPriority = "Priority";
        /// <summary>
        /// 数量越小越优先。
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IngredientCategory() { this.Id = Guid.NewGuid(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public IngredientCategory(Guid id) { this.Id = id; }

        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }

            var right = obj as IngredientCategory;
            if (right == null) { return false; }

            return (this.Id == right.Id);
        }

        public override int GetHashCode()
        {
            return string.Format("{0}", this.Id).GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }

        public XElement ToXElement()
        {
            return new XElement(typeof(IngredientCategory).Name,
                new XAttribute(strId, this.Id),
                new XAttribute(strName, this.Name),
                new XAttribute(strPriority, this.Priority));
        }

        public static IngredientCategory Parse(XElement xml)
        {
            if (xml == null || xml.Name != typeof(IngredientCategory).Name) { throw new ArgumentException(); }

            Guid id = new Guid(xml.Attribute(strId).Value);
            string name = xml.Attribute(strName).Value;
            int priority = int.Parse(xml.Attribute(strPriority).Value);

            return new IngredientCategory(id) { Name = name, Priority = priority };
        }

        private static readonly Dictionary<Guid, IngredientCategory> dictionary = new Dictionary<Guid, IngredientCategory>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        public static void LoadDatabase(string filename)
        {
            if (!File.Exists(filename)) { return; }

            XElement xml = XElement.Load(filename);
            if (xml == null || xml.Name != typeof(IngredientCategory).Name) { throw new ArgumentException(); }

            foreach (var item in xml.Elements(typeof(IngredientCategory).Name))
            {
                IngredientCategory category = IngredientCategory.Parse(item);
                if (dictionary.ContainsKey(category.Id))
                { throw new Exception(string.Format("发现重复的食材类别【{0}】！", category.Name)); }

                dictionary.Add(category.Id, category);
            }
        }

        public static IDictionary<Guid, IngredientCategory> GetAll()
        {
            return dictionary;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal static IngredientCategory Select(Guid id)
        {
            IngredientCategory result;
            if (dictionary.TryGetValue(id, out result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException(string.Format("数据库中没有指定的【{0}】类别！", id), "name");
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
