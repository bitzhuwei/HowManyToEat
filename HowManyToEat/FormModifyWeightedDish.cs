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
    public partial class FormModifyWeightedDish : Form
    {
        private WeightedDish weightedDish;
        public FormModifyWeightedDish(WeightedDish weightedDish)
        {
            InitializeComponent();

            this.weightedDish = weightedDish;

            this.txtName.Text = weightedDish.Dish.Name;
            this.txtCount.Text = weightedDish.Count.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int value;
            if (!int.TryParse(this.txtCount.Text, out value))
            {
                MessageBox.Show(string.Format("数量格式【{0}】错误，无法解析！", this.txtCount.Text), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.weightedDish.Count = value;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
