using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HowManyToEat
{
    public partial class FormMain : Form
    {
        private PartyProject currentPartyProject;
        private Brush grayBrush;
        private Brush foreColorBrush;

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

            for (int i = 0; i < partyProject.LeftDishList.Count; i++)
            {
                this.lstLeftDishes.Items.Add(partyProject.LeftDishList[i]);
            }

            for (int i = 0; i < partyProject.RightDishList.Count; i++)
            {
                this.lstRightDishes.Items.Add(partyProject.RightDishList[i]);
            }
        }

        public FormMain()
        {
            InitializeComponent();

            this.CurrentPartyProject = new PartyProject();
            this.grayBrush = new SolidBrush(Color.LightGray);

            this.CurrentFont = new Font("宋体", 32, GraphicsUnit.Pixel);
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
            IngredientCategory.LoadDatabase(typeof(IngredientCategory).Name + ".xml");
            IngredientUnit.LoadDatabase(typeof(IngredientUnit).Name + ".xml");
            Ingredient.LoadDatabase(typeof(Ingredient).Name + ".xml");
            Dish.LoadDatabase(typeof(Dish).Name + ".xml");

        }

        private void 新建NToolStripButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("是否保存当前的方案？", "询问", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (string.IsNullOrEmpty(this.CurrentPartyProject.Fullname))
                {
                    if (this.saveProjectDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.CurrentPartyProject.Fullname = this.saveProjectDlg.FileName;
                    }
                    else
                    {
                        return;
                    }
                }

                this.CurrentPartyProject.Save();
                this.UpdateTitle(this.CurrentPartyProject.Fullname);
                MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            else
            {
                // nothing to do.
            }

            this.CurrentPartyProject = new PartyProject();
        }

        private void 打开OToolStripButton_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    this.CurrentPartyProject = PartyProject.Load(this.openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误");
                }
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
                    this.UpdateTitle(this.CurrentPartyProject.Fullname);
                    MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                this.CurrentPartyProject.Save();
                this.UpdateTitle(this.CurrentPartyProject.Fullname);
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
                MessageBox.Show("另存为成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void 打印PToolStripButton_Click(object sender, EventArgs e)
        {
            if (this.printDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            PartyProject project = this.CurrentPartyProject;
            if (project != null)
            {
                int tableCount = (int)this.numTableCount.Value;
                Bitmap image = project.DumpBitmap(tableCount, this.CurrentFont, this.CurrentPen, this.CurrentBrush, false);
                Rectangle destRect = new Rectangle(0, 0, image.Width, image.Height);
                e.Graphics.DrawImage(image, destRect, destRect, GraphicsUnit.Pixel);
            }
        }

        private void 打印预览VToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FormPrintPreview(this.CurrentPartyProject, (int)this.numTableCount.Value)).ShowDialog();
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
                    var weighted = new WeightedDish(item, 1);
                    this.lstLeftDishes.Items.Add(weighted);
                    this.CurrentPartyProject.LeftDishList.Add(weighted);
                }
            }
        }

        private void 删除菜品leftDishesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var list = new List<WeightedDish>();
            foreach (var item in this.lstLeftDishes.SelectedItems)
            {
                list.Add(item as WeightedDish);
            }
            foreach (var item in list)
            {
                this.lstLeftDishes.Items.Remove(item);
                this.CurrentPartyProject.LeftDishList.Remove(item);
            }
        }

        private void 上移leftDishesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = this.lstLeftDishes.SelectedIndex;
            if (0 < index && index < this.lstLeftDishes.Items.Count)
            {
                var item = this.lstLeftDishes.Items[index] as WeightedDish;
                this.lstLeftDishes.Items.Remove(item);
                this.lstLeftDishes.Items.Insert(index - 1, item);
                this.CurrentPartyProject.LeftDishList.Remove(item);
                this.CurrentPartyProject.LeftDishList.Insert(index - 1, item);
            }
        }

        private void 下移leftDishesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = this.lstLeftDishes.SelectedIndex;
            if (0 <= index && index + 1 < this.lstLeftDishes.Items.Count)
            {
                var item = this.lstLeftDishes.Items[index] as WeightedDish;
                this.lstLeftDishes.Items.Remove(item);
                this.lstLeftDishes.Items.Insert(index + 1, item);
                this.CurrentPartyProject.LeftDishList.Remove(item);
                this.CurrentPartyProject.LeftDishList.Insert(index + 1, item);
            }
        }

        private void 移到右侧leftDishesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var list = new List<WeightedDish>();
            foreach (var item in this.lstLeftDishes.SelectedItems)
            {
                var obj = item as WeightedDish;
                list.Add(obj);
            }
            foreach (var item in list)
            {
                this.lstLeftDishes.Items.Remove(item);
                this.lstRightDishes.Items.Add(item);
                this.CurrentPartyProject.LeftDishList.Remove(item);
                this.CurrentPartyProject.RightDishList.Add(item);
            }
        }

        private void 打印时隐藏leftDishesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var items = this.lstLeftDishes.SelectedItems;
            foreach (var item in items)
            {
                var weightedDish = item as WeightedDish;
                weightedDish.HiddenWhenPrinting = true;
            }
            this.lstLeftDishes.Invalidate();
        }

        private void 打印时显示leftDishesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var items = this.lstLeftDishes.SelectedItems;
            foreach (var item in items)
            {
                var weightedDish = item as WeightedDish;
                weightedDish.HiddenWhenPrinting = false;
            }
            this.lstLeftDishes.Invalidate();
        }

        private void 添加菜品rightDishesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmAddDishes = new FormAddDishToProject();
            if (frmAddDishes.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var dishes = frmAddDishes.SelectedDishes;
                foreach (var item in dishes)
                {
                    var weighted = new WeightedDish(item, 1);
                    this.lstRightDishes.Items.Add(weighted);
                    this.CurrentPartyProject.RightDishList.Add(weighted);
                }
            }
        }

        private void 删除菜品rightDishesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var list = new List<WeightedDish>();
            foreach (var item in this.lstRightDishes.SelectedItems)
            {
                list.Add(item as WeightedDish);
            }
            foreach (var item in list)
            {
                this.lstRightDishes.Items.Remove(item);
                this.CurrentPartyProject.RightDishList.Remove(item);
            }
        }

        private void 上移rightDishesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = this.lstRightDishes.SelectedIndex;
            if (0 < index && index < this.lstRightDishes.Items.Count)
            {
                var item = this.lstRightDishes.Items[index] as WeightedDish;
                this.lstRightDishes.Items.Remove(item);
                this.lstRightDishes.Items.Insert(index - 1, item);
                this.CurrentPartyProject.RightDishList.Remove(item);
                this.CurrentPartyProject.RightDishList.Insert(index - 1, item);
            }
        }

        private void 下移rightDishesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = this.lstRightDishes.SelectedIndex;
            if (0 <= index && index + 1 < this.lstRightDishes.Items.Count)
            {
                var item = this.lstRightDishes.Items[index] as WeightedDish;
                this.lstRightDishes.Items.Remove(item);
                this.lstRightDishes.Items.Insert(index + 1, item);
                this.CurrentPartyProject.RightDishList.Remove(item);
                this.CurrentPartyProject.RightDishList.Insert(index + 1, item);
            }
        }

        private void 移到左侧rightDishesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var list = new List<WeightedDish>();
            foreach (var item in this.lstRightDishes.SelectedItems)
            {
                var obj = item as WeightedDish;
                list.Add(obj);
            }
            foreach (var item in list)
            {
                this.lstRightDishes.Items.Remove(item);
                this.lstLeftDishes.Items.Add(item);
                this.CurrentPartyProject.RightDishList.Remove(item);
                this.CurrentPartyProject.LeftDishList.Add(item);
            }
        }

        private void 打印时隐藏rightDishesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var items = this.lstRightDishes.SelectedItems;
            foreach (var item in items)
            {
                var weightedDish = item as WeightedDish;
                weightedDish.HiddenWhenPrinting = true;
            }
            this.lstRightDishes.Invalidate();
        }

        private void 打印时显示rightDishesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var items = this.lstRightDishes.SelectedItems;
            foreach (var item in items)
            {
                var weightedDish = item as WeightedDish;
                weightedDish.HiddenWhenPrinting = false;
            }
            this.lstRightDishes.Invalidate();
        }

        private void lstLeftDishes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // 修改份数
            //if (e.Button == System.Windows.Forms.MouseButtons.Left)
            //{
            //    foreach (var item in this.lstLeftDishes.SelectedItems)
            //    {
            //        var obj = item as WeightedDish;
            //        var frm = new FormModifyWeightedDish(obj);
            //        frm.ShowDialog();
            //    }
            //}
        }

        private void lstRightDishes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // 修改份数
            //if (e.Button == System.Windows.Forms.MouseButtons.Left)
            //{
            //    foreach (var item in this.lstRightDishes.SelectedItems)
            //    {
            //        var obj = item as WeightedDish;
            //        var frm = new FormModifyWeightedDish(obj);
            //        frm.ShowDialog();
            //    }
            //}
        }

        private void 查看所有菜品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FormAllDishes()).ShowDialog();
        }

        private void 查看所有食材ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FormAllIngredients()).ShowDialog();
        }

        private void lstbothDishes_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            var listBox = sender as ListBox;
            int index = e.Index;
            if (0 <= index && index < listBox.Items.Count)
            {
                var weightedDish = listBox.Items[e.Index] as WeightedDish;
                if (weightedDish.HiddenWhenPrinting)
                {
                    e.Graphics.DrawString(weightedDish.ToString(), e.Font, this.grayBrush, e.Bounds);
                }
                else
                {
                    if (this.foreColorBrush == null) { this.foreColorBrush = new SolidBrush(e.ForeColor); }
                    e.Graphics.DrawString(weightedDish.ToString(), e.Font, this.foreColorBrush, e.Bounds);
                }
            }

            e.DrawFocusRectangle();
        }

        private void numTableCount_ValueChanged(object sender, EventArgs e)
        {
            this.CurrentPartyProject.Count = (int)this.numTableCount.Value;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int tableCount = (int)this.numTableCount.Value;
            var ingredientDict = new Dictionary<string, WeightedIngredient>();
            foreach (var weightedDish in this.CurrentPartyProject.LeftDishList)
            {
                Calculate(ingredientDict, weightedDish, tableCount);
            }
            foreach (var weightedDish in this.CurrentPartyProject.RightDishList)
            {
                Calculate(ingredientDict, weightedDish, tableCount);
            }

            var groupedIngredient = from item in ingredientDict.Values
                                    group item by item.Ingredient.Category into g
                                    orderby g.Key.Priority ascending
                                    select g;

            var builder = new StringBuilder();
            foreach (var item in groupedIngredient)
            {
                builder.Append(item.Key.Name); builder.AppendLine("：");
                List<WeightedIngredient> list = item.ToList();
                for (int i = 0; i < list.Count - 1; i++)
                {
                    builder.Append(list[i]); builder.Append("， ");
                }
                {
                    builder.Append(list[list.Count - 1]); builder.Append("。");
                }
                builder.AppendLine();
            }

            this.txtResult.Text = builder.ToString();
        }

        private static void Calculate(Dictionary<string, WeightedIngredient> ingredientDict, WeightedDish weightedDish, int tableCount)
        {
            int count = weightedDish.Count;
            foreach (var weightedIngredient in weightedDish.Dish.WeightedIngredientList)
            {
                WeightedIngredient current;
                if (ingredientDict.TryGetValue(weightedIngredient.Ingredient.Name, out current))
                {
                    current.Weight += (tableCount * count * weightedIngredient.Weight);
                }
                else
                {
                    current = new WeightedIngredient() { Ingredient = weightedIngredient.Ingredient, Weight = tableCount * count * weightedIngredient.Weight };
                    ingredientDict.Add(current.Ingredient.Name, current);
                }
            }
        }



        public System.Drawing.Font CurrentFont { get; set; }

        public Pen CurrentPen { get; set; }

        public Brush CurrentBrush { get; set; }

        private void 查看所有食材类别ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FormAllIngredientCategory()).ShowDialog();
        }

        private void 查看所有食材单位名称ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FormAllIngredientUnit()).ShowDialog();
        }

        private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("席宴食材统计软件 东大街宴会大厅专用！", "祝威制作", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrEmpty(this.CurrentPartyProject.Fullname))
            {
                var result = MessageBox.Show("是否保存当前方案？", "询问", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (this.saveProjectDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.CurrentPartyProject.Fullname = this.saveProjectDlg.FileName;
                        this.CurrentPartyProject.Save();
                        this.UpdateTitle(this.CurrentPartyProject.Fullname);
                        MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else
                {
                    // nothig to do.
                }
            }
            else
            {
                var result = MessageBox.Show("是否保存当前方案？", "询问", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    this.CurrentPartyProject.Save();
                    this.UpdateTitle(this.CurrentPartyProject.Fullname);
                    MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else
                {
                    // nothing to do.
                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //    var now = DateTime.Now;
            //    if (now.Subtract(new DateTime(2017, 12, 24)).TotalSeconds > 0)
            //    {
            //        this.btnCalculate.Enabled = false;
            //        this.menuStrip1.Enabled = false;
            //        this.toolStrip1.Enabled = false;
            //    }
        }
    }
}
