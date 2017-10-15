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
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("佐料", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("蔬菜", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("家禽", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup9 = new System.Windows.Forms.ListViewGroup("河鲜海鲜", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup10 = new System.Windows.Forms.ListViewGroup("主粮", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("盐");
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("油");
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem("酱油");
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem("醋");
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem("鸡精");
            System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem("白菜");
            System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem("鱼");
            System.Windows.Forms.ListViewItem listViewItem17 = new System.Windows.Forms.ListViewItem("猪肉");
            System.Windows.Forms.ListViewItem listViewItem18 = new System.Windows.Forms.ListViewItem("大米");
            this.lstIngredient = new System.Windows.Forms.ListView();
            this.btnSaveAndContinue = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstIngredient
            // 
            this.lstIngredient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstIngredient.Font = new System.Drawing.Font("宋体", 14F);
            listViewGroup6.Header = "佐料";
            listViewGroup6.Name = "listViewGroup1";
            listViewGroup7.Header = "蔬菜";
            listViewGroup7.Name = "listViewGroup2";
            listViewGroup8.Header = "家禽";
            listViewGroup8.Name = "listViewGroup3";
            listViewGroup9.Header = "河鲜海鲜";
            listViewGroup9.Name = "listViewGroup4";
            listViewGroup10.Header = "主粮";
            listViewGroup10.Name = "listViewGroup5";
            this.lstIngredient.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup6,
            listViewGroup7,
            listViewGroup8,
            listViewGroup9,
            listViewGroup10});
            listViewItem10.Group = listViewGroup6;
            listViewItem11.Group = listViewGroup6;
            listViewItem12.Group = listViewGroup6;
            listViewItem13.Group = listViewGroup6;
            listViewItem14.Group = listViewGroup6;
            listViewItem15.Group = listViewGroup7;
            listViewItem16.Group = listViewGroup9;
            listViewItem17.Group = listViewGroup8;
            listViewItem18.Group = listViewGroup10;
            this.lstIngredient.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem10,
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14,
            listViewItem15,
            listViewItem16,
            listViewItem17,
            listViewItem18});
            this.lstIngredient.Location = new System.Drawing.Point(12, 12);
            this.lstIngredient.Name = "lstIngredient";
            this.lstIngredient.Size = new System.Drawing.Size(718, 514);
            this.lstIngredient.TabIndex = 0;
            this.lstIngredient.UseCompatibleStateImageBehavior = false;
            this.lstIngredient.View = System.Windows.Forms.View.SmallIcon;
            this.lstIngredient.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstIngredient_ItemSelectionChanged);
            // 
            // btnSaveAndContinue
            // 
            this.btnSaveAndContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveAndContinue.Location = new System.Drawing.Point(106, 532);
            this.btnSaveAndContinue.Name = "btnSaveAndContinue";
            this.btnSaveAndContinue.Size = new System.Drawing.Size(88, 23);
            this.btnSaveAndContinue.TabIndex = 2;
            this.btnSaveAndContinue.Text = "修改";
            this.btnSaveAndContinue.UseVisualStyleBackColor = true;
            this.btnSaveAndContinue.Visible = false;
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
            // FormAllIngredients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(742, 567);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSaveAndContinue);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lstIngredient);
            this.Name = "FormAllIngredients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查看所有食材";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstIngredient;
        private System.Windows.Forms.Button btnSaveAndContinue;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
    }
}