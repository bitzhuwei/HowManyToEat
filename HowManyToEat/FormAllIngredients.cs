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
    public partial class FormAllIngredients : Form
    {
        public FormAllIngredients()
        {
            InitializeComponent();

            this.Load += FormAllIngredients_Load;
        }

        void FormAllIngredients_Load(object sender, EventArgs e)
        {
            this.lstIngredient.Items.Clear();

            IDictionary<string, Ingredient> ingredientDict = Ingredient.GetAll();
            var groups = new Dictionary<string, ListViewGroup>();
            foreach (var item in ingredientDict)
            {
                string name = item.Key;
                string category = item.Value.Category.Name;
                if (!groups.ContainsKey(category))
                {
                    var group = new ListViewGroup(category);
                    groups.Add(category, group);
                    this.lstIngredient.Groups.Add(group);
                }
                this.lstIngredient.Items.Add(new ListViewItem(name, groups[category]) { Tag = item.Value });
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var items = this.lstIngredient.SelectedItems;
            if (items.Count > 0)
            {
                if (MessageBox.Show("是否删除选中的食材？（这将同时删除所有使用此食材的菜品）", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    var selectedItems = new List<ListViewItem>();
                    foreach (var item in items)
                    {
                        var obj = item as ListViewItem;
                        selectedItems.Add(obj);
                    }
                    IDictionary<string, Dish> dishDict = Dish.GetAll();
                    IDictionary<string, Ingredient> ingredientDict = Ingredient.GetAll();
                    var standByDishList = new List<string>();

                    foreach (var item in selectedItems)
                    {
                        var ingredient = item.Tag as Ingredient;
                        foreach (var keyValuePair in dishDict)
                        {
                            foreach (var weightedDish in keyValuePair.Value)
                            {
                                if (weightedDish.Ingredient.Name == ingredient.Name)
                                {
                                    if (!standByDishList.Contains(keyValuePair.Key))
                                    { standByDishList.Add(keyValuePair.Key); }

                                    break;
                                }
                            }
                        }

                        ingredientDict.Remove(ingredient.Name);
                        this.lstIngredient.Items.Remove(item);
                    }

                    foreach (var item in standByDishList)
                    {
                        dishDict.Remove(item);
                    }

                    Dish.SaveDatabase(typeof(Dish).Name);
                    Ingredient.SaveDatabase(typeof(Ingredient).Name);
                }
            }
        }

        private void lstIngredient_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            this.btnDelete.Enabled = this.lstIngredient.SelectedItems.Count > 0;
        }
    }
}
