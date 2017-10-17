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
    public class WeightedIngredient
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

        public override string ToString()
        {
            var ingredient = this.Ingredient;
            if (ingredient == null)
            {
                return string.Format("【没有指定食材】");
            }
            else
            {
                string name = ingredient.Name;
                string unit = ingredient.Unit.Name;
                float weight = this.Weight;
                return string.Format("{0}:{1}{2}", name, weight, unit);
            }
        }

        internal XElement ToXElement()
        {
            return new XElement(typeof(WeightedIngredient).Name,
                new XAttribute(strWeight, this.Weight),
                new XAttribute(typeof(Ingredient).Name, this.Ingredient.Id));
        }

        internal static WeightedIngredient Parse(XElement xml)
        {
            if (xml == null || xml.Name != typeof(WeightedIngredient).Name) { throw new ArgumentException(); }

            float weight = float.Parse(xml.Attribute(strWeight).Value);
            Guid id = new Guid(xml.Attribute(typeof(Ingredient).Name).Value);
            Ingredient ingredient = Ingredient.Select(id);

            return new WeightedIngredient() { Weight = weight, Ingredient = ingredient };
        }
    }
}
