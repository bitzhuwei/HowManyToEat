﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HowManyToEat
{
    /// <summary>
    /// 一个要处理的单元（换行符）。
    /// </summary>
    public class NewLineChunk : ChunkBase
    {
        private static readonly Font font = new Font("宋体", 32, GraphicsUnit.Pixel);

        public NewLineChunk() : base(Environment.NewLine, font) { }

        public override void Put(PagesContext context)
        {
            if (context == null) { throw new ArgumentNullException("context"); }
            Graphics graphics = context.UnitGraphics;
            if (graphics == null) { throw new Exception("Context already disposed!"); }

            if (context.Pages.Length <= context.CurrentIndex) // 页用完了。
            {
                // 页索引超出范围，表示页不够用了。
                return;
            }

            Page page = context.Pages[context.CurrentIndex];
            float height = context.MaxLineHeight;

            if (page.Height < context.CurrentLeftTop.Y + height) // 要换页了。
            {
                context.CurrentIndex++;
                if (context.Pages.Length <= context.CurrentIndex) // 页用完了。
                {
                    return;
                }
                else // 用下一页。
                {
                    context.CurrentLeftTop = new PointF(0, 0);
                    //context.MaxLineHeight = 0;
                }
            }
            else // 仅仅换行，不换页。
            {
                context.CurrentLeftTop = new PointF(0, context.CurrentLeftTop.Y + height);
                //context.MaxLineHeight = 0;
            }
        }
    }
}
