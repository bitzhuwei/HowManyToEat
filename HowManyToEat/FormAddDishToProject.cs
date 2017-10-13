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

            this.Load += FormAddDishToProject_Load;
        }

        void FormAddDishToProject_Load(object sender, EventArgs e)
        {
            IDictionary<string, Dish> dishList = Dish.GetAll();

            foreach (var item in dishList)
            {
                this.listView1.Items.Add(item.Key);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (var item in this.listView1.SelectedItems)
            {
                var dish = Dish.Select(item as string);
                this.SelectedDishes.Add(dish);
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnNewDish_Click(object sender, EventArgs e)
        {
            //(new FormNewDish()).ShowDialog();
        }
    }
}
