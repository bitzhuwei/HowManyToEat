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
    public partial class FormAllIngredientUnit : Form
    {
        public FormAllIngredientUnit()
        {
            InitializeComponent();

            this.Load += FormNewIngredientUnit_Load;
        }

        void FormNewIngredientUnit_Load(object sender, EventArgs e)
        {
            IDictionary<Guid, IngredientUnit> unitDict = IngredientUnit.GetAll();
            var list = from item in unitDict.Values
                       select item;
            foreach (var item in list)
            {
                this.lstUnit.Items.Add(item);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedItem = this.lstUnit.SelectedItem;
            if (selectedItem != null)
            {
                if (MessageBox.Show(string.Format("是否确认删除【{0}】单位名称？（这将同步删除使用此单位名称的食材和使用这些食材的菜品！）", selectedItem), "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    // 删除category
                    var unit = selectedItem as IngredientUnit;
                    IDictionary<Guid, IngredientUnit> categoryDict = IngredientUnit.GetAll();
                    categoryDict.Remove(unit.Id);
                    // 删除关联到unit的食材ingredient
                    IDictionary<Guid, Ingredient> ingredientDict = Ingredient.GetAll();
                    var toBeDeletedIngredients = (from item in ingredientDict.Values
                                                  where item.Unit.Id == unit.Id
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

                    IngredientUnit.SaveDatabase(typeof(IngredientUnit).Name);
                    Ingredient.SaveDatabase(typeof(Ingredient).Name);
                    Dish.SaveDatabase(typeof(Dish).Name);

                    this.lstUnit.Items.Remove(selectedItem);
                    MessageBox.Show("已删除此单位名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void lstCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnDelete.Enabled = this.lstUnit.SelectedItems.Count > 0;
            this.btnUpdate.Enabled = this.lstUnit.SelectedItems.Count > 0;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var index = this.lstUnit.SelectedIndex;
            if (0 <= index && index < this.lstUnit.Items.Count)
            {
                var unit = this.lstUnit.Items[index] as IngredientUnit;
                var frm = new FormUpdateIngredientUnit(unit);
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.lstUnit.Items[index] = unit;
                }
            }
        }

    }
}
