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
    public partial class FormModifyWeightedIngrendient : Form
    {
        private WeightedIngredient weighted;

        /// <summary>
        /// 
        /// </summary>
        public WeightedIngredient Weighted
        {
            get { return weighted; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="weighted"></param>
        public FormModifyWeightedIngrendient(WeightedIngredient weighted)
        {
            InitializeComponent();

            this.weighted = weighted;

            this.txtName.Text = weighted.Ingredient.Name;
            this.txtCategory.Text = weighted.Ingredient.Category.ToString();
            this.txtUnit.Text = weighted.Ingredient.Unit.ToString();
            this.txtWeight.Text = weighted.Weight.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            float value;
            if (!float.TryParse(this.txtWeight.Text, out value))
            {
                MessageBox.Show(string.Format("数量格式[{0}]异常，无法解析！", this.txtWeight.Text), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.weighted.Weight = value;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
