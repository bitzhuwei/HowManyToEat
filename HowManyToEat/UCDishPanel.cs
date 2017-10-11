using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HowManyToEat
{
    public partial class UCDishPanel : UserControl
    {
        public UCDishPanel(string dishName)
        {
            InitializeComponent();

            if (dishName == "YuXiangRouSi")
            {
                YuXiangRouSi();
            }
            else if (dishName == "DouYaCai")
            {
                DouYaCai();
            }
            else if (dishName == "Other")
            {
                Other();
            }
        }

        private void Other()
        {
            this.listView1.Items.Add("某料1 x1克");
            this.listView1.Items.Add("某料2 x2斤");
            this.listView1.Items.Add("某料3 x3两");
            this.listView1.Items.Add("某料4 x4克");
        }

        private void DouYaCai()
        {
            this.listView1.Items.Add("盐 1克");
            this.listView1.Items.Add("酱油 6克");
            this.listView1.Items.Add("味精 3克");
            this.listView1.Items.Add("豆芽 2两");
            this.listView1.Items.Add("油 15克");
        }

        private void YuXiangRouSi()
        {
            this.listView1.Items.Add("盐 1克");
            this.listView1.Items.Add("味精 0.5克");
            this.listView1.Items.Add("鸡精 1克");
            this.listView1.Items.Add("油 8克");
            this.listView1.Items.Add("鸡肉 3两");
            this.listView1.Items.Add("青椒 2两");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (new FormAddIngredientToDish()).ShowDialog();
        }
    }
}
