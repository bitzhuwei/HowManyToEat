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
    public partial class FormNewDish : Form
    {
        public FormNewDish()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //(new FormNewIngrendient()).ShowDialog();
            (new FormAddIngredientToDish()).ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var items = this.listView1.SelectedItems;
            foreach (var item in items)
            {
                this.listView1.Items.Remove(item as ListViewItem);
            }
        }
    }
}
