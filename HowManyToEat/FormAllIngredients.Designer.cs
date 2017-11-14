namespace HowManyToEat
{
    partial class FormAllIngredients
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("佐料", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("蔬菜", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("家禽", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("河鲜海鲜", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("主粮", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "盐"}, -1, System.Drawing.Color.Red, System.Drawing.Color.Empty, null);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("油");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("酱油");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("醋");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("鸡精");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("白菜");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("鱼");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("猪肉");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("大米");
            this.lstIngredient = new System.Windows.Forms.ListView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCategoryOrder = new System.Windows.Forms.Button();
            this.btnIngredientSort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstIngredient
            // 
            this.lstIngredient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstIngredient.Font = new System.Drawing.Font("宋体", 14F);
            listViewGroup1.Header = "佐料";
            listViewGroup1.Name = "listViewGroup1";
            listViewGroup2.Header = "蔬菜";
            listViewGroup2.Name = "listViewGroup2";
            listViewGroup3.Header = "家禽";
            listViewGroup3.Name = "listViewGroup3";
            listViewGroup4.Header = "河鲜海鲜";
            listViewGroup4.Name = "listViewGroup4";
            listViewGroup5.Header = "主粮";
            listViewGroup5.Name = "listViewGroup5";
            this.lstIngredient.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5});
            listViewItem1.Group = listViewGroup1;
            listViewItem2.Group = listViewGroup1;
            listViewItem3.Group = listViewGroup1;
            listViewItem4.Group = listViewGroup1;
            listViewItem5.Group = listViewGroup1;
            listViewItem6.Group = listViewGroup2;
            listViewItem7.Group = listViewGroup4;
            listViewItem8.Group = listViewGroup3;
            listViewItem9.Group = listViewGroup5;
            this.lstIngredient.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9});
            this.lstIngredient.Location = new System.Drawing.Point(12, 12);
            this.lstIngredient.Name = "lstIngredient";
            this.lstIngredient.Size = new System.Drawing.Size(718, 514);
            this.lstIngredient.TabIndex = 0;
            this.lstIngredient.UseCompatibleStateImageBehavior = false;
            this.lstIngredient.View = System.Windows.Forms.View.SmallIcon;
            this.lstIngredient.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstIngredient_ItemSelectionChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdate.Location = new System.Drawing.Point(106, 532);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(88, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(666, 532);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "关闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(12, 532);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCategoryOrder
            // 
            this.btnCategoryOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCategoryOrder.Location = new System.Drawing.Point(315, 532);
            this.btnCategoryOrder.Name = "btnCategoryOrder";
            this.btnCategoryOrder.Size = new System.Drawing.Size(88, 23);
            this.btnCategoryOrder.TabIndex = 2;
            this.btnCategoryOrder.Text = "类别排序...";
            this.btnCategoryOrder.UseVisualStyleBackColor = true;
            this.btnCategoryOrder.Click += new System.EventHandler(this.btnCategoryOrder_Click);
            // 
            // btnIngredientSort
            // 
            this.btnIngredientSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIngredientSort.Location = new System.Drawing.Point(200, 532);
            this.btnIngredientSort.Name = "btnIngredientSort";
            this.btnIngredientSort.Size = new System.Drawing.Size(88, 23);
            this.btnIngredientSort.TabIndex = 2;
            this.btnIngredientSort.Text = "食材排序...";
            this.btnIngredientSort.UseVisualStyleBackColor = true;
            this.btnIngredientSort.Click += new System.EventHandler(this.btnIngredientSort_Click);
            // 
            // FormAllIngredients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(742, 567);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCategoryOrder);
            this.Controls.Add(this.btnIngredientSort);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lstIngredient);
            this.Name = "FormAllIngredients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查看所有食材";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstIngredient;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCategoryOrder;
        private System.Windows.Forms.Button btnIngredientSort;
    }
}