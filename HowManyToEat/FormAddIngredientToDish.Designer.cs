namespace HowManyToEat
{
    partial class FormAddIngredientToDish
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
            System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem("盐");
            System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem("油");
            System.Windows.Forms.ListViewItem listViewItem17 = new System.Windows.Forms.ListViewItem("酱油");
            System.Windows.Forms.ListViewItem listViewItem18 = new System.Windows.Forms.ListViewItem("醋");
            System.Windows.Forms.ListViewItem listViewItem19 = new System.Windows.Forms.ListViewItem("鸡精");
            System.Windows.Forms.ListViewItem listViewItem20 = new System.Windows.Forms.ListViewItem("白菜");
            System.Windows.Forms.ListViewItem listViewItem21 = new System.Windows.Forms.ListViewItem("鱼");
            System.Windows.Forms.ListViewItem listViewItem22 = new System.Windows.Forms.ListViewItem("猪肉");
            System.Windows.Forms.ListViewItem listViewItem23 = new System.Windows.Forms.ListViewItem("大米");
            System.Windows.Forms.ListViewItem listViewItem24 = new System.Windows.Forms.ListViewItem("盐 20克");
            System.Windows.Forms.ListViewItem listViewItem25 = new System.Windows.Forms.ListViewItem("油 10克");
            System.Windows.Forms.ListViewItem listViewItem26 = new System.Windows.Forms.ListViewItem("酱油 10克");
            System.Windows.Forms.ListViewItem listViewItem27 = new System.Windows.Forms.ListViewItem("醋 15克");
            System.Windows.Forms.ListViewItem listViewItem28 = new System.Windows.Forms.ListViewItem("大米 5两");
            this.button2 = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(411, 60);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "修改选中的食材...";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(300, 514);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(109, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(415, 514);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(411, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "录入新食材...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(503, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "请在下方列表中选择您需要的食材（双击添加到下方列表）";
            // 
            // listView1
            // 
            this.listView1.Font = new System.Drawing.Font("宋体", 14F);
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem15,
            listViewItem16,
            listViewItem17,
            listViewItem18,
            listViewItem19,
            listViewItem20,
            listViewItem21,
            listViewItem22,
            listViewItem23});
            this.listView1.Location = new System.Drawing.Point(12, 31);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(375, 214);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // listView2
            // 
            this.listView2.Font = new System.Drawing.Font("宋体", 14F);
            this.listView2.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem24,
            listViewItem25,
            listViewItem26,
            listViewItem27,
            listViewItem28});
            this.listView2.Location = new System.Drawing.Point(12, 286);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(375, 214);
            this.listView2.TabIndex = 3;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.List;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14F);
            this.label2.Location = new System.Drawing.Point(12, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(389, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "请在下方列表中指定食材的数量（双击修改）";
            // 
            // FormAddIngredientToDish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 549);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Name = "FormAddIngredientToDish";
            this.Text = "添加食材到菜品";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Label label2;
    }
}