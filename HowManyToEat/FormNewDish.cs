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

            this.Load += FormNewDish_Load;
        }

        void FormNewDish_Load(object sender, EventArgs e)
        {
            this.lstIngredient.Items.Clear();
            IDictionary<string, Ingredient> ingredientDict = Ingredient.GetAll();
            var groups = new Dictionary<string, ListViewGroup>();
            foreach (var item in ingredientDict)
            {
                string name = item.Key;
                string category = item.Value.Category.Name;
                if (!groups.ContainsKey(category))
                {
                    var group = new ListViewGroup(category);
                    groups.Add(category, group);
                    this.lstIngredient.Groups.Add(group);
                }
                this.lstIngredient.Items.Add(new ListViewItem(name, groups[category]));
            }
        }

        private int curentViewIndex = 3;
        private static readonly View[] views = new View[] { View.Details, View.LargeIcon, View.List, View.SmallIcon, View.Tile };
        private void btnSwitchView_Click(object sender, EventArgs e)
        {
            this.lstIngredient.View = views[(curentViewIndex + 1) % views.Length];
            this.lstSelectedIngredient.View = views[(curentViewIndex + 1) % views.Length];
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
