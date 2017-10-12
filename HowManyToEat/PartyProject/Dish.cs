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
        public XElement ToXElement()
        {
            return new XElement(typeof(Dish).Name,
                from item in this select item.ToXElement());
        }

        public static Dish Parse(XElement xml)
        {
            if (xml == null || xml.Name != typeof(Dish).Name) { throw new ArgumentException(); }

            Dish result = new Dish();
            foreach (var item in xml.Elements(typeof(WeightedIngredient).Name))
            {
                WeightedIngredient ingredient = WeightedIngredient.Parse(item);
                result.Add(ingredient);
            }

            return result;
        }

    }
}
