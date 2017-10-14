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
    public partial class FormNewDish : Form
    {
        private List<string> selectedIngredientList = new List<string>();
        private Dictionary<string, ListViewGroup> groups = new Dictionary<string, ListViewGroup>();

        public FormNewDish()
        {
            InitializeComponent();

            this.Load += FormNewDish_Load;
        }

        void FormNewDish_Load(object sender, EventArgs e)
        {
            this.txtDishName.Text = string.Empty;
            this.lstIngredient.Items.Clear();
            this.lstSelectedIngredient.Items.Clear();

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

        private int curentViewIndex = 3;
        private static readonly View[] views = new View[] { View.Details, View.LargeIcon, View.List, View.SmallIcon, View.Tile };
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.lblSucessTip.Visible = false;
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
                var frmModify = new FormModifyWeightedIngrendient(weighted);
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

        private void btnSaveAndContinue_Click(object sender, EventArgs e)
        {
            this.btnSaveAndContinue.Enabled = false;

            if (TryAdd())
            {
                this.lblSucessTip.Visible = true;
                this.timer1.Enabled = true;
                this.lstSelectedIngredient.Items.Clear();
                this.selectedIngredientList.Clear();
                this.groups.Clear();
                this.txtDishName.Text = string.Empty;
            }

            this.btnSaveAndContinue.Enabled = true;
        }

        private bool TryAdd()
        {
            string dishName = this.txtDishName.Text.Trim();
            if (string.IsNullOrEmpty(dishName))
            {
                MessageBox.Show(string.Format("菜品名称不能为空!", dishName), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            IDictionary<string, Dish> dishDict = Dish.GetAll();
            if (dishDict.ContainsKey(dishName))
            {
                MessageBox.Show(string.Format("已存在名为[{0}]的菜品!", dishName), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            var dish = new Dish() { Name = dishName };
            foreach (var item in this.lstSelectedIngredient.Items)
            {
                var obj = item as ListViewItem;
                var weighted = obj.Tag as WeightedIngredient;
                dish.Add(weighted);
            }
            dishDict.Add(dishName, dish);
            Dish.SaveDatabase(typeof(Dish).Name);

            return true;
        }


    }
}
