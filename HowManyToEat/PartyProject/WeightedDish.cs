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
        public Dish Dish { get; private set; }

        private const string strCount = "Count";
        /// <summary>
        /// 几份？（根据客户需求，目前此属性始终为1）
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dish"></param>
        /// <param name="count"></param>
        public WeightedDish(Dish dish, int count = 1)
        {
            if (dish == null) { throw new ArgumentNullException(); }

            this.Dish = dish;
            this.Count = count;
        }

        public override string ToString()
        {
            var dish = this.Dish;
            if (dish == null)
            {
                return string.Format("【没有指定菜品]");
            }
            else
            {
                string name = dish.Name;
                int count = this.Count;
                return string.Format("{0}", name);
            }
        }

        internal XElement ToXElement()
        {
            return new XElement(typeof(WeightedDish).Name,
                new XAttribute(strCount, this.Count),
                new XElement(typeof(Dish).Name, this.Dish.Id));
        }

        internal static WeightedDish Parse(XElement xml)
        {
            if (xml == null || xml.Name != typeof(WeightedDish).Name) { throw new ArgumentException(); }

            int count = int.Parse(xml.Attribute(strCount).Value);
            Guid id = new Guid(xml.Element(typeof(Dish).Name).Value);
            Dish dish = Dish.Select(id);

            return new WeightedDish(dish, count);
        }
    }
}
