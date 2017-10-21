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
    /// 布局状态。
    /// </summary>
    public abstract class PagesContext : IDisposable
    {
        private Page[] surfaces;
        private Image unitImage = new Bitmap(1, 1);

        /// <summary>
        /// 画布列表。
        /// </summary>
        public Page[] Surfaces
        {
            get { return surfaces; }
            set { surfaces = value; }
        }

        /// <summary>
        /// 当前正在使用的<see cref="surfaces"/>的索引。
        /// </summary>
        public int CurrentIndex { get; set; }

        /// <summary>
        /// 下一个字符要写到的位置（左上角）。
        /// </summary>
        public Point CurrentLeftTop { get; set; }

        /// <summary>
        /// 当前行的最大高度。
        /// </summary>
        public int MaxLineHeight { get; set; }

        /// <summary>
        /// 布局状态。
        /// </summary>
        /// <param name="surfaces"></param>
        public PagesContext(params Page[] surfaces)
        {
            if (surfaces == null || surfaces.Length < 1)
            {
                throw new ArgumentException();
            }

            this.surfaces = surfaces;

            this.UnitGraphics = Graphics.FromImage(this.unitImage);
        }

        private bool disposedValue = false;

        /// <summary>
        ///
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///
        /// </summary>
        ~PagesContext()
        {
            this.Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                }

                // Dispose unmanaged resources.
                this.UnitGraphics.Dispose();
                this.UnitGraphics = null;
                this.unitImage.Dispose();
                this.unitImage = null;
            }

            this.disposedValue = true;
        }

        public Graphics UnitGraphics { get; private set; }
    }

    /// <summary>
    /// 一页。将在上面写字（排列布局）。
    /// </summary>
    public class Page
    {
        /// <summary>
        /// 
        /// </summary>
        public int Width { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// 一页。将在上面写字（排列布局）。
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Page(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}