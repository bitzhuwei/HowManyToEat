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
    public partial class FormAllIngredientSorting : Form
    {
        public FormAllIngredientSorting()
        {
            InitializeComponent();

            this.Load += FormAllIngredientSorting_Load;

            this.lstIngredient.MouseDown += lstIngredient_MouseDown;
            this.lstIngredient.DragOver += lstIngredient_DragOver;
            this.lstIngredient.DragDrop += lstIngredient_DragDrop;

            this.lstIngredient.DrawItem += lstIngredient_DrawItem;
        }

        void lstIngredient_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            var listBox = sender as ListBox;
            int index = e.Index;
            if (0 <= index && index < listBox.Items.Count)
            {
                var ingredient = listBox.Items[e.Index] as Ingredient;
                e.Graphics.DrawString(ingredient.ToString(), e.Font, new SolidBrush(ingredient.ForeColor), e.Bounds);
            }

            e.DrawFocusRectangle();
        }

        void lstIngredient_DragDrop(object sender, DragEventArgs e)
        {
            Point point = lstIngredient.PointToClient(new Point(e.X, e.Y));
            int index = this.lstIngredient.IndexFromPoint(point);
            if (index < 0)
            {
                index = this.lstIngredient.Items.Count - 1;
            }
            //获取拖放的数据内容
            object data = e.Data.GetData(typeof(Ingredient));
            //删除元数据
            this.lstIngredient.Items.Remove(data);
            //插入目标数据
            this.lstIngredient.Items.Insert(index, data);
        }

        void lstIngredient_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        void lstIngredient_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.lstIngredient.SelectedItem == null)
            {
                return;
            }
            //开始拖放操作，DragDropEffects为枚举类型。
            //DragDropEffects.Move 为将源数据移动到目标数据
            this.lstIngredient.DoDragDrop(this.lstIngredient.SelectedItem, DragDropEffects.Move);
        }

        void FormAllIngredientSorting_Load(object sender, EventArgs e)
        {
            IDictionary<Guid, Ingredient> ingredientDict = Ingredient.GetAll();
            var list = from item in ingredientDict.Values
                       orderby item.Priority ascending
                       select item;
            int index = 0;
            foreach (var item in list)
            {
                this.lstIngredient.Items.Add(item);

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (TryAdd())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;

                this.Close();
            }
        }

        private bool TryAdd()
        {
            for (int i = 0; i < this.lstIngredient.Items.Count; i++)
            {
                var obj = this.lstIngredient.Items[i] as Ingredient;
                obj.Priority = i;
            }

            Ingredient.SaveDatabase(typeof(Ingredient).Name);

            return true;
        }

        private void btnHighest_Click(object sender, EventArgs e)
        {
            int index = this.lstIngredient.SelectedIndex;
            if (0 < index && index < this.lstIngredient.Items.Count)
            {
                var item = this.lstIngredient.Items[index];
                this.lstIngredient.Items.Remove(item);
                this.lstIngredient.Items.Insert(0, item);
                this.lstIngredient.SelectedIndex = 0;
            }
        }

        private void btnHigher_Click(object sender, EventArgs e)
        {
            int index = this.lstIngredient.SelectedIndex;
            if (0 < index && index < this.lstIngredient.Items.Count)
            {
                var item = this.lstIngredient.Items[index];
                this.lstIngredient.Items.Remove(item);
                this.lstIngredient.Items.Insert(index - 1, item);
                this.lstIngredient.SelectedIndex = index - 1;
            }
        }

        private void btnLower_Click(object sender, EventArgs e)
        {
            int index = this.lstIngredient.SelectedIndex;
            if (0 <= index && index + 1 < this.lstIngredient.Items.Count)
            {
                var item = this.lstIngredient.Items[index];
                this.lstIngredient.Items.Remove(item);
                this.lstIngredient.Items.Insert(index + 1, item);
                this.lstIngredient.SelectedIndex = index + 1;
            }
        }

        private void btnLowest_Click(object sender, EventArgs e)
        {
            int index = this.lstIngredient.SelectedIndex;
            if (0 <= index && index + 1 < this.lstIngredient.Items.Count)
            {
                var item = this.lstIngredient.Items[index];
                this.lstIngredient.Items.Remove(item);
                this.lstIngredient.Items.Add(item);
                this.lstIngredient.SelectedIndex = this.lstIngredient.Items.Count - 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedItem = this.lstIngredient.SelectedItem;
            if (selectedItem != null)
            {
                if (MessageBox.Show(string.Format("是否确认删除食材【{0}】？（这将同步删除使用此食材的菜品！）", selectedItem), "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    // 删除ingredient
                    var ingredient = selectedItem as Ingredient;
                    IDictionary<Guid, Ingredient> ingredientDict = Ingredient.GetAll();
                    ingredientDict.Remove(ingredient.Id);
                    // 删除关联到食材ingredient的菜品dish
                    IDictionary<Guid, Dish> dishDict = Dish.GetAll();
                    var toBeDeletedDishes = new List<Dish>();
                    foreach (var dish in dishDict.Values)
                    {
                        foreach (var weightedIngredient in dish)
                        {
                            if (ingredient.Id == weightedIngredient.Ingredient.Id)
                            {
                                toBeDeletedDishes.Add(dish);
                                break;
                            }
                        }
                    }
                    foreach (var dish in toBeDeletedDishes)
                    {
                        dishDict.Remove(dish.Id);
                    }

                    Ingredient.SaveDatabase(typeof(Ingredient).Name);
                    Dish.SaveDatabase(typeof(Dish).Name);

                    this.lstIngredient.Items.Remove(selectedItem);
                    MessageBox.Show("已删除此食材！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var index = this.lstIngredient.SelectedIndex;
            if (0 <= index && index < this.lstIngredient.Items.Count)
            {
                var ingredient = this.lstIngredient.Items[index] as Ingredient;
                var frm = new FormUpdateIngredient(ingredient);
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.lstIngredient.Items[index] = ingredient;
                }
            }
        }

    }
}
