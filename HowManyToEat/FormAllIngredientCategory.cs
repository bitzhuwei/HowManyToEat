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
    public partial class FormAllIngredientCategory : Form
    {
        public FormAllIngredientCategory()
        {
            InitializeComponent();

            this.Load += FormNewIngredientCategory_Load;
        }

        void FormNewIngredientCategory_Load(object sender, EventArgs e)
        {
            IDictionary<Guid, IngredientCategory> ingredientDict = IngredientCategory.GetAll();
            var list = from item in ingredientDict.Values
                       orderby item.Priority ascending
                       select item;
            foreach (var item in list)
            {
                this.lstCategory.Items.Add(item);
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
            for (int i = 0; i < this.lstCategory.Items.Count; i++)
            {
                var obj = this.lstCategory.Items[i] as IngredientCategory;
                obj.Priority = i;
            }

            IngredientCategory.SaveDatabase(typeof(IngredientCategory).Name);

            return true;
        }

        private void btnHighest_Click(object sender, EventArgs e)
        {
            int index = this.lstCategory.SelectedIndex;
            if (0 < index && index < this.lstCategory.Items.Count)
            {
                var item = this.lstCategory.Items[index];
                this.lstCategory.Items.Remove(item);
                this.lstCategory.Items.Insert(0, item);
                this.lstCategory.SelectedIndex = 0;
            }
        }

        private void btnHigher_Click(object sender, EventArgs e)
        {
            int index = this.lstCategory.SelectedIndex;
            if (0 < index && index < this.lstCategory.Items.Count)
            {
                var item = this.lstCategory.Items[index];
                this.lstCategory.Items.Remove(item);
                this.lstCategory.Items.Insert(index - 1, item);
                this.lstCategory.SelectedIndex = index - 1;
            }
        }

        private void btnLower_Click(object sender, EventArgs e)
        {
            int index = this.lstCategory.SelectedIndex;
            if (0 <= index && index + 1 < this.lstCategory.Items.Count)
            {
                var item = this.lstCategory.Items[index];
                this.lstCategory.Items.Remove(item);
                this.lstCategory.Items.Insert(index + 1, item);
                this.lstCategory.SelectedIndex = index + 1;
            }
        }

        private void btnLowest_Click(object sender, EventArgs e)
        {
            int index = this.lstCategory.SelectedIndex;
            if (0 <= index && index + 1 < this.lstCategory.Items.Count)
            {
                var item = this.lstCategory.Items[index];
                this.lstCategory.Items.Remove(item);
                this.lstCategory.Items.Add(item);
                this.lstCategory.SelectedIndex = this.lstCategory.Items.Count - 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedItem = this.lstCategory.SelectedItem;
            if (selectedItem != null)
            {
                if (MessageBox.Show(string.Format("是否确认删除【{0}】类别？（这将同步删除使用此类别的食材和使用这些食材的菜品！）", selectedItem), "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    // 删除category
                    var category = selectedItem as IngredientCategory;
                    IDictionary<Guid, IngredientCategory> categoryDict = IngredientCategory.GetAll();
                    categoryDict.Remove(category.Id);
                    // 删除关联到category的食材ingredient
                    IDictionary<Guid, Ingredient> ingredientDict = Ingredient.GetAll();
                    var toBeDeletedIngredients = (from item in ingredientDict.Values
                                                  where item.Category.Id == category.Id
                                                  select item.Id).ToList();
                    foreach (var id in toBeDeletedIngredients)
                    {
                        ingredientDict.Remove(id);
                    }
                    // 删除关联到食材ingredient的菜品dish
                    IDictionary<Guid, Dish> dishDict = Dish.GetAll();
                    var toBeDeletedDishes = new List<Dish>();
                    foreach (var dish in dishDict.Values)
                    {
                        foreach (var weightedIngredient in dish)
                        {
                            if (toBeDeletedIngredients.Contains(weightedIngredient.Ingredient.Id))
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

                    IngredientCategory.SaveDatabase(typeof(IngredientCategory).Name);
                    Ingredient.SaveDatabase(typeof(Ingredient).Name);
                    Dish.SaveDatabase(typeof(Dish).Name);

                    this.lstCategory.Items.Remove(selectedItem);
                    MessageBox.Show("已删除此类别！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void lstCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnDelete.Enabled = this.lstCategory.SelectedItems.Count > 0;
            this.btnUpdate.Enabled = this.lstCategory.SelectedItems.Count > 0;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var index = this.lstCategory.SelectedIndex;
            if (0 <= index && index < this.lstCategory.Items.Count)
            {
                var category = this.lstCategory.Items[index] as IngredientCategory;
                var frm = new FormUpdateIngredientCategory(category);
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.lstCategory.Items[index] = category;
                }
            }
        }

    }
}
