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
            ReloadDishes();
        }

        private void ReloadDishes()
        {
            this.listView1.Items.Clear();

            IDictionary<Guid, Dish> dishList = Dish.GetAll();

            foreach (var item in dishList)
            {
                var obj = new ListViewItem(item.Value.Name) { Tag = item.Value };
                this.listView1.Items.Add(obj);
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
                var obj = item as ListViewItem;
                this.SelectedDishes.Add(obj.Tag as Dish);
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnNewDish_Click(object sender, EventArgs e)
        {
            var frm = new FormNewDish();
            frm.ShowDialog();

            foreach (var item in frm.NewDishList)
            {
                var obj = new ListViewItem(item.Name) { Tag = item };
                this.listView1.Items.Add(obj);
            }
        }

        private void btnUpdateDish_Click(object sender, EventArgs e)
        {
            foreach (var item in this.listView1.SelectedItems)
            {
                var obj = item as ListViewItem;
                var dish = obj.Tag as Dish;
                var frm = new FormUpdateDish(dish);
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    obj.Text = dish.Name;
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnUpdateDish.Enabled = this.listView1.SelectedItems.Count > 0;
        }

        private int curentViewIndex = 3;
        private static readonly View[] views = new View[] { View.Details, View.LargeIcon, View.List, View.SmallIcon, View.Tile };
        private void btnSwitchView_Click(object sender, EventArgs e)
        {
            this.listView1.View = views[(curentViewIndex + 1) % views.Length];
            curentViewIndex++;
            if (curentViewIndex > 1000)
            {
                curentViewIndex = curentViewIndex % views.Length;
            }
        }
    }
}
