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
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
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
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Font = new System.Drawing.Font("宋体", 14F);
            this.button3.Location = new System.Drawing.Point(625, 109);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 50);
            this.button3.TabIndex = 2;
            this.button3.Text = "添加->";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnSwitchView_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.Font = new System.Drawing.Font("宋体", 14F);
            this.button4.Location = new System.Drawing.Point(625, 165);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 50);
            this.button4.TabIndex = 3;
            this.button4.Text = "<-撤回";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnSwitchView_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button5.Font = new System.Drawing.Font("宋体", 14F);
            this.button5.Location = new System.Drawing.Point(625, 221);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 50);
            this.button5.TabIndex = 4;
            this.button5.Text = "修改";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.btnSwitchView_Click);
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
            // 
            // lblSucessTip
            // 
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
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
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
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox txtDishName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSaveAndContinue;
        private System.Windows.Forms.Label lblSucessTip;
        private System.Windows.Forms.Timer timer1;
    }
}