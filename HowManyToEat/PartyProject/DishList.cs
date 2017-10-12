using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HowManyToEat
{
    /// <summary>
    /// 一席（桌）都有哪些菜？
    /// </summary>
    class DishList : List<Dish>
    {
        public XElement TXElement()
        {
            return new XElement(typeof(DishList).Name,
                from item in this select item.ToXElement());
        }

        public static DishList Parse(XElement xml)
        {
            if (xml == null || xml.Name != typeof(DishList).Name) { throw new ArgumentException(); }

            DishList result = new DishList();
            foreach (var item in xml.Elements(typeof(Dish).Name))
            {
                Dish ingredient = Dish.Parse(item);
                result.Add(ingredient);
            }

            return result;
        }
    }
}
