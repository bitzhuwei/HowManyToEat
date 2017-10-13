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
        public FormNewIngrendient()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.btnOK.Enabled = false;
            if (TryAdd())
            {
                this.lblSucessTip.Visible = true;
                this.timer1.Enabled = true;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            this.btnOK.Enabled = true;
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

            string categoryName = this.txtCategory.Text.Trim();
            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("食材类别不能为空！");
                return false;
            }

            string unitName = this.txtUnit.Text.Trim();
            if (string.IsNullOrEmpty(unitName))
            {
                MessageBox.Show("食材单位不能为空！");
                return false;
            }

            float price;
            if (!float.TryParse(this.txtPrice.Text.Trim(), out price))
            {
                MessageBox.Show("食材单价格式错误，无法解析！");
                return false;
            }

            var category = new IngredientCategory() { Name = categoryName };
            var unit = new IngredientUnit() { UnitName = unitName };
            var ingredient = new Ingredient() { Name = name, Category = category, UnitName = unit, Price = price };
            {
                IDictionary<string, Ingredient> ingredientDict = Ingredient.GetAll();
                if (ingredientDict.ContainsKey(ingredient.Name))
                {
                    MessageBox.Show(string.Format("已存在名为[{0}]的食材！", name), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                {
                    IDictionary<string, IngredientCategory> dict = IngredientCategory.GetAll();
                    if (!dict.ContainsKey(category.Name))
                    {
                        dict.Add(category.Name, category);
                        IngredientCategory.SaveDatabase(typeof(IngredientCategory).Name);
                    }
                }

                {
                    IDictionary<string, IngredientUnit> dict = IngredientUnit.GetAll();
                    if (!dict.ContainsKey(unit.UnitName))
                    {
                        dict.Add(unit.UnitName, unit);
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
    }
}
