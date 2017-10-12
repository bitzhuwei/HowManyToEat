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
        private PartyProject currentPartyProject;

        /// <summary>
        /// 
        /// </summary>
        internal PartyProject CurrentPartyProject
        {
            get { return currentPartyProject; }
            set
            {
                currentPartyProject = value;
                this.UpdateTitle(value.Fullname);
                this.UpdateMenu(value);
            }
        }

        private void UpdateTitle(string filename)
        {
            this.Text = string.Format("{0} - 东大街宴会大厅", filename);
        }

        private void UpdateMenu(PartyProject partyProject)
        {
            this.numTableCount.Value = partyProject.Count;
            this.lstLeftDishes.Items.Clear();
            this.lstRightDishes.Items.Clear();
            for (int i = 0; i <= partyProject.DishList.Count / 2; i++)
            {
                this.lstLeftDishes.Items.Add(partyProject.DishList[i]);
            }
            for (int i = partyProject.DishList.Count / 2 + 1; i < partyProject.DishList.Count; i++)
            {
                this.lstRightDishes.Items.Add(partyProject.DishList[i]);
            }
        }

        public FormMain()
        {
            InitializeComponent();

            this.CurrentPartyProject = new PartyProject();
        }

        private void 新建NToolStripButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.CurrentPartyProject.Fullname))
            {
                if (MessageBox.Show("是否保存当前的方案？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.CurrentPartyProject.Save();
                }
            }

            this.CurrentPartyProject = new PartyProject();

            this.lstLeftDishes.Items.Clear();
            this.lstRightDishes.Items.Clear();
            this.numTableCount.Value = 10;
        }

        private void 打开OToolStripButton_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.lstLeftDishes.Items.Clear();
                this.lstRightDishes.Items.Clear();

                this.CurrentPartyProject = PartyProject.Load(this.openFileDialog1.FileName);
            }
        }

        private void 保存SToolStripButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.CurrentPartyProject.Fullname))
            {
                if (this.saveProjectDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.CurrentPartyProject.Fullname = this.saveProjectDlg.FileName;
                    this.CurrentPartyProject.Save();
                    MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                this.CurrentPartyProject.Save();
                MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void 另存为AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.saveProjectDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = this.saveProjectDlg.FileName;
                this.CurrentPartyProject.SaveAs(filename);
                this.CurrentPartyProject = PartyProject.Load(filename);
                File.WriteAllText(filename, string.Format("{0} 另存为成功！", DateTime.Now));
            }
        }

        private void 打印PToolStripButton_Click(object sender, EventArgs e)
        {
            if (this.printDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // TODO:
                //var printDocument1 = new System.Drawing.Printing.PrintDocument();
                //printDocument1.PrintPage += printDocument1_PrintPage;
                //printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // TODO:
            //Bitmap image = null;
            //try
            //{
            //    image = new Bitmap(@"printPreview.png");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("没有找到预定义的图片！");
            //}

            //e.Graphics.DrawImage(image, 0, 0, image.Width, image.Height);
        }

        private void 打印预览VToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO:
            //(new FormPrintPreview()).ShowDialog();
        }

        private void 录入菜品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FormNewDish()).Show();
        }

        private void 录入食材ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FormNewIngrendient()).Show();
        }

        private void lstLeftDishes_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                this.leftDishesMenuStrip.Show(sender as Control, e.Location);
            }
        }

        private void lstRightDishes_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                this.rightDishesMenuStrip.Show(sender as Control, e.Location);
            }
        }

        private void 添加菜品leftDishesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmAddDishes = new FormAddDishToProject();
            if (frmAddDishes.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var dishes = frmAddDishes.SelectedDishes;
                foreach (var item in dishes)
                {
                    var weighted = new WeightedDish() { Count = 1, Dish = item };
                    this.lstLeftDishes.Items.Add(weighted);
                }
            }
        }

        private void 删除菜品leftDishesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var items = this.lstLeftDishes.SelectedItems;
            foreach (var item in items)
            {
                this.lstLeftDishes.Items.Remove(item);
            }
        }

        private void 上移leftDishesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = this.lstLeftDishes.SelectedIndex;
            if (0 < index && index < this.lstLeftDishes.Items.Count)
            {
                var item = this.lstLeftDishes.Items[index];
                this.lstLeftDishes.Items.Remove(item);
                this.lstLeftDishes.Items.Insert(index - 1, item);
            }
        }

        private void 下移leftDishesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = this.lstLeftDishes.SelectedIndex;
            if (0 <= index && index + 1 < this.lstLeftDishes.Items.Count)
            {
                var item = this.lstLeftDishes.Items[index];
                this.lstLeftDishes.Items.Remove(item);
                this.lstLeftDishes.Items.Insert(index + 1, item);
            }
        }

        private void 移到右侧leftDishesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var items = this.lstLeftDishes.SelectedItems;
            foreach (var item in items)
            {
                this.lstLeftDishes.Items.Remove(item);
                this.lstRightDishes.Items.Add(item);
            }
        }

        private void 添加菜品rightDishesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmAddDishes = new FormAddDishToProject();
            if (frmAddDishes.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var dishes = frmAddDishes.SelectedDishes;
                foreach (var item in dishes)
                {
                    var weighted = new WeightedDish() { Count = 1, Dish = item };
                    this.lstRightDishes.Items.Add(weighted);
                }
            }
        }

        private void 删除菜品rightDishesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var items = this.lstRightDishes.SelectedItems;
            foreach (var item in items)
            {
                this.lstRightDishes.Items.Remove(item);
            }
        }

        private void 上移rightDishesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = this.lstRightDishes.SelectedIndex;
            if (0 < index && index < this.lstRightDishes.Items.Count)
            {
                var item = this.lstRightDishes.Items[index];
                this.lstRightDishes.Items.Remove(item);
                this.lstRightDishes.Items.Insert(index - 1, item);
            }
        }

        private void 下移rightDishesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = this.lstRightDishes.SelectedIndex;
            if (0 <= index && index + 1 < this.lstRightDishes.Items.Count)
            {
                var item = this.lstRightDishes.Items[index];
                this.lstRightDishes.Items.Remove(item);
                this.lstRightDishes.Items.Insert(index + 1, item);
            }
        }

        private void 移到左侧rightDishesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var items = this.lstRightDishes.SelectedItems;
            foreach (var item in items)
            {
                this.lstRightDishes.Items.Remove(item);
                this.lstLeftDishes.Items.Add(item);
            }
        }
    }
}
