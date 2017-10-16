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
    public partial class FormUpdateIngredientCategory : Form
    {
        private IngredientCategory category;
        public FormUpdateIngredientCategory(IngredientCategory category)
        {
            InitializeComponent();

            if (category == null) { throw new ArgumentNullException("category"); }

            this.category = category;
            this.txtName.Text = category.Name;
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

            this.category.Name = this.txtName.Text.Trim();
            IngredientCategory.SaveDatabase(typeof(IngredientCategory).Name);

            return true;
        }
    }
}
