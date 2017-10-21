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
        public string Text { get; private set; }

        public Font TheFont { get; private set; }

        public SizeF Size { get; set; }

        public Point LeftTop { get; set; }

        /// <summary>
        /// 如果页索引超出范围，就表示页不够用了。
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 一个要处理的单元（一个字符或一个字符串）。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="font"></param>
        public StringChunk(string text, Font font)
        {
            this.Text = text;
            this.TheFont = font;
        }

        public override void Put(PagesContext context)
        {
            if (context == null) { throw new ArgumentNullException("context"); }
            Graphics graphics = context.UnitGraphics;
            if (graphics == null) { throw new Exception("Context already disposed!"); }


            if (context.Surfaces.Length <= context.CurrentIndex) // 页用完了。
            {
                this.PageIndex = context.CurrentIndex; // 页索引超出范围，表示页不够用了。
                return;
            }

            Page page = context.Surfaces[context.CurrentIndex];
            Point leftTop = context.CurrentLeftTop;
            SizeF bigSize = graphics.MeasureString(this.Text, this.TheFont);
            SizeF emptySize = graphics.MeasureString(string.Empty, this.TheFont);
            float width = bigSize.Width - emptySize.Width;
            float height = bigSize.Height;
            if (leftTop.X + width <= page.Width) // 当前行还可以放下此chunk。
            {
                this.LeftTop = leftTop;
                this.Size = new SizeF(width, height);
                this.PageIndex = context.CurrentIndex;

                context.CurrentLeftTop = new Point(leftTop.X + (int)width, leftTop.Y);
                if (context.MaxLineHeight < (int)height)
                {
                    context.MaxLineHeight = (int)height;
                }
            }
            else // 要换行了。
            {
                leftTop = new Point(0, leftTop.Y + context.MaxLineHeight);
                if (page.Height < leftTop.Y + height) // 要换页了。
                {
                    context.CurrentIndex++;
                    if (context.Surfaces.Length <= context.CurrentIndex) // 页用完了。
                    {
                        this.PageIndex = context.CurrentIndex;
                    }
                    else // 用下一页。
                    {
                        this.LeftTop = new Point(0, 0);
                        this.Size = new SizeF(width, height);
                        this.PageIndex = context.CurrentIndex;

                        context.CurrentLeftTop = new Point(0, 0);
                        context.MaxLineHeight = 0;
                    }
                }
                else // 仅仅换行，不换页。
                {
                    this.LeftTop = leftTop;
                    this.Size = new SizeF(width, height);
                    this.PageIndex = context.CurrentIndex;

                    context.CurrentLeftTop = leftTop;
                    context.MaxLineHeight = 0;
                }
            }
        }
    }
}
