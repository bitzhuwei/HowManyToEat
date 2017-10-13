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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public XElement ToXElement()
        {
            return new XElement(typeof(Dish).Name,
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
