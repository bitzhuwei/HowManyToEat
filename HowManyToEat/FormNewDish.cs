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
        private List<Guid> selectedIngredientList = new List<Guid>();
        private Dictionary<Guid, ListViewGroup> groups = new Dictionary<Guid, ListViewGroup>();

        public IList<Dish> NewDishList = new List<Dish>();

        public FormNewDish()
        {
            InitializeComponent();

            this.Load += FormNewDish_Load;
        }

        void FormNewDish_Load(object sender, EventArgs e)
        {
            this.txtDishName.Text = string.Empty;

            this.ReloadIngredients();

            this.lstSelectedIngredient.Items.Clear();
        }

        private void ReloadIngredients()
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
                    var item = new ListViewItem(ingredient.Name, listViewGroup) { Tag = ingredient };
                    item.ForeColor = ingredient.ForeColor;
                    this.lstIngredient.Items.Add(item);
                }
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
                var ingredient = obj.Tag as Ingredient;
                if (!this.selectedIngredientList.Contains(ingredient.Id))
                {
                    Guid categoryId = ingredient.Category.Id;
                    if (!this.groups.ContainsKey(categoryId))
                    {
                        var group = new ListViewGroup(ingredient.Category.Name);
                        this.groups.Add(categoryId, group);
                        this.lstSelectedIngredient.Groups.Add(group);
                    }

                    var weighted = new WeightedIngredient() { Ingredient = ingredient, Weight = 0 };
                    var listViewItem = new ListViewItem(weighted.ToString(), this.groups[categoryId]) { Tag = weighted };
                    listViewItem.ForeColor = ingredient.ForeColor;
                    this.lstSelectedIngredient.Items.Add(listViewItem);
                    this.selectedIngredientList.Add(ingredient.Id);
                }
            }
        }

        private void btnRemoveIngredientFromDish_Click(object sender, EventArgs e)
        {
            foreach (var item in this.lstSelectedIngredient.SelectedItems)
            {
                var obj = item as ListViewItem;
                var weightedIngredient = obj.Tag as WeightedIngredient;
                this.lstSelectedIngredient.Items.Remove(obj);
                this.selectedIngredientList.Remove(weightedIngredient.Ingredient.Id);
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
                    obj.ForeColor = weighted.Ingredient.ForeColor;
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

            IDictionary<Guid, Dish> dishDict = Dish.GetAll();
            {
                var result = from item in dishDict.Values
                             where item.Name == dishName
                             select item;
                if (result.Count() > 0)
                {
                    MessageBox.Show(string.Format("已存在名为【{0}】的菜品!", dishName), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            var dish = new Dish() { Name = dishName };
            foreach (var item in this.lstSelectedIngredient.Items)
            {
                var obj = item as ListViewItem;
                var weighted = obj.Tag as WeightedIngredient;
                dish.Add(weighted);
            }
            dishDict.Add(dish.Id, dish);
            Dish.SaveDatabase(typeof(Dish).Name);

            this.NewDishList.Add(dish);

            return true;
        }

        private void btnModifyIngredient_Click(object sender, EventArgs e)
        {
            foreach (var item in this.lstIngredient.SelectedItems)
            {
                var obj = item as ListViewItem;
                var ingredient = obj.Tag as Ingredient;
                var frm = new FormUpdateIngredient(ingredient);
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.ReloadIngredients();
                }
            }
        }

        private void lstIngredient_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnModifyIngredient.Enabled = this.lstIngredient.SelectedItems.Count > 0;
        }

        private void btnNewIngrendient_Click(object sender, EventArgs e)
        {
            var frm = new FormNewIngrendient();
            frm.ShowDialog();
            if (frm.NewIngrendientList.Count > 0)
            {
                this.ReloadIngredients();
            }
        }

    }
}
