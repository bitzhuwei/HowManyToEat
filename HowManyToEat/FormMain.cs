﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HowManyToEat
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private UCProjectPanel projectPanel = new UCProjectPanel();
        private UCDishPanel dishPanelYuXiangRouSi = new UCDishPanel("YuXiangRouSi");
        private UCDishPanel dishPanelDouYaCai = new UCDishPanel("DouYaCai");
        private UCDishPanel dishPanelOther = new UCDishPanel("Other");

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "某家某月某席")
            {
                this.splitContainer1.Panel2.Controls.Clear();
                this.splitContainer1.Panel2.Controls.Add(this.projectPanel);
                this.projectPanel.Dock = DockStyle.Fill;
            }
            else if (e.Node.Text == "鱼香肉丝")
            {
                this.splitContainer1.Panel2.Controls.Clear();
                this.splitContainer1.Panel2.Controls.Add(this.dishPanelYuXiangRouSi);
                this.dishPanelYuXiangRouSi.Dock = DockStyle.Fill;
            }
            else if (e.Node.Text == "豆芽菜")
            {
                this.splitContainer1.Panel2.Controls.Clear();
                this.splitContainer1.Panel2.Controls.Add(this.dishPanelDouYaCai);
                this.dishPanelDouYaCai.Dock = DockStyle.Fill;
            }
            else
            {
                this.splitContainer1.Panel2.Controls.Clear();
                this.splitContainer1.Panel2.Controls.Add(this.dishPanelOther);
                this.dishPanelOther.Dock = DockStyle.Fill;
            }
        }

        private void 添加菜品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FormAddDishToProject()).ShowDialog();
        }

        private void 删除菜品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var items = this.listView1.SelectedItems;
            if (items.Count == 0)
            {
                MessageBox.Show("请先选中要删除的菜品，然后再点击 删除 菜品 按钮。");
                return;
            }

            foreach (var item in items)
            {
                this.listView1.Items.Remove(item as ListViewItem);
            }
        }

        private void 新建NToolStripButton_Click(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
            this.numericUpDown1.Value = 10;
        }

        private void 打开OToolStripButton_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.listView1.Items.Clear();
                var listViewItem1 = new System.Windows.Forms.ListViewItem("鱼香肉丝");
                var listViewItem2 = new System.Windows.Forms.ListViewItem("豆芽菜");
                var listViewItem3 = new System.Windows.Forms.ListViewItem("某菜3");
                var listViewItem4 = new System.Windows.Forms.ListViewItem("某菜4");
                var listViewItem5 = new System.Windows.Forms.ListViewItem("某菜5");
                var listViewItem6 = new System.Windows.Forms.ListViewItem("某菜6");
                var listViewItem7 = new System.Windows.Forms.ListViewItem("某菜7");
                var listViewItem8 = new System.Windows.Forms.ListViewItem("筷子 10双");
                var listViewItem9 = new System.Windows.Forms.ListViewItem("碗 10个");
                var listViewItem10 = new System.Windows.Forms.ListViewItem("玻璃杯 10个");
                var listViewItem11 = new System.Windows.Forms.ListViewItem("餐巾纸 2盒");
                this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] { listViewItem1, listViewItem2, listViewItem3, listViewItem4, listViewItem5, listViewItem6, listViewItem7, listViewItem8, listViewItem9, listViewItem10, listViewItem11 });
            }
        }

        private void 保存SToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 另存为AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.saveProjectDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = this.saveProjectDlg.FileName;
                File.WriteAllText(filename, string.Format("{0} 另存为成功！", DateTime.Now));

                MessageBox.Show("另存为 成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void 打印PToolStripButton_Click(object sender, EventArgs e)
        {
            if (this.printDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var printDocument1 = new System.Drawing.Printing.PrintDocument();
                printDocument1.PrintPage += printDocument1_PrintPage;
                printDocument1.Print();
            }
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

        private void 打印预览VToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FormPrintPreview()).ShowDialog();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var items = this.listView1.SelectedItems;
            if (items.Count > 0)
            {
                var last = items[items.Count - 1];
                if (last.Text == "鱼香肉丝")
                {
                    this.splitContainer1.Panel2.Controls.Clear();
                    this.splitContainer1.Panel2.Controls.Add(this.dishPanelYuXiangRouSi);
                    this.dishPanelYuXiangRouSi.Dock = DockStyle.Fill;
                }
                else if (last.Text == "豆芽菜")
                {
                    this.splitContainer1.Panel2.Controls.Clear();
                    this.splitContainer1.Panel2.Controls.Add(this.dishPanelDouYaCai);
                    this.dishPanelDouYaCai.Dock = DockStyle.Fill;
                }
                else
                {
                    this.splitContainer1.Panel2.Controls.Clear();
                    this.splitContainer1.Panel2.Controls.Add(this.dishPanelOther);
                    this.dishPanelOther.Dock = DockStyle.Fill;
                }
            }
        }

    }
}
