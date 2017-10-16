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
    public partial class FormNewIngredientCategory : Form
    {
        private const string strNewCategory = "新类别名称";
        private IngredientCategory newCatetory;
        public FormNewIngredientCategory()
        {
            InitializeComponent();

            this.Load += FormNewIngredientCategory_Load;
        }

        void FormNewIngredientCategory_Load(object sender, EventArgs e)
        {
            IDictionary<string, IngredientCategory> ingredientDict = IngredientCategory.GetAll();
            var list = from item in ingredientDict.Values
                       orderby item.Priority ascending
                       select item;
            foreach (var item in list)
            {
                this.lstCategory.Items.Add(item);
            }
            {
                var category = new IngredientCategory() { Name = strNewCategory, Priority = 10000 };
                this.lstCategory.Items.Add(category);
                this.newCatetory = category;
                this.txtName.Text = strNewCategory;
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
            string name = this.txtName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("食材类别的名称不能为空！");
                return false;
            }

            IDictionary<string, IngredientCategory> ingredientDict = IngredientCategory.GetAll();
            if (ingredientDict.ContainsKey(this.newCatetory.Name))
            {
                MessageBox.Show(string.Format("已存在名为【{0}】的食材类别！", name), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            for (int i = 0; i < this.lstCategory.Items.Count; i++)
            {
                var obj = this.lstCategory.Items[i] as IngredientCategory;
                obj.Priority = i;
            }

            ingredientDict.Add(this.newCatetory.Name, this.newCatetory);
            IngredientCategory.SaveDatabase(typeof(IngredientCategory).Name);

            return true;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            this.newCatetory.Name = this.txtName.Text;
            for (int i = 0; i < this.lstCategory.Items.Count; i++)
            {
                if (this.lstCategory.Items[i] == this.newCatetory)
                {
                    this.lstCategory.Items[i] = this.lstCategory.Items[i];
                    break;
                }
            }
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

    }
}
