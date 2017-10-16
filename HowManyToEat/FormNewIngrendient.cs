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
        private const string newOne = "新建...";

        private IList<Ingredient> newIngrendientList = new List<Ingredient>();

        /// <summary>
        /// 
        /// </summary>
        public IList<Ingredient> NewIngrendientList
        {
            get { return newIngrendientList; }
        }

        public FormNewIngrendient()
        {
            InitializeComponent();

            this.Load += FormNewIngrendient_Load;
        }

        void FormNewIngrendient_Load(object sender, EventArgs e)
        {
            this.ReloadIngredientCategory();

            this.ReloadIngredientUnit();
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

            var ingredient = new Ingredient() { Name = name, Category = category, Unit = unit, Price = price };
            IDictionary<Guid, Ingredient> ingredientDict = Ingredient.GetAll();
            {
                var result = from item in ingredientDict.Values
                             where item.Name == ingredient.Name
                             select item;
                if (result.Count() > 0)
                {
                    MessageBox.Show(string.Format("已存在名为【{0}】的食材！", name), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            {
                ingredientDict.Add(ingredient.Id, ingredient);
                Ingredient.SaveDatabase(typeof(Ingredient).Name);

                this.newIngrendientList.Add(ingredient);
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
                    if (str == newOne)
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
    }
}
