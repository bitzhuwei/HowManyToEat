using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HowManyToEat
{
    /// <summary>
    /// 单位名称，如“斤”，“两”，“克”。
    /// </summary>
    public class IngredientUnit
    {
        private const string strId = "Id";
        /// <summary>
        /// 
        /// </summary>
        public Guid Id { get; private set; }

        private const string strUnitName = "UnitName";
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IngredientUnit() { this.Id = Guid.NewGuid(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public IngredientUnit(Guid id) { this.Id = id; }

        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }

        public XElement ToXElement()
        {
            return new XElement(typeof(IngredientUnit).Name,
                new XAttribute(strId, this.Id),
                new XAttribute(strUnitName, this.Name));
        }

        public static IngredientUnit Parse(XElement xml)
        {
            if (xml.Name != typeof(IngredientUnit).Name) { throw new ArgumentException(); }

            Guid id = new Guid(xml.Attribute(strId).Value);
            string unitName = xml.Attribute(strUnitName).Value;

            return new IngredientUnit(id) { Name = unitName };
        }

        private static readonly Dictionary<Guid, IngredientUnit> dictionary = new Dictionary<Guid, IngredientUnit>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        public static void LoadDatabase(string filename)
        {
            if (!File.Exists(filename)) { return; }

            XElement xml = XElement.Load(filename);
            if (xml == null || xml.Name != typeof(IngredientUnit).Name) { throw new ArgumentException(); }

            foreach (var item in xml.Elements(typeof(IngredientUnit).Name))
            {
                IngredientUnit unit = IngredientUnit.Parse(item);
                if (dictionary.ContainsKey(unit.Id))
                { throw new Exception(string.Format("发现重复的单位名称【{0}】！", unit.Name)); }

                dictionary.Add(unit.Id, unit);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IDictionary<Guid, IngredientUnit> GetAll()
        {
            return dictionary;
        }

        internal static IngredientUnit Select(Guid unitName)
        {
            IngredientUnit result;
            if (dictionary.TryGetValue(unitName, out result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException(string.Format("数据库中没有指定的【{0}】单位名称！", unitName), "unitName");
            }
        }

        internal static void SaveDatabase(string filename)
        {
            var xml = new XElement(typeof(IngredientUnit).Name,
               from item in dictionary.Values select item.ToXElement());

            if (!filename.ToLower().EndsWith(".xml"))
            {
                filename = filename + ".xml";
            }

            xml.Save(filename);
        }
    }
}