using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HowManyToEat
{
    /// <summary>
    /// 多少？什么食材？
    /// </summary>
    class WeightedIngredient
    {
        /// <summary>
        /// 多少食材？
        /// </summary>
        public float Count { get; set; }


        /// <summary>
        /// 什么食材？
        /// </summary>
        public Ingredient Ingredient { get; set; }
    }
}
