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
    public partial class FormUpdateWeightedIngrendient : Form
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
        /// <param name="weightedIngredient"></param>
        public FormUpdateWeightedIngrendient(WeightedIngredient weightedIngredient)
        {
            InitializeComponent();

            if (weightedIngredient == null) { throw new ArgumentNullException("weightedIngredient"); }

            this.weighted = weightedIngredient;

            this.FillView(weightedIngredient.Ingredient);

            this.txtWeight.Text = weightedIngredient.Weight.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            float value;
            if (!float.TryParse(this.txtWeight.Text, out value))
            {
                MessageBox.Show(string.Format("数量格式【{0}】异常，无法解析！", this.txtWeight.Text), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.weighted.Weight = value;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnUpdateIngredient_Click(object sender, EventArgs e)
        {
            var frm = new FormUpdateIngredient(this.weighted.Ingredient);
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FillView(this.weighted.Ingredient);
            }
        }

        private void FillView(Ingredient ingredient)
        {
            Color color = ingredient.ForeColor;
            this.txtName.Text = ingredient.Name;
            this.txtName.ForeColor = color;
            this.txtCategory.Text = ingredient.Category.ToString();
            this.txtUnit.Text = ingredient.Unit.ToString();
            this.lblColorDisplay.BackColor = color;
            this.lblColor.Text = string.Format("R:{0}, G:{1}, B:{2}", color.R, color.G, color.B);
            this.txtPrice.Text = ingredient.Price.ToString();
        }
    }
}
