using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HowManyToEat
{
    /// <summary>
    /// 一个要处理的单元（一个字符或一个字符串）。
    /// </summary>
    public abstract class ChunkBase
    {
        /// <summary>
        /// 把这个单元安排到合适的地方去。
        /// </summary>
        /// <param name="context"></param>
        public abstract void Put(PagesContext context);
    }
}
