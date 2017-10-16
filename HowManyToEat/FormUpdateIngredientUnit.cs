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
    public partial class FormUpdateIngredientUnit : Form
    {
        private IngredientUnit unit;
        public FormUpdateIngredientUnit(IngredientUnit unit)
        {
            InitializeComponent();

            if (unit == null) { throw new ArgumentNullException("category"); }

            this.unit = unit;
            this.txtName.Text = unit.Name;
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
                MessageBox.Show("食材单位名称不能为空！");
                return false;
            }

            this.unit.Name = this.txtName.Text.Trim();
            IngredientUnit.SaveDatabase(typeof(IngredientUnit).Name);

            return true;
        }
    }
}
