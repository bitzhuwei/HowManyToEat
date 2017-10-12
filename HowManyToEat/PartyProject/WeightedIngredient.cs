using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HowManyToEat
{
    /// <summary>
    /// 多少？什么食材？
    /// </summary>
    class WeightedIngredient
    {
        private const string strWeight = "Weight";
        /// <summary>
        /// 多少食材？
        /// </summary>
        public float Weight { get; set; }

        /// <summary>
        /// 什么食材？
        /// </summary>
        public Ingredient Ingredient { get; set; }

        internal XElement ToXElement()
        {
            return new XElement(typeof(WeightedIngredient).Name,
                new XAttribute(strWeight, this.Weight),
                this.Ingredient.ToXElement());
        }

        internal static WeightedIngredient Parse(XElement xml)
        {
            if (xml == null || xml.Name != typeof(WeightedIngredient).Name) { throw new ArgumentException(); }

            float weight = float.Parse(xml.Attribute(strWeight).Value);
            Ingredient ingredient = Ingredient.Parse(xml.Element(typeof(Ingredient).Name));

            return new WeightedIngredient() { Weight = weight, Ingredient = ingredient };
        }
    }
}
