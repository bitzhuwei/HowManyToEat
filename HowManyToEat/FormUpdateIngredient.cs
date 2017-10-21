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
    public partial class FormUpdateIngredient : Form
    {
        private const string newOne = "新建...";
        private Ingredient currentIngredient;
        public FormUpdateIngredient(Ingredient ingrendient)
        {
            InitializeComponent();

            this.currentIngredient = ingrendient;

            this.Load += FormUpdateIngrendient_Load;
        }

        void FormUpdateIngrendient_Load(object sender, EventArgs e)
        {
            this.txtName.Text = this.currentIngredient.Name;

            this.ReloadIngredientCategory();
            for (int i = 0; i < this.cmbCategory.Items.Count; i++)
            {
                var item = this.cmbCategory.Items[i] as IngredientCategory;
                if (item != null && item.Id == this.currentIngredient.Category.Id)
                {
                    this.cmbCategory.SelectedIndex = i;
                    break;
                }
            }

            this.ReloadIngredientUnit();
            for (int i = 0; i < this.cmbUnit.Items.Count; i++)
            {
                var item = this.cmbUnit.Items[i] as IngredientUnit;
                if (item != null && item.Id == this.currentIngredient.Unit.Id)
                {
                    this.cmbUnit.SelectedIndex = i;
                    break;
                }
            }

            Color color = this.currentIngredient.ForeColor;
            this.lblColorDisplay.BackColor = color;
            this.lblColor.Text = string.Format("R:{0}, G:{1}, B:{2}", color.R, color.G, color.B);
            this.txtName.ForeColor = color;

            this.txtPrice.Text = this.currentIngredient.Price.ToString();
        }

        private void ReloadIngredientUnit()
        {
            this.cmbUnit.Items.Clear();
            IDictionary<Guid, IngredientUnit> dict = IngredientUnit.GetAll();
            var list = from item in dict.Values
                       select item;
            foreach (var item in list)
            {
                this.cmbUnit.Items.Add(item);
            }
            {
                this.cmbUnit.Items.Add(newOne);
            }
        }

        private void ReloadIngredientCategory()
        {
            this.cmbCategory.Items.Clear();
            IDictionary<Guid, IngredientCategory> dict = IngredientCategory.GetAll();
            var list = from item in dict.Values
                       orderby item.Priority ascending
                       select item;
            foreach (var item in list)
            {
                this.cmbCategory.Items.Add(item);
            }
            {
                this.cmbCategory.Items.Add(newOne);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (TryUpdate())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;

                this.Close();
            }
        }

        private bool TryUpdate()
        {
            string name = this.txtName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("食材名称不能为空！");
                return false;
            }

            var category = this.cmbCategory.SelectedItem as IngredientCategory;
            if (category == null)
            {
                MessageBox.Show("食材类别不能为空！");
                return false;
            }

            var unit = this.cmbUnit.SelectedItem as IngredientUnit;
            if (unit == null)
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

            {
                var ingredient = this.currentIngredient;
                ingredient.Name = name;
                ingredient.Category = category;
                ingredient.Unit = unit;
                ingredient.ForeColor = this.lblColorDisplay.BackColor;
                ingredient.Price = price;
                Ingredient.SaveDatabase(typeof(Ingredient).Name);
            }

            return true;
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = this.cmbCategory.SelectedItem;
            if (item != null)
            {
                if (item is string)
                {
                    var str = item as string;
                    if (str == newOne)
                    {
                        var frm = new FormNewIngredientCategory();
                        if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            this.ReloadIngredientCategory();
                        }

                        this.cmbCategory.SelectedIndex = -1;
                    }
                }
            }
        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = this.cmbUnit.SelectedItem;
            if (item != null)
            {
                if (item is string)
                {
                    var str = item as string;
                    if (str == newOne)
                    {
                        var frm = new FormNewIngredientUnit();
                        if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            this.ReloadIngredientUnit();
                            this.cmbUnit.SelectedItem = null;
                        }
                        else
                        {
                            this.cmbUnit.SelectedIndex = -1;
                        }
                    }
                }
            }
        }

        private void lblColorDisplay_Click(object sender, EventArgs e)
        {
            if (this.colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Color color = this.colorDialog1.Color;
                this.lblColorDisplay.BackColor = color;
                this.lblColor.Text = string.Format("R:{0}, G:{1}, B:{2}", color.R, color.G, color.B);
                this.txtName.ForeColor = color;
            }
        }
    }
}
