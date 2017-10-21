using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HowManyToEat
{
    /// <summary>
    /// 一个要处理的单元（一个字符或一个字符串）。
    /// </summary>
    public class StringChunk : ChunkBase
    {

        /// <summary>
        /// 一个要处理的单元（一个字符或一个字符串）。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="font"></param>
        public StringChunk(string text, Font font)
            : base(text, font)
        {
        }

        public override void Put(PagesContext context)
        {
            if (context == null) { throw new ArgumentNullException("context"); }
            Graphics graphics = context.UnitGraphics;
            if (graphics == null) { throw new Exception("Context already disposed!"); }


            if (context.Pages.Length <= context.CurrentIndex) // 页用完了。
            {
                this.PageIndex = context.CurrentIndex; // 页索引超出范围，表示页不够用了。
                return;
            }

            Page page = context.Pages[context.CurrentIndex];
            PointF leftTop = context.CurrentLeftTop;
            SizeF bigSize = graphics.MeasureString("丨" + this.Text + "丨", this.TheFont);
            SizeF emptySize = graphics.MeasureString("丨丨", this.TheFont);
            var width = (bigSize.Width - emptySize.Width);
            var height = bigSize.Height;
            if (page.Height < leftTop.Y + height) // 要换页了。
            {
                context.CurrentIndex++;
                if (context.Pages.Length <= context.CurrentIndex) // 页用完了。
                {
                    this.PageIndex = context.CurrentIndex;
                }
                else // 用下一页。
                {
                    this.LeftTop = new PointF(0, 0);
                    this.TheSize = new SizeF(width, height);
                    this.PageIndex = context.CurrentIndex;

                    context.CurrentLeftTop = new Point(0, 0);
                    //context.MaxLineHeight = 0;
                }
            }
            else if (page.Width < leftTop.X + width) // 仅仅换行，不换页。
            {
                leftTop = new PointF(0, leftTop.Y + context.MaxLineHeight);
                this.LeftTop = leftTop;
                this.TheSize = new SizeF(width, height);
                this.PageIndex = context.CurrentIndex;

                context.CurrentLeftTop = new PointF(leftTop.X + width, leftTop.Y);
                //context.MaxLineHeight = 0;
            }
            else // 当前行还可以放下此chunk。
            {
                this.LeftTop = leftTop;
                this.TheSize = new SizeF(width, height);
                this.PageIndex = context.CurrentIndex;

                context.CurrentLeftTop = new PointF(leftTop.X + width, leftTop.Y);
                if (leftTop.X == 0 // 第一个字符（串）
                    || context.MaxLineHeight < (int)height)
                {
                    context.MaxLineHeight = (int)height;
                }
            }
        }
    }
}
