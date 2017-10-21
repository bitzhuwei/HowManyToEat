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
            PointF leftTop = context.CurrentLeftTop;
            var width = 0.0f;

            if (page.Height < leftTop.Y + context.MaxLineHeight + height) // 要换页了。
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
            else // 仅仅换行，不换页。
            {
                leftTop = new PointF(0, leftTop.Y + context.MaxLineHeight);
                this.LeftTop = leftTop;
                this.TheSize = new SizeF(width, height);
                this.PageIndex = context.CurrentIndex;

                context.CurrentLeftTop = new PointF(leftTop.X + width, leftTop.Y);
                //context.MaxLineHeight = 0;
            }
        }
    }
}
