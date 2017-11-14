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
    public partial class FormAllDishSorting : Form
    {
        public FormAllDishSorting()
        {
            InitializeComponent();

            this.Load += FormAllDishSorting_Load;

            this.lstDish.MouseDown += listDish_MouseDown;
            this.lstDish.DragOver += lstDish_DragOver;
            this.lstDish.DragDrop += lstDish_DragDrop;
        }

        void lstDish_DragDrop(object sender, DragEventArgs e)
        {
            Point point = this.lstDish.PointToClient(new Point(e.X, e.Y));
            int index = this.lstDish.IndexFromPoint(point);
            if (index < 0)
            {
                index = this.lstDish.Items.Count - 1;
            }
            //获取拖放的数据内容
            object data = e.Data.GetData(typeof(Dish));
            //删除元数据
            this.lstDish.Items.Remove(data);
            //插入目标数据
            this.lstDish.Items.Insert(index, data);
        }

        void lstDish_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        void listDish_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.lstDish.SelectedItem == null)
            {
                return;
            }
            //开始拖放操作，DragDropEffects为枚举类型。
            //DragDropEffects.Move 为将源数据移动到目标数据
            this.lstDish.DoDragDrop(this.lstDish.SelectedItem, DragDropEffects.Move);
        }

        void FormAllDishSorting_Load(object sender, EventArgs e)
        {
            IDictionary<Guid, Dish> dishDict = Dish.GetAll();
            var list = from item in dishDict.Values
                       orderby item.Priority ascending
                       select item;
            foreach (var item in list)
            {
                this.lstDish.Items.Add(item);
            }
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
            for (int i = 0; i < this.lstDish.Items.Count; i++)
            {
                var obj = this.lstDish.Items[i] as Dish;
                obj.Priority = i;
            }

            Dish.SaveDatabase(typeof(Dish).Name);

            return true;
        }

        private void btnHighest_Click(object sender, EventArgs e)
        {
            int index = this.lstDish.SelectedIndex;
            if (0 < index && index < this.lstDish.Items.Count)
            {
                var item = this.lstDish.Items[index];
                this.lstDish.Items.Remove(item);
                this.lstDish.Items.Insert(0, item);
                this.lstDish.SelectedIndex = 0;
            }
        }

        private void btnHigher_Click(object sender, EventArgs e)
        {
            int index = this.lstDish.SelectedIndex;
            if (0 < index && index < this.lstDish.Items.Count)
            {
                var item = this.lstDish.Items[index];
                this.lstDish.Items.Remove(item);
                this.lstDish.Items.Insert(index - 1, item);
                this.lstDish.SelectedIndex = index - 1;
            }
        }

        private void btnLower_Click(object sender, EventArgs e)
        {
            int index = this.lstDish.SelectedIndex;
            if (0 <= index && index + 1 < this.lstDish.Items.Count)
            {
                var item = this.lstDish.Items[index];
                this.lstDish.Items.Remove(item);
                this.lstDish.Items.Insert(index + 1, item);
                this.lstDish.SelectedIndex = index + 1;
            }
        }

        private void btnLowest_Click(object sender, EventArgs e)
        {
            int index = this.lstDish.SelectedIndex;
            if (0 <= index && index + 1 < this.lstDish.Items.Count)
            {
                var item = this.lstDish.Items[index];
                this.lstDish.Items.Remove(item);
                this.lstDish.Items.Add(item);
                this.lstDish.SelectedIndex = this.lstDish.Items.Count - 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var items = this.lstDish.SelectedItems;
            if (items.Count > 0)
            {
                string msg = string.Empty;
                if (items.Count == 1)
                {
                    msg = string.Format("是否删除选中的菜品【{0}】？", (items[0] as Dish).Name);
                }
                else
                {
                    msg = "是否删除选中的菜品？";
                }

                if (MessageBox.Show(msg, "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    IDictionary<Guid, Dish> dict = Dish.GetAll();

                    foreach (var item in items)
                    {
                        dict.Remove((item as Dish).Id);
                        this.lstDish.Items.Remove(item);
                    }

                    Dish.SaveDatabase(typeof(Dish).Name);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var index = this.lstDish.SelectedIndex;
            if (0 <= index && index < this.lstDish.Items.Count)
            {
                var dish = this.lstDish.Items[index] as Dish;
                var frm = new FormUpdateDish(dish);
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.lstDish.Items[index] = dish;
                }
            }
        }
    }
}
