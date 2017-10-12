using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HowManyToEat
{
    /// <summary>
    /// 开席了！
    /// </summary>
    class PartyProject
    {
        private const string strCount = "Count";
        /// <summary>
        /// 多少席（桌）？
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 每一席（桌）都有哪些菜？
        /// </summary>
        public WeightedDishList DishList { get; private set; }

        public XElement ToXElement()
        {
            return new XElement(typeof(PartyProject).Name,
                new XAttribute(strCount, this.Count),
                this.DishList.ToXElement());
        }

        public static PartyProject Parse(XElement xml)
        {
            if (xml == null || xml.Name != typeof(PartyProject).Name) { throw new ArgumentException(); }

            int count = int.Parse(xml.Attribute(strCount).Value);
            WeightedDishList dishList = WeightedDishList.Parse(xml.Element(typeof(WeightedDishList).Name));

            return new PartyProject() { Count = count, DishList = dishList };
        }
    }
}
