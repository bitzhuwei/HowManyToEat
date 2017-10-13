namespace HowManyToEat
{
    partial class FormNewDish
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup11 = new System.Windows.Forms.ListViewGroup("佐料", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup12 = new System.Windows.Forms.ListViewGroup("蔬菜", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup13 = new System.Windows.Forms.ListViewGroup("家禽", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup14 = new System.Windows.Forms.ListViewGroup("河鲜海鲜", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup15 = new System.Windows.Forms.ListViewGroup("主粮", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem("盐");
            System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem("油");
            System.Windows.Forms.ListViewItem listViewItem17 = new System.Windows.Forms.ListViewItem("酱油");
            System.Windows.Forms.ListViewItem listViewItem18 = new System.Windows.Forms.ListViewItem("醋");
            System.Windows.Forms.ListViewItem listViewItem19 = new System.Windows.Forms.ListViewItem("鸡精");
            System.Windows.Forms.ListViewItem listViewItem20 = new System.Windows.Forms.ListViewItem("白菜");
            System.Windows.Forms.ListViewItem listViewItem21 = new System.Windows.Forms.ListViewItem("鱼");
            System.Windows.Forms.ListViewItem listViewItem22 = new System.Windows.Forms.ListViewItem("猪肉");
            System.Windows.Forms.ListViewItem listViewItem23 = new System.Windows.Forms.ListViewItem("大米");
            System.Windows.Forms.ListViewGroup listViewGroup16 = new System.Windows.Forms.ListViewGroup("佐料", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup17 = new System.Windows.Forms.ListViewGroup("蔬菜", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup18 = new System.Windows.Forms.ListViewGroup("家禽", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup19 = new System.Windows.Forms.ListViewGroup("河鲜海鲜", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup20 = new System.Windows.Forms.ListViewGroup("主粮", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem24 = new System.Windows.Forms.ListViewItem("盐 20克");
            System.Windows.Forms.ListViewItem listViewItem25 = new System.Windows.Forms.ListViewItem("油 10克");
            System.Windows.Forms.ListViewItem listViewItem26 = new System.Windows.Forms.ListViewItem("酱油 10克");
            System.Windows.Forms.ListViewItem listViewItem27 = new System.Windows.Forms.ListViewItem("醋 15克");
            System.Windows.Forms.ListViewItem listViewItem28 = new System.Windows.Forms.ListViewItem("大米 5两");
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
            this.btnSaveAndContinue = new System.Windows.Forms.Button();
            this.lblSucessTip = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
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
            this.btnModifyIngredient.Visible = false;
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
            this.btnNewIngrendient.Visible = false;
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
            listViewGroup11.Header = "佐料";
            listViewGroup11.Name = "listViewGroup1";
            listViewGroup12.Header = "蔬菜";
            listViewGroup12.Name = "listViewGroup2";
            listViewGroup13.Header = "家禽";
            listViewGroup13.Name = "listViewGroup3";
            listViewGroup14.Header = "河鲜海鲜";
            listViewGroup14.Name = "listViewGroup4";
            listViewGroup15.Header = "主粮";
            listViewGroup15.Name = "listViewGroup5";
            this.lstIngredient.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup11,
            listViewGroup12,
            listViewGroup13,
            listViewGroup14,
            listViewGroup15});
            listViewItem15.Group = listViewGroup11;
            listViewItem16.Group = listViewGroup11;
            listViewItem17.Group = listViewGroup11;
            listViewItem18.Group = listViewGroup11;
            listViewItem19.Group = listViewGroup11;
            listViewItem20.Group = listViewGroup12;
            listViewItem21.Group = listViewGroup14;
            listViewItem22.Group = listViewGroup13;
            listViewItem23.Group = listViewGroup15;
            this.lstIngredient.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem15,
            listViewItem16,
            listViewItem17,
            listViewItem18,
            listViewItem19,
            listViewItem20,
            listViewItem21,
            listViewItem22,
            listViewItem23});
            this.lstIngredient.Location = new System.Drawing.Point(12, 66);
            this.lstIngredient.Name = "lstIngredient";
            this.lstIngredient.Size = new System.Drawing.Size(607, 404);
            this.lstIngredient.TabIndex = 1;
            this.lstIngredient.UseCompatibleStateImageBehavior = false;
            this.lstIngredient.View = System.Windows.Forms.View.SmallIcon;
            // 
            // lstSelectedIngredient
            // 
            this.lstSelectedIngredient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSelectedIngredient.Font = new System.Drawing.Font("宋体", 14F);
            listViewGroup16.Header = "佐料";
            listViewGroup16.Name = "listViewGroup1";
            listViewGroup17.Header = "蔬菜";
            listViewGroup17.Name = "listViewGroup2";
            listViewGroup18.Header = "家禽";
            listViewGroup18.Name = "listViewGroup3";
            listViewGroup19.Header = "河鲜海鲜";
            listViewGroup19.Name = "listViewGroup4";
            listViewGroup20.Header = "主粮";
            listViewGroup20.Name = "listViewGroup5";
            this.lstSelectedIngredient.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup16,
            listViewGroup17,
            listViewGroup18,
            listViewGroup19,
            listViewGroup20});
            listViewItem24.Group = listViewGroup16;
            listViewItem25.Group = listViewGroup16;
            listViewItem26.Group = listViewGroup16;
            listViewItem27.Group = listViewGroup16;
            listViewItem28.Group = listViewGroup20;
            this.lstSelectedIngredient.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem24,
            listViewItem25,
            listViewItem26,
            listViewItem27,
            listViewItem28});
            this.lstSelectedIngredient.Location = new System.Drawing.Point(706, 66);
            this.lstSelectedIngredient.Name = "lstSelectedIngredient";
            this.lstSelectedIngredient.Size = new System.Drawing.Size(224, 404);
            this.lstSelectedIngredient.TabIndex = 5;
            this.lstSelectedIngredient.UseCompatibleStateImageBehavior = false;
            this.lstSelectedIngredient.View = System.Windows.Forms.View.SmallIcon;
            // 
            // label2
            // 
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
            this.btnAddIngredientToDish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.btnRemoveIngredientFromDish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.btnModifyWeightedIngredient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            // btnSaveAndContinue
            // 
            this.btnSaveAndContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndContinue.Location = new System.Drawing.Point(698, 476);
            this.btnSaveAndContinue.Name = "btnSaveAndContinue";
            this.btnSaveAndContinue.Size = new System.Drawing.Size(162, 23);
            this.btnSaveAndContinue.TabIndex = 6;
            this.btnSaveAndContinue.Text = "保存并继续录入新菜品";
            this.btnSaveAndContinue.UseVisualStyleBackColor = true;
            this.btnSaveAndContinue.Click += new System.EventHandler(this.btnSaveAndContinue_Click);
            // 
            // lblSucessTip
            // 
            this.lblSucessTip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSucessTip.AutoSize = true;
            this.lblSucessTip.Font = new System.Drawing.Font("宋体", 14F);
            this.lblSucessTip.ForeColor = System.Drawing.Color.Green;
            this.lblSucessTip.Location = new System.Drawing.Point(588, 480);
            this.lblSucessTip.Name = "lblSucessTip";
            this.lblSucessTip.Size = new System.Drawing.Size(104, 19);
            this.lblSucessTip.TabIndex = 16;
            this.lblSucessTip.Text = "保存成功！";
            this.lblSucessTip.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormNewDish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 511);
            this.Controls.Add(this.lblSucessTip);
            this.Controls.Add(this.txtDishName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnModifyIngredient);
            this.Controls.Add(this.btnModifyWeightedIngredient);
            this.Controls.Add(this.btnRemoveIngredientFromDish);
            this.Controls.Add(this.btnAddIngredientToDish);
            this.Controls.Add(this.btnSwitchView);
            this.Controls.Add(this.btnSaveAndContinue);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNewIngrendient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstSelectedIngredient);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstIngredient);
            this.Name = "FormNewDish";
            this.Text = "录入新菜品";
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
        private System.Windows.Forms.Button btnSaveAndContinue;
        private System.Windows.Forms.Label lblSucessTip;
        private System.Windows.Forms.Timer timer1;
    }
}