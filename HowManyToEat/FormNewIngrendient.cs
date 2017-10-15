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
    public partial class FormNewIngrendient : Form
    {
        private const string newCatetory = "新建...";
        public FormNewIngrendient()
        {
            InitializeComponent();

            this.Load += FormNewIngrendient_Load;
        }

        void FormNewIngrendient_Load(object sender, EventArgs e)
        {
            ReloadIngredientCategory();
        }

        private void ReloadIngredientCategory()
        {
            this.cmbCategory.Items.Clear();
            IDictionary<string, IngredientCategory> dict = IngredientCategory.GetAll();
            foreach (var item in dict.Values)
            {
                this.cmbCategory.Items.Add(item);
            }
            {
                this.cmbCategory.Items.Add(newCatetory);
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
            }
            this.btnSaveAndContinue.Enabled = true;
        }

        private bool TryAdd()
        {
            string name = this.txtName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("食材名称不能为空！");
                return false;
            }

            //string categoryName = this.txtCategory.Text.Trim();
            //if (string.IsNullOrEmpty(categoryName))
            //{
            //    MessageBox.Show("食材类别不能为空！");
            //    return false;
            //}

            string unitName = this.txtUnit.Text.Trim();
            if (string.IsNullOrEmpty(unitName))
            {
                MessageBox.Show("食材单位不能为空！");
                return false;
            }
            var category = this.cmbCategory.SelectedItem as IngredientCategory;
            if (category == null)
            {
                MessageBox.Show("食材类别不能为空！");
                return false;
            }

            float price;
            if (!float.TryParse(this.txtPrice.Text.Trim(), out price))
            {
                MessageBox.Show("食材单价格式错误，无法解析！");
                return false;
            }

            var unit = new IngredientUnit() { Name = unitName };
            var ingredient = new Ingredient() { Name = name, Category = category, Unit = unit, Price = price };
            {
                IDictionary<string, Ingredient> ingredientDict = Ingredient.GetAll();
                if (ingredientDict.ContainsKey(ingredient.Name))
                {
                    MessageBox.Show(string.Format("已存在名为【{0}】的食材！", name), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                {
                    IDictionary<string, IngredientUnit> dict = IngredientUnit.GetAll();
                    if (!dict.ContainsKey(unit.Name))
                    {
                        dict.Add(unit.Name, unit);
                        IngredientUnit.SaveDatabase(typeof(IngredientUnit).Name);
                    }
                }
                {
                    ingredientDict.Add(ingredient.Name, ingredient);
                    Ingredient.SaveDatabase(typeof(Ingredient).Name);
                }
            }

            return true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.lblSucessTip.Visible = false;
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = this.cmbCategory.SelectedItem;
            if (item != null)
            {
                if (item is string)
                {
                    var str = item as string;
                    if (str == newCatetory)
                    {
                        var frm = new FormNewIngredientCategory();
                        if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            this.ReloadIngredientCategory();
                            this.cmbCategory.SelectedItem = null;
                        }
                        else
                        {
                            this.cmbCategory.SelectedIndex = -1;
                        }
                    }
                }
            }
        }
    }
}
