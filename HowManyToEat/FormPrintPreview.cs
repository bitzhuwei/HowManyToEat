﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HowManyToEat
{
    public partial class FormPrintPreview : Form
    {
        private int TableCount;
        /// <summary>
        /// 
        /// </summary>
        public PartyProject CurrentProject { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Font CurrentFont { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Pen CurrentPen { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Brush CurrentBrush { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="partyProject"></param>
        public FormPrintPreview(PartyProject partyProject, int tableCount)
        {
            InitializeComponent();

            this.TableCount = tableCount;
            this.CurrentProject = partyProject;

            this.CurrentFont = new Font("仿宋", 22, GraphicsUnit.Pixel);
            this.CurrentBrush = new SolidBrush(Color.Black);
            this.CurrentPen = new Pen(this.CurrentBrush);

            foreach (PaperSize item in this.printDocument1.PrinterSettings.PaperSizes)
            {
                if (item.PaperName.Equals("A4"))
                {
                    this.printDocument1.DefaultPageSettings.PaperSize = item;
                    break;
                }
            }

            this.ReloadImage(this.CurrentProject, this.TableCount);
        }

        private void ReloadImage(PartyProject partyProject, int tableCount)
        {
            Bitmap image = partyProject.DumpBitmap(tableCount, this.CurrentFont, this.CurrentPen, this.CurrentBrush, this.showRectangle);
            Rectangle destRect = new Rectangle(0, 0, image.Width, image.Height);
            this.pictureBox1.BackgroundImage = image;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            PartyProject project = this.CurrentProject;
            if (project != null)
            {
                Bitmap image = project.DumpBitmap(this.TableCount, this.CurrentFont, this.CurrentPen, this.CurrentBrush, this.showRectangle);
                Rectangle destRect = new Rectangle(0, 0, image.Width, image.Height);
                e.Graphics.DrawImage(image, destRect, destRect, GraphicsUnit.Pixel);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.printDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //var ps = new PrinterSettings();
                this.printDocument1.Print();
            }
        }

        private void btnSavePicture_Click(object sender, EventArgs e)
        {
            PartyProject project = this.CurrentProject;
            if (project != null)
            {
                if (this.saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Bitmap image = project.DumpBitmap(this.TableCount, this.CurrentFont, this.CurrentPen, this.CurrentBrush, this.showRectangle);
                    image.Save(this.saveFileDialog1.FileName);
                    Process.Start("explorer", "/select," + this.saveFileDialog1.FileName);
                }
            }
            else
            {
                MessageBox.Show("没有指定方案，无法生成统计结果！");
            }
        }

        private bool showRectangle = false;

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                this.showRectangle = !this.showRectangle;
                this.ReloadImage(this.CurrentProject, this.TableCount);
            }
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            if (this.fontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.CurrentFont = this.fontDialog1.Font;
                this.ReloadImage(this.CurrentProject, this.TableCount);
            }
        }


    }
}
