using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HowManyToEat
{
    /// <summary>
    /// 一席里所有的菜品。
    /// </summary>
    class WeightedDishList : List<WeightedDish>
    {
        public XElement ToXElement()
        {
            return new XElement(typeof(WeightedDishList).Name,
                from item in this select item.ToXElement());
        }

        public static WeightedDishList Parse(XElement xml)
        {
            if (xml == null || xml.Name != typeof(WeightedDishList).Name) { throw new ArgumentException(); }

            WeightedDishList result = new WeightedDishList();
            foreach (var item in xml.Elements(typeof(WeightedDish).Name))
            {
                WeightedDish ingredient = WeightedDish.Parse(item);
                result.Add(ingredient);
            }

            return result;
        }

    }
}
