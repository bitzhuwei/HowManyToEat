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

        public override string ToString()
        {
            var dish = this.Dish;
            if (dish == null)
            {
                return string.Format("[没有指定菜品]");
            }
            else
            {
                string name = dish.Name;
                int count = this.Count;
                return string.Format("{0}:{1}份", name, count);
            }
        }

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
