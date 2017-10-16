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
    public partial class FormAllIngredientCategory : Form
    {
        public FormAllIngredientCategory()
        {
            InitializeComponent();

            this.Load += FormNewIngredientCategory_Load;
        }

        void FormNewIngredientCategory_Load(object sender, EventArgs e)
        {
            IDictionary<Guid, IngredientCategory> ingredientDict = IngredientCategory.GetAll();
            var list = from item in ingredientDict.Values
                       orderby item.Priority ascending
                       select item;
            foreach (var item in list)
            {
                this.lstCategory.Items.Add(item);
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
            for (int i = 0; i < this.lstCategory.Items.Count; i++)
            {
                var obj = this.lstCategory.Items[i] as IngredientCategory;
                obj.Priority = i;
            }

            IngredientCategory.SaveDatabase(typeof(IngredientCategory).Name);

            return true;
        }

        private void btnHighest_Click(object sender, EventArgs e)
        {
            int index = this.lstCategory.SelectedIndex;
            if (0 < index && index < this.lstCategory.Items.Count)
            {
                var item = this.lstCategory.Items[index];
                this.lstCategory.Items.Remove(item);
                this.lstCategory.Items.Insert(0, item);
                this.lstCategory.SelectedIndex = 0;
            }
        }

        private void btnHigher_Click(object sender, EventArgs e)
        {
            int index = this.lstCategory.SelectedIndex;
            if (0 < index && index < this.lstCategory.Items.Count)
            {
                var item = this.lstCategory.Items[index];
                this.lstCategory.Items.Remove(item);
                this.lstCategory.Items.Insert(index - 1, item);
                this.lstCategory.SelectedIndex = index - 1;
            }
        }

        private void btnLower_Click(object sender, EventArgs e)
        {
            int index = this.lstCategory.SelectedIndex;
            if (0 <= index && index + 1 < this.lstCategory.Items.Count)
            {
                var item = this.lstCategory.Items[index];
                this.lstCategory.Items.Remove(item);
                this.lstCategory.Items.Insert(index + 1, item);
                this.lstCategory.SelectedIndex = index + 1;
            }
        }

        private void btnLowest_Click(object sender, EventArgs e)
        {
            int index = this.lstCategory.SelectedIndex;
            if (0 <= index && index + 1 < this.lstCategory.Items.Count)
            {
                var item = this.lstCategory.Items[index];
                this.lstCategory.Items.Remove(item);
                this.lstCategory.Items.Add(item);
                this.lstCategory.SelectedIndex = this.lstCategory.Items.Count - 1;
            }
        }

    }
}
