using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HowManyToEat
{
    public partial class FormPrintPreview : Form
    {
        public FormPrintPreview()
        {
            InitializeComponent();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap image = null;
            try
            {
                image = new Bitmap(@"printPreview.png");
            }
            catch (Exception ex)
            {
                MessageBox.Show("没有找到预定义的图片！");
            }

            e.Graphics.DrawImage(image, 0, 0, image.Width, image.Height);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.printDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.printDocument1.Print();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Bitmap image = null;
                try
                {
                    image = new Bitmap(@"printPreview.png");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("没有找到预定义的图片！");
                }

                image.Save(this.saveFileDialog1.FileName);
                Process.Start("explorer", "/select," + this.saveFileDialog1.FileName);
            }
        }
    }
}
