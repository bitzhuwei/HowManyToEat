using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HowManyToEat
{
    /// <summary>
    /// 一道菜品，要几份？
    /// </summary>
    public class WeightedDish
    {
        /// <summary>
        /// 什么菜品？
        /// </summary>
        public Dish Dish { get; set; }

        private const string strCount = "Count";
        /// <summary>
        /// 几份？
        /// </summary>
        public int Count { get; set; }

        internal XElement ToXElement()
        {
            return new XElement(typeof(WeightedDish).Name,
                new XAttribute(strCount, this.Count),
                this.Dish.ToXElement());
        }

        internal static WeightedDish Parse(XElement xml)
        {
            if (xml == null || xml.Name != typeof(WeightedDish).Name) { throw new ArgumentException(); }

            int count = int.Parse(xml.Attribute(strCount).Value);
            Dish dish = Dish.Parse(xml.Element(typeof(Dish).Name));

            return new WeightedDish() { Count = count, Dish = dish };
        }
    }
}
