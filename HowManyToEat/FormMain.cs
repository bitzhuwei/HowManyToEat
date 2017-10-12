using System;
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

            this.treeView1.ExpandAll();
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
            TreeNode node = this.treeView1.SelectedNode;
            if (node == null)
            {
                MessageBox.Show("请先选中要删除的菜品，然后再点击 删除 菜品 按钮。");
                return;
            }

            this.treeView1.Nodes.Remove(node);
        }

        private void 新建NToolStripButton_Click(object sender, EventArgs e)
        {
            this.treeView1.Nodes.Clear();
            var treeNode9 = new TreeNode("某家某月某席");
            this.treeView1.Nodes.Add(treeNode9);
            this.treeView1.ExpandAll();
        }

        private void 打开OToolStripButton_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.treeView1.Nodes.Clear();
                var treeNode1 = new TreeNode("鱼香肉丝");
                var treeNode2 = new TreeNode("豆芽菜");
                var treeNode3 = new TreeNode("某菜2");
                var treeNode4 = new TreeNode("某菜3");
                var treeNode5 = new TreeNode("某菜4");
                var treeNode6 = new TreeNode("某菜5");
                var treeNode7 = new TreeNode("某菜6");
                var treeNode8 = new TreeNode("某菜7");
                var treeNode9 = new TreeNode("某家某月某席", new TreeNode[] { treeNode1, treeNode2, treeNode3, treeNode4, treeNode5, treeNode6, treeNode7, treeNode8 });
                this.treeView1.Nodes.Add(treeNode9);
                this.treeView1.ExpandAll();

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

    }
}
