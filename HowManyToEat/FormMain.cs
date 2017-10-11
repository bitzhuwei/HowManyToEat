using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}
