﻿using System;
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

            IDictionary<string, Dish> dict = Dish.GetAll();

            foreach (var item in dict)
            {
                var obj = new ListViewItem(item.Key) { Tag = item.Value };
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
                if (MessageBox.Show("是否删除选中的菜品？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    IDictionary<string, Dish> dict = Dish.GetAll();

                    var list = new List<ListViewItem>();
                    foreach (var item in items)
                    {
                        var obj = item as ListViewItem;
                        list.Add(obj);
                    }
                    foreach (var item in list)
                    {
                        dict.Remove(item.Text);
                        this.listView1.Items.Remove(item);
                    }

                    Dish.SaveDatabase(typeof(Dish).Name);
                }
            }
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            this.btnDelete.Enabled = this.listView1.SelectedItems.Count > 0;
        }

    }
}