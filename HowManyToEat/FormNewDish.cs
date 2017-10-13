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

        private int curentViewIndex = 3;
        private static readonly View[] views = new View[] { View.Details, View.LargeIcon, View.List, View.SmallIcon, View.Tile };
        private void btnSwitchView_Click(object sender, EventArgs e)
        {
            this.listView1.View = views[(curentViewIndex + 1) % views.Length];
            this.listView2.View = views[(curentViewIndex + 1) % views.Length];
            curentViewIndex++;
            if (curentViewIndex > 1000)
            {
                curentViewIndex = curentViewIndex % views.Length;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.lblSucessTip.Visible = false;
        }
    }
}
