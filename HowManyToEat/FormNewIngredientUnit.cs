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
    public partial class FormNewIngredientUnit : Form
    {
        private const string strNewCategory = "新单位名称";
        public FormNewIngredientUnit()
        {
            InitializeComponent();
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
            string name = this.txtName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("食材单位名称不能为空！");
                return false;
            }

            var unit = new IngredientUnit() { Name = name };
            IDictionary<Guid, IngredientUnit> unitDict = IngredientUnit.GetAll();
            var result = from item in unitDict.Values
                         where item.Name == unit.Name
                         select item;
            if (result.Count() > 0)
            {
                MessageBox.Show(string.Format("已存在名为【{0}】的食材单位名称！", name), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            unitDict.Add(unit.Id, unit);
            IngredientUnit.SaveDatabase(typeof(IngredientUnit).Name);

            return true;
        }

    }
}
