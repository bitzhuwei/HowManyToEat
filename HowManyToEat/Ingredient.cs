using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HowManyToEat
{
    /// <summary>
    /// 食材。
    /// </summary>
    class Ingredient
    {
        /// <summary>
        /// 类别，如“作料”，“菜”，“肉”。
        /// </summary>
        public IngredientCategory Category { get; set; }

        /// <summary>
        /// 名称。如“盐”，“猪肉”。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 单位名词，如“斤”，“两”，“克”。
        /// </summary>
        public IngredientUnit UnitName { get; set; }

        /// <summary>
        /// 单价。
        /// </summary>
        public int Price { get; set; }

    }
}
