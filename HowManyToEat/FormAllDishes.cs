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
    public partial class FormAllDishes : Form
    {
        private List<Dish> selectedDishes = new List<Dish>();
        /// <summary>
        /// 
        /// </summary>
        public List<Dish> SelectedDishes
        {
            get { return selectedDishes; }
        }

        public FormAllDishes()
        {
            InitializeComponent();

            this.Load += FormAddDishToProject_Load;
        }

        void FormAddDishToProject_Load(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();

            IDictionary<Guid, Dish> dict = Dish.GetAll();
            var dishes = from item in dict.Values
                         orderby item.Priority
                         select item;
            foreach (var item in dishes)
            {
                var obj = new ListViewItem(item.Name) { Tag = item };
                this.listView1.Items.Add(obj);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var items = this.listView1.SelectedItems;
            if (items.Count > 0)
            {
                string msg = string.Empty;
                if (items.Count == 1)
                {
                    msg = string.Format("是否删除选中的菜品【{0}】？", (items[0].Tag as Dish).Name);
                }
                else
                {
                    msg = "是否删除选中的菜品？";
                }

                if (MessageBox.Show(msg, "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    IDictionary<Guid, Dish> dict = Dish.GetAll();

                    var list = new List<ListViewItem>();
                    foreach (var item in items)
                    {
                        var obj = item as ListViewItem;
                        list.Add(obj);
                    }
                    foreach (var item in list)
                    {
                        dict.Remove((item.Tag as Dish).Id);
                        this.listView1.Items.Remove(item);
                    }

                    Dish.SaveDatabase(typeof(Dish).Name);
                }
            }
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            this.btnDelete.Enabled = this.listView1.SelectedItems.Count > 0;
            this.btnUpdate.Enabled = this.listView1.SelectedItems.Count > 0;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
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

        private void btnDishSort_Click(object sender, EventArgs e)
        {
            var frm = new FormAllDishSorting();
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.FormAddDishToProject_Load(sender, e);
            }
        }

    }
}
