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
    public partial class FormAddDishToProject : Form
    {
        private List<Dish> selectedDishes = new List<Dish>();

        /// <summary>
        /// 
        /// </summary>
        public List<Dish> SelectedDishes
        {
            get { return selectedDishes; }
        }

        public FormAddDishToProject()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (new FormNewDish()).ShowDialog();
        }
    }
}
