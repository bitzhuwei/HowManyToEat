using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HowManyToEat
{
    /// <summary>
    /// 开席了！
    /// </summary>
    class PartyProject
    {
        /// <summary>
        /// 多少席（桌）？
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 每一席（桌）都有哪些菜？
        /// </summary>
        public DishList DishList { get; private set; }
    }
}
