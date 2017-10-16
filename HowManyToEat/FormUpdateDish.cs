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
    public partial class FormUpdateDish : Form
    {
        private List<string> selectedIngredientList = new List<string>();
        private Dictionary<string, ListViewGroup> groups = new Dictionary<string, ListViewGroup>();

        public FormUpdateDish(Dish dish)
        {
            InitializeComponent();

            if (dish == null) { throw new ArgumentNullException("dish"); }

            this.currentDish = dish;

            this.Load += FormNewDish_Load;
        }

        void FormNewDish_Load(object sender, EventArgs e)
        {
            this.txtDishName.Text = this.currentDish.Name;

            ReloadAllIngredients();

            {
                this.lstSelectedIngredient.Items.Clear();
                var groupedIngredients = from weighted in this.currentDish
                                         group weighted by weighted.Ingredient.Category into g
                                         orderby g.Key.Priority ascending
                                         select g;
                foreach (var group in groupedIngredients)
                {
                    var listViewGroup = new ListViewGroup(group.Key.Name);
                    this.lstSelectedIngredient.Groups.Add(listViewGroup);
                    foreach (var weighted in group)
                    {
                        this.lstSelectedIngredient.Items.Add(new ListViewItem(weighted.ToString(), listViewGroup) { Tag = weighted });
                    }
                }
            }
        }

        private void ReloadAllIngredients()
        {
            this.lstIngredient.Items.Clear();
            IDictionary<Guid, Ingredient> ingredientDict = Ingredient.GetAll();
            var groupedIngredients = from item in ingredientDict.Values
                                     group item by item.Category into g
                                     orderby g.Key.Priority ascending
                                     select g;
            foreach (var group in groupedIngredients)
            {
                var listViewGroup = new ListViewGroup(group.Key.Name);
                this.lstIngredient.Groups.Add(listViewGroup);
                foreach (var ingredient in group)
                {
                    this.lstIngredient.Items.Add(new ListViewItem(ingredient.Name, listViewGroup) { Tag = ingredient });
                }
            }
        }

        private int curentViewIndex = 3;
        private static readonly View[] views = new View[] { View.Details, View.LargeIcon, View.List, View.SmallIcon, View.Tile };
        private Dish currentDish;
        private void btnSwitchView_Click(object sender, EventArgs e)
        {
            this.lstIngredient.View = views[(curentViewIndex + 1) % views.Length];
            this.lstSelectedIngredient.View = views[(curentViewIndex + 1) % views.Length];
            curentViewIndex++;
            if (curentViewIndex > 1000)
            {
                curentViewIndex = curentViewIndex % views.Length;
            }
        }

        private void btnAddIngredientToDish_Click(object sender, EventArgs e)
        {
            AddIngredientsToDish(this.lstIngredient.SelectedItems);
        }

        private void lstIngredient_DoubleClick(object sender, EventArgs e)
        {
            AddIngredientsToDish(this.lstIngredient.SelectedItems);
        }

        private void AddIngredientsToDish(ListView.SelectedListViewItemCollection items)
        {
            foreach (var item in items)
            {
                var obj = item as ListViewItem;
                string name = obj.Text;
                if (!this.selectedIngredientList.Contains(name))
                {
                    var ingredient = obj.Tag as Ingredient;
                    string category = ingredient.Category.Name;
                    if (!this.groups.ContainsKey(category))
                    {
                        var group = new ListViewGroup(category);
                        this.groups.Add(category, group);
                        this.lstSelectedIngredient.Groups.Add(group);
                    }

                    var weighted = new WeightedIngredient() { Ingredient = ingredient, Weight = 0 };
                    this.lstSelectedIngredient.Items.Add(new ListViewItem(weighted.ToString(), this.groups[category]) { Tag = weighted });
                    this.selectedIngredientList.Add(name);
                }
            }
        }

        private void btnRemoveIngredientFromDish_Click(object sender, EventArgs e)
        {
            foreach (var item in this.lstSelectedIngredient.SelectedItems)
            {
                var obj = item as ListViewItem;
                var name = obj.Text;
                this.lstSelectedIngredient.Items.Remove(obj);
                this.selectedIngredientList.Remove(name);
            }
        }

        private void btnModifyWeightedIngredient_Click(object sender, EventArgs e)
        {
            ModifyWeightedIngredients(this.lstSelectedIngredient.SelectedItems);
        }

        private void lstSelectedIngredient_DoubleClick(object sender, EventArgs e)
        {
            ModifyWeightedIngredients(this.lstSelectedIngredient.SelectedItems);
        }

        private void ModifyWeightedIngredients(ListView.SelectedListViewItemCollection items)
        {
            foreach (var item in items)
            {
                var obj = item as ListViewItem;
                var name = obj.Text;
                var weighted = obj.Tag as WeightedIngredient;
                var frmModify = new FormUpdateWeightedIngrendient(weighted);
                if (frmModify.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    obj.Text = weighted.ToString();
                }
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
            string dishName = this.txtDishName.Text.Trim();
            if (string.IsNullOrEmpty(dishName))
            {
                MessageBox.Show(string.Format("菜品名称不能为空!", dishName), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            var dish = this.currentDish;
            dish.Name = this.txtDishName.Text;
            dish.Clear();
            foreach (var item in this.lstSelectedIngredient.Items)
            {
                var obj = item as ListViewItem;
                var weighted = obj.Tag as WeightedIngredient;
                dish.Add(weighted);
            }
            Dish.SaveDatabase(typeof(Dish).Name);

            return true;
        }

        private void btnNewIngrendient_Click(object sender, EventArgs e)
        {
            var frm = new FormNewIngrendient();
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.ReloadAllIngredients();
            }
        }

        private void btnModifyIngredient_Click(object sender, EventArgs e)
        {
            foreach (var item in this.lstIngredient.Items)
            {
                var obj = item as ListViewItem;
                var ingredient = obj.Tag as Ingredient;
                var frmModify = new FormUpdateIngredient(ingredient);
                if (frmModify.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    obj.Text = ingredient.ToString();
                }
            }
        }


    }
}
