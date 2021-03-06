﻿namespace HowManyToEat
{
    partial class FormUpdateDish
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("盐");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("油");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("酱油");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("醋");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("鸡精");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("白菜");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("鱼");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("猪肉");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("大米");
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("佐料", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("蔬菜", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("家禽", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup9 = new System.Windows.Forms.ListViewGroup("河鲜海鲜", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup10 = new System.Windows.Forms.ListViewGroup("主粮", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("盐 20克");
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("油 10克");
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem("酱油 10克");
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem("醋 15克");
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem("大米 5两");
            this.btnModifyIngredient = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNewIngrendient = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lstIngredient = new System.Windows.Forms.ListView();
            this.lstSelectedIngredient = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSwitchView = new System.Windows.Forms.Button();
            this.btnAddIngredientToDish = new System.Windows.Forms.Button();
            this.btnRemoveIngredientFromDish = new System.Windows.Forms.Button();
            this.btnModifyWeightedIngredient = new System.Windows.Forms.Button();
            this.txtDishName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnModifyIngredient
            // 
            this.btnModifyIngredient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnModifyIngredient.Enabled = false;
            this.btnModifyIngredient.Location = new System.Drawing.Point(242, 476);
            this.btnModifyIngredient.Name = "btnModifyIngredient";
            this.btnModifyIngredient.Size = new System.Drawing.Size(109, 23);
            this.btnModifyIngredient.TabIndex = 10;
            this.btnModifyIngredient.Text = "修改选中的食材...";
            this.btnModifyIngredient.UseVisualStyleBackColor = true;
            this.btnModifyIngredient.Click += new System.EventHandler(this.btnModifyIngredient_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(866, 476);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "关闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNewIngrendient
            // 
            this.btnNewIngrendient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewIngrendient.Location = new System.Drawing.Point(127, 476);
            this.btnNewIngrendient.Name = "btnNewIngrendient";
            this.btnNewIngrendient.Size = new System.Drawing.Size(109, 23);
            this.btnNewIngrendient.TabIndex = 9;
            this.btnNewIngrendient.Text = "录入新食材...";
            this.btnNewIngrendient.UseVisualStyleBackColor = true;
            this.btnNewIngrendient.Click += new System.EventHandler(this.btnNewIngrendient_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F);
            this.label1.Location = new System.Drawing.Point(19, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(600, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "请在下方列表中选择您需要的食材（双击或选中后点击\"添加->\"按钮）";
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
            this.lstIngredient.Location = new System.Drawing.Point(12, 66);
            this.lstIngredient.Name = "lstIngredient";
            this.lstIngredient.Size = new System.Drawing.Size(607, 404);
            this.lstIngredient.TabIndex = 1;
            this.lstIngredient.UseCompatibleStateImageBehavior = false;
            this.lstIngredient.View = System.Windows.Forms.View.SmallIcon;
            this.lstIngredient.DoubleClick += new System.EventHandler(this.lstIngredient_DoubleClick);
            // 
            // lstSelectedIngredient
            // 
            this.lstSelectedIngredient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSelectedIngredient.Font = new System.Drawing.Font("宋体", 14F);
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
            this.lstSelectedIngredient.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup6,
            listViewGroup7,
            listViewGroup8,
            listViewGroup9,
            listViewGroup10});
            listViewItem10.Group = listViewGroup6;
            listViewItem11.Group = listViewGroup6;
            listViewItem12.Group = listViewGroup6;
            listViewItem13.Group = listViewGroup6;
            listViewItem14.Group = listViewGroup10;
            this.lstSelectedIngredient.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem10,
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14});
            this.lstSelectedIngredient.Location = new System.Drawing.Point(706, 66);
            this.lstSelectedIngredient.Name = "lstSelectedIngredient";
            this.lstSelectedIngredient.Size = new System.Drawing.Size(224, 404);
            this.lstSelectedIngredient.TabIndex = 5;
            this.lstSelectedIngredient.UseCompatibleStateImageBehavior = false;
            this.lstSelectedIngredient.View = System.Windows.Forms.View.SmallIcon;
            this.lstSelectedIngredient.DoubleClick += new System.EventHandler(this.lstSelectedIngredient_DoubleClick);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14F);
            this.label2.Location = new System.Drawing.Point(718, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "所需食材的种类和数量";
            // 
            // btnSwitchView
            // 
            this.btnSwitchView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSwitchView.Location = new System.Drawing.Point(12, 476);
            this.btnSwitchView.Name = "btnSwitchView";
            this.btnSwitchView.Size = new System.Drawing.Size(109, 23);
            this.btnSwitchView.TabIndex = 8;
            this.btnSwitchView.Text = "切换视图";
            this.btnSwitchView.UseVisualStyleBackColor = true;
            this.btnSwitchView.Click += new System.EventHandler(this.btnSwitchView_Click);
            // 
            // btnAddIngredientToDish
            // 
            this.btnAddIngredientToDish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddIngredientToDish.Font = new System.Drawing.Font("宋体", 14F);
            this.btnAddIngredientToDish.Location = new System.Drawing.Point(625, 109);
            this.btnAddIngredientToDish.Name = "btnAddIngredientToDish";
            this.btnAddIngredientToDish.Size = new System.Drawing.Size(75, 50);
            this.btnAddIngredientToDish.TabIndex = 2;
            this.btnAddIngredientToDish.Text = "添加->";
            this.btnAddIngredientToDish.UseVisualStyleBackColor = true;
            this.btnAddIngredientToDish.Click += new System.EventHandler(this.btnAddIngredientToDish_Click);
            // 
            // btnRemoveIngredientFromDish
            // 
            this.btnRemoveIngredientFromDish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveIngredientFromDish.Font = new System.Drawing.Font("宋体", 14F);
            this.btnRemoveIngredientFromDish.Location = new System.Drawing.Point(625, 165);
            this.btnRemoveIngredientFromDish.Name = "btnRemoveIngredientFromDish";
            this.btnRemoveIngredientFromDish.Size = new System.Drawing.Size(75, 50);
            this.btnRemoveIngredientFromDish.TabIndex = 3;
            this.btnRemoveIngredientFromDish.Text = "<-撤回";
            this.btnRemoveIngredientFromDish.UseVisualStyleBackColor = true;
            this.btnRemoveIngredientFromDish.Click += new System.EventHandler(this.btnRemoveIngredientFromDish_Click);
            // 
            // btnModifyWeightedIngredient
            // 
            this.btnModifyWeightedIngredient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModifyWeightedIngredient.Font = new System.Drawing.Font("宋体", 14F);
            this.btnModifyWeightedIngredient.Location = new System.Drawing.Point(625, 221);
            this.btnModifyWeightedIngredient.Name = "btnModifyWeightedIngredient";
            this.btnModifyWeightedIngredient.Size = new System.Drawing.Size(75, 50);
            this.btnModifyWeightedIngredient.TabIndex = 4;
            this.btnModifyWeightedIngredient.Text = "修改";
            this.btnModifyWeightedIngredient.UseVisualStyleBackColor = true;
            this.btnModifyWeightedIngredient.Click += new System.EventHandler(this.btnModifyWeightedIngredient_Click);
            // 
            // txtDishName
            // 
            this.txtDishName.Font = new System.Drawing.Font("宋体", 14F);
            this.txtDishName.Location = new System.Drawing.Point(118, 12);
            this.txtDishName.Name = "txtDishName";
            this.txtDishName.Size = new System.Drawing.Size(271, 29);
            this.txtDishName.TabIndex = 0;
            this.txtDishName.Text = "一碗米饭";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14F);
            this.label3.Location = new System.Drawing.Point(8, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "菜品名称：";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(763, 476);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(97, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 14F);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(484, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(446, 19);
            this.label6.TabIndex = 17;
            this.label6.Text = "注意：修改菜品信息将影响所有使用此菜品的方案！";
            // 
            // FormUpdateDish
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(942, 511);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDishName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnModifyIngredient);
            this.Controls.Add(this.btnModifyWeightedIngredient);
            this.Controls.Add(this.btnRemoveIngredientFromDish);
            this.Controls.Add(this.btnAddIngredientToDish);
            this.Controls.Add(this.btnSwitchView);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNewIngrendient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstSelectedIngredient);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstIngredient);
            this.Name = "FormUpdateDish";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改菜品信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnModifyIngredient;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNewIngrendient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstIngredient;
        private System.Windows.Forms.ListView lstSelectedIngredient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSwitchView;
        private System.Windows.Forms.Button btnAddIngredientToDish;
        private System.Windows.Forms.Button btnRemoveIngredientFromDish;
        private System.Windows.Forms.Button btnModifyWeightedIngredient;
        private System.Windows.Forms.TextBox txtDishName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label6;
    }
}