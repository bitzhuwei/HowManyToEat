﻿namespace HowManyToEat
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.保存SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.打印PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印预览VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.退出XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.录入食材ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.录入菜品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看所有菜品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看所有食材ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看所有食材类别ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看所有食材单位名称ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.新建NToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.打开OToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.保存SToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.打印预览PToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.打印PToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.leftDishesMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加菜品leftDishesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除菜品leftDishesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上移leftDishesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下移leftDishesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.移到右侧leftDishesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印时隐藏leftDishesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印时显示leftDishesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveProjectDlg = new System.Windows.Forms.SaveFileDialog();
            this.saveResultDlg = new System.Windows.Forms.SaveFileDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.numTableCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lstLeftDishes = new System.Windows.Forms.ListBox();
            this.lstRightDishes = new System.Windows.Forms.ListBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.rightDishesMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加菜品rightDishesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除菜品rightDishesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上移rightDishesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下移rightDishesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.移到左侧rightDishesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印时隐藏rightDishesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印时显示rightDishesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.leftDishesMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTableCount)).BeginInit();
            this.rightDishesMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.工具TToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(940, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建NToolStripMenuItem,
            this.打开OToolStripMenuItem,
            this.toolStripSeparator,
            this.保存SToolStripMenuItem,
            this.另存为AToolStripMenuItem,
            this.toolStripSeparator1,
            this.打印PToolStripMenuItem,
            this.打印预览VToolStripMenuItem,
            this.toolStripSeparator2,
            this.退出XToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // 新建NToolStripMenuItem
            // 
            this.新建NToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("新建NToolStripMenuItem.Image")));
            this.新建NToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.新建NToolStripMenuItem.Name = "新建NToolStripMenuItem";
            this.新建NToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.新建NToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.新建NToolStripMenuItem.Text = "新建(&N)";
            this.新建NToolStripMenuItem.Click += new System.EventHandler(this.新建NToolStripButton_Click);
            // 
            // 打开OToolStripMenuItem
            // 
            this.打开OToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("打开OToolStripMenuItem.Image")));
            this.打开OToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打开OToolStripMenuItem.Name = "打开OToolStripMenuItem";
            this.打开OToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.打开OToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.打开OToolStripMenuItem.Text = "打开(&O)";
            this.打开OToolStripMenuItem.Click += new System.EventHandler(this.打开OToolStripButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(162, 6);
            // 
            // 保存SToolStripMenuItem
            // 
            this.保存SToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("保存SToolStripMenuItem.Image")));
            this.保存SToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.保存SToolStripMenuItem.Name = "保存SToolStripMenuItem";
            this.保存SToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.保存SToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.保存SToolStripMenuItem.Text = "保存(&S)";
            this.保存SToolStripMenuItem.Click += new System.EventHandler(this.保存SToolStripButton_Click);
            // 
            // 另存为AToolStripMenuItem
            // 
            this.另存为AToolStripMenuItem.Name = "另存为AToolStripMenuItem";
            this.另存为AToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.另存为AToolStripMenuItem.Text = "另存为(&A)";
            this.另存为AToolStripMenuItem.Click += new System.EventHandler(this.另存为AToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // 打印PToolStripMenuItem
            // 
            this.打印PToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("打印PToolStripMenuItem.Image")));
            this.打印PToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打印PToolStripMenuItem.Name = "打印PToolStripMenuItem";
            this.打印PToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.打印PToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.打印PToolStripMenuItem.Text = "打印(&P)";
            this.打印PToolStripMenuItem.Click += new System.EventHandler(this.打印PToolStripButton_Click);
            // 
            // 打印预览VToolStripMenuItem
            // 
            this.打印预览VToolStripMenuItem.Image = global::HowManyToEat.Properties.Resources.preview;
            this.打印预览VToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打印预览VToolStripMenuItem.Name = "打印预览VToolStripMenuItem";
            this.打印预览VToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.打印预览VToolStripMenuItem.Text = "打印预览(&V)";
            this.打印预览VToolStripMenuItem.Click += new System.EventHandler(this.打印预览VToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(162, 6);
            // 
            // 退出XToolStripMenuItem
            // 
            this.退出XToolStripMenuItem.Name = "退出XToolStripMenuItem";
            this.退出XToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.退出XToolStripMenuItem.Text = "退出(&X)";
            this.退出XToolStripMenuItem.Click += new System.EventHandler(this.退出XToolStripMenuItem_Click);
            // 
            // 工具TToolStripMenuItem
            // 
            this.工具TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.录入食材ToolStripMenuItem,
            this.录入菜品ToolStripMenuItem,
            this.查看所有菜品ToolStripMenuItem,
            this.查看所有食材ToolStripMenuItem,
            this.查看所有食材类别ToolStripMenuItem,
            this.查看所有食材单位名称ToolStripMenuItem});
            this.工具TToolStripMenuItem.Name = "工具TToolStripMenuItem";
            this.工具TToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.工具TToolStripMenuItem.Text = "工具(&T)";
            // 
            // 录入食材ToolStripMenuItem
            // 
            this.录入食材ToolStripMenuItem.Name = "录入食材ToolStripMenuItem";
            this.录入食材ToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.录入食材ToolStripMenuItem.Text = "录入 新食材";
            this.录入食材ToolStripMenuItem.Click += new System.EventHandler(this.录入食材ToolStripMenuItem_Click);
            // 
            // 录入菜品ToolStripMenuItem
            // 
            this.录入菜品ToolStripMenuItem.Name = "录入菜品ToolStripMenuItem";
            this.录入菜品ToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.录入菜品ToolStripMenuItem.Text = "录入 新菜品";
            this.录入菜品ToolStripMenuItem.Click += new System.EventHandler(this.录入菜品ToolStripMenuItem_Click);
            // 
            // 查看所有菜品ToolStripMenuItem
            // 
            this.查看所有菜品ToolStripMenuItem.Name = "查看所有菜品ToolStripMenuItem";
            this.查看所有菜品ToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.查看所有菜品ToolStripMenuItem.Text = "查看所有 菜品";
            this.查看所有菜品ToolStripMenuItem.Click += new System.EventHandler(this.查看所有菜品ToolStripMenuItem_Click);
            // 
            // 查看所有食材ToolStripMenuItem
            // 
            this.查看所有食材ToolStripMenuItem.Name = "查看所有食材ToolStripMenuItem";
            this.查看所有食材ToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.查看所有食材ToolStripMenuItem.Text = "查看所有 食材";
            this.查看所有食材ToolStripMenuItem.Click += new System.EventHandler(this.查看所有食材ToolStripMenuItem_Click);
            // 
            // 查看所有食材类别ToolStripMenuItem
            // 
            this.查看所有食材类别ToolStripMenuItem.Name = "查看所有食材类别ToolStripMenuItem";
            this.查看所有食材类别ToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.查看所有食材类别ToolStripMenuItem.Text = "查看所有 食材类别";
            this.查看所有食材类别ToolStripMenuItem.Click += new System.EventHandler(this.查看所有食材类别ToolStripMenuItem_Click);
            // 
            // 查看所有食材单位名称ToolStripMenuItem
            // 
            this.查看所有食材单位名称ToolStripMenuItem.Name = "查看所有食材单位名称ToolStripMenuItem";
            this.查看所有食材单位名称ToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.查看所有食材单位名称ToolStripMenuItem.Text = "查看所有 食材单位名称";
            this.查看所有食材单位名称ToolStripMenuItem.Click += new System.EventHandler(this.查看所有食材单位名称ToolStripMenuItem_Click);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于AToolStripMenuItem});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // 关于AToolStripMenuItem
            // 
            this.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            this.关于AToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.关于AToolStripMenuItem.Text = "关于(&A)...";
            this.关于AToolStripMenuItem.Click += new System.EventHandler(this.关于AToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建NToolStripButton,
            this.打开OToolStripButton,
            this.保存SToolStripButton,
            this.打印预览PToolStripButton,
            this.打印PToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(940, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // 新建NToolStripButton
            // 
            this.新建NToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.新建NToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("新建NToolStripButton.Image")));
            this.新建NToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.新建NToolStripButton.Name = "新建NToolStripButton";
            this.新建NToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.新建NToolStripButton.Text = "新建(&N)";
            this.新建NToolStripButton.Click += new System.EventHandler(this.新建NToolStripButton_Click);
            // 
            // 打开OToolStripButton
            // 
            this.打开OToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.打开OToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("打开OToolStripButton.Image")));
            this.打开OToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打开OToolStripButton.Name = "打开OToolStripButton";
            this.打开OToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.打开OToolStripButton.Text = "打开(&O)";
            this.打开OToolStripButton.Click += new System.EventHandler(this.打开OToolStripButton_Click);
            // 
            // 保存SToolStripButton
            // 
            this.保存SToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.保存SToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("保存SToolStripButton.Image")));
            this.保存SToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.保存SToolStripButton.Name = "保存SToolStripButton";
            this.保存SToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.保存SToolStripButton.Text = "保存(&S)";
            this.保存SToolStripButton.Click += new System.EventHandler(this.保存SToolStripButton_Click);
            // 
            // 打印预览PToolStripButton
            // 
            this.打印预览PToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.打印预览PToolStripButton.Image = global::HowManyToEat.Properties.Resources.preview;
            this.打印预览PToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打印预览PToolStripButton.Name = "打印预览PToolStripButton";
            this.打印预览PToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.打印预览PToolStripButton.Text = "打印(&P)";
            this.打印预览PToolStripButton.Click += new System.EventHandler(this.打印预览VToolStripMenuItem_Click);
            // 
            // 打印PToolStripButton
            // 
            this.打印PToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.打印PToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("打印PToolStripButton.Image")));
            this.打印PToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打印PToolStripButton.Name = "打印PToolStripButton";
            this.打印PToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.打印PToolStripButton.Text = "打印(&P)";
            this.打印PToolStripButton.Click += new System.EventHandler(this.打印PToolStripButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 547);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(940, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // leftDishesMenuStrip
            // 
            this.leftDishesMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加菜品leftDishesToolStripMenuItem,
            this.删除菜品leftDishesToolStripMenuItem,
            this.上移leftDishesToolStripMenuItem,
            this.下移leftDishesToolStripMenuItem,
            this.移到右侧leftDishesToolStripMenuItem,
            this.打印时隐藏leftDishesToolStripMenuItem,
            this.打印时显示leftDishesToolStripMenuItem});
            this.leftDishesMenuStrip.Name = "contextMenuStrip1";
            this.leftDishesMenuStrip.Size = new System.Drawing.Size(137, 158);
            // 
            // 添加菜品leftDishesToolStripMenuItem
            // 
            this.添加菜品leftDishesToolStripMenuItem.Name = "添加菜品leftDishesToolStripMenuItem";
            this.添加菜品leftDishesToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.添加菜品leftDishesToolStripMenuItem.Text = "添加 菜品";
            this.添加菜品leftDishesToolStripMenuItem.Click += new System.EventHandler(this.添加菜品leftDishesToolStripMenuItem_Click);
            // 
            // 删除菜品leftDishesToolStripMenuItem
            // 
            this.删除菜品leftDishesToolStripMenuItem.Name = "删除菜品leftDishesToolStripMenuItem";
            this.删除菜品leftDishesToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.删除菜品leftDishesToolStripMenuItem.Text = "删除 菜品";
            this.删除菜品leftDishesToolStripMenuItem.Click += new System.EventHandler(this.删除菜品leftDishesToolStripMenuItem_Click);
            // 
            // 上移leftDishesToolStripMenuItem
            // 
            this.上移leftDishesToolStripMenuItem.Name = "上移leftDishesToolStripMenuItem";
            this.上移leftDishesToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.上移leftDishesToolStripMenuItem.Text = "上移";
            this.上移leftDishesToolStripMenuItem.Click += new System.EventHandler(this.上移leftDishesToolStripMenuItem_Click);
            // 
            // 下移leftDishesToolStripMenuItem
            // 
            this.下移leftDishesToolStripMenuItem.Name = "下移leftDishesToolStripMenuItem";
            this.下移leftDishesToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.下移leftDishesToolStripMenuItem.Text = "下移";
            this.下移leftDishesToolStripMenuItem.Click += new System.EventHandler(this.下移leftDishesToolStripMenuItem_Click);
            // 
            // 移到右侧leftDishesToolStripMenuItem
            // 
            this.移到右侧leftDishesToolStripMenuItem.Name = "移到右侧leftDishesToolStripMenuItem";
            this.移到右侧leftDishesToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.移到右侧leftDishesToolStripMenuItem.Text = "移到右侧";
            this.移到右侧leftDishesToolStripMenuItem.Click += new System.EventHandler(this.移到右侧leftDishesToolStripMenuItem_Click);
            // 
            // 打印时隐藏leftDishesToolStripMenuItem
            // 
            this.打印时隐藏leftDishesToolStripMenuItem.Name = "打印时隐藏leftDishesToolStripMenuItem";
            this.打印时隐藏leftDishesToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.打印时隐藏leftDishesToolStripMenuItem.Text = "打印时隐藏";
            this.打印时隐藏leftDishesToolStripMenuItem.Click += new System.EventHandler(this.打印时隐藏leftDishesToolStripMenuItem_Click);
            // 
            // 打印时显示leftDishesToolStripMenuItem
            // 
            this.打印时显示leftDishesToolStripMenuItem.Name = "打印时显示leftDishesToolStripMenuItem";
            this.打印时显示leftDishesToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.打印时显示leftDishesToolStripMenuItem.Text = "打印时显示";
            this.打印时显示leftDishesToolStripMenuItem.Click += new System.EventHandler(this.打印时显示leftDishesToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "*.xml|*.xml";
            // 
            // saveProjectDlg
            // 
            this.saveProjectDlg.Filter = "*.xml|*.xml";
            // 
            // saveResultDlg
            // 
            this.saveResultDlg.Filter = "*.png|*.png";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // numTableCount
            // 
            this.numTableCount.Location = new System.Drawing.Point(82, 53);
            this.numTableCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTableCount.Name = "numTableCount";
            this.numTableCount.Size = new System.Drawing.Size(120, 21);
            this.numTableCount.TabIndex = 5;
            this.numTableCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numTableCount.ValueChanged += new System.EventHandler(this.numTableCount_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F);
            this.label1.Location = new System.Drawing.Point(10, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "席数：";
            // 
            // lstLeftDishes
            // 
            this.lstLeftDishes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstLeftDishes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstLeftDishes.Font = new System.Drawing.Font("宋体", 18F);
            this.lstLeftDishes.FormattingEnabled = true;
            this.lstLeftDishes.ItemHeight = 24;
            this.lstLeftDishes.Location = new System.Drawing.Point(12, 104);
            this.lstLeftDishes.Name = "lstLeftDishes";
            this.lstLeftDishes.Size = new System.Drawing.Size(234, 436);
            this.lstLeftDishes.TabIndex = 6;
            this.lstLeftDishes.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstbothDishes_DrawItem);
            this.lstLeftDishes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstLeftDishes_MouseDoubleClick);
            this.lstLeftDishes.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstLeftDishes_MouseUp);
            // 
            // lstRightDishes
            // 
            this.lstRightDishes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstRightDishes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstRightDishes.Font = new System.Drawing.Font("宋体", 18F);
            this.lstRightDishes.FormattingEnabled = true;
            this.lstRightDishes.ItemHeight = 24;
            this.lstRightDishes.Location = new System.Drawing.Point(252, 104);
            this.lstRightDishes.Name = "lstRightDishes";
            this.lstRightDishes.Size = new System.Drawing.Size(234, 436);
            this.lstRightDishes.TabIndex = 6;
            this.lstRightDishes.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstbothDishes_DrawItem);
            this.lstRightDishes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstRightDishes_MouseDoubleClick);
            this.lstRightDishes.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstRightDishes_MouseUp);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Font = new System.Drawing.Font("宋体", 14F);
            this.txtResult.Location = new System.Drawing.Point(492, 82);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(436, 454);
            this.txtResult.TabIndex = 7;
            // 
            // rightDishesMenuStrip
            // 
            this.rightDishesMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加菜品rightDishesToolStripMenuItem,
            this.删除菜品rightDishesToolStripMenuItem,
            this.上移rightDishesToolStripMenuItem,
            this.下移rightDishesToolStripMenuItem,
            this.移到左侧rightDishesToolStripMenuItem,
            this.打印时隐藏rightDishesToolStripMenuItem,
            this.打印时显示rightDishesToolStripMenuItem});
            this.rightDishesMenuStrip.Name = "contextMenuStrip1";
            this.rightDishesMenuStrip.Size = new System.Drawing.Size(137, 158);
            // 
            // 添加菜品rightDishesToolStripMenuItem
            // 
            this.添加菜品rightDishesToolStripMenuItem.Name = "添加菜品rightDishesToolStripMenuItem";
            this.添加菜品rightDishesToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.添加菜品rightDishesToolStripMenuItem.Text = "添加 菜品";
            this.添加菜品rightDishesToolStripMenuItem.Click += new System.EventHandler(this.添加菜品rightDishesToolStripMenuItem_Click);
            // 
            // 删除菜品rightDishesToolStripMenuItem
            // 
            this.删除菜品rightDishesToolStripMenuItem.Name = "删除菜品rightDishesToolStripMenuItem";
            this.删除菜品rightDishesToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.删除菜品rightDishesToolStripMenuItem.Text = "删除 菜品";
            this.删除菜品rightDishesToolStripMenuItem.Click += new System.EventHandler(this.删除菜品rightDishesToolStripMenuItem_Click);
            // 
            // 上移rightDishesToolStripMenuItem
            // 
            this.上移rightDishesToolStripMenuItem.Name = "上移rightDishesToolStripMenuItem";
            this.上移rightDishesToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.上移rightDishesToolStripMenuItem.Text = "上移";
            this.上移rightDishesToolStripMenuItem.Click += new System.EventHandler(this.上移rightDishesToolStripMenuItem_Click);
            // 
            // 下移rightDishesToolStripMenuItem
            // 
            this.下移rightDishesToolStripMenuItem.Name = "下移rightDishesToolStripMenuItem";
            this.下移rightDishesToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.下移rightDishesToolStripMenuItem.Text = "下移";
            this.下移rightDishesToolStripMenuItem.Click += new System.EventHandler(this.下移rightDishesToolStripMenuItem_Click);
            // 
            // 移到左侧rightDishesToolStripMenuItem
            // 
            this.移到左侧rightDishesToolStripMenuItem.Name = "移到左侧rightDishesToolStripMenuItem";
            this.移到左侧rightDishesToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.移到左侧rightDishesToolStripMenuItem.Text = "移到左侧";
            this.移到左侧rightDishesToolStripMenuItem.Click += new System.EventHandler(this.移到左侧rightDishesToolStripMenuItem_Click);
            // 
            // 打印时隐藏rightDishesToolStripMenuItem
            // 
            this.打印时隐藏rightDishesToolStripMenuItem.Name = "打印时隐藏rightDishesToolStripMenuItem";
            this.打印时隐藏rightDishesToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.打印时隐藏rightDishesToolStripMenuItem.Text = "打印时隐藏";
            this.打印时隐藏rightDishesToolStripMenuItem.Click += new System.EventHandler(this.打印时隐藏rightDishesToolStripMenuItem_Click);
            // 
            // 打印时显示rightDishesToolStripMenuItem
            // 
            this.打印时显示rightDishesToolStripMenuItem.Name = "打印时显示rightDishesToolStripMenuItem";
            this.打印时显示rightDishesToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.打印时显示rightDishesToolStripMenuItem.Text = "打印时显示";
            this.打印时显示rightDishesToolStripMenuItem.Click += new System.EventHandler(this.打印时显示rightDishesToolStripMenuItem_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(492, 53);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 8;
            this.btnCalculate.Text = "统计结果";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14F);
            this.label2.Location = new System.Drawing.Point(10, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "左列菜单";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14F);
            this.label3.Location = new System.Drawing.Point(248, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "右列菜单";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 569);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.lstRightDishes);
            this.Controls.Add(this.lstLeftDishes);
            this.Controls.Add(this.numTableCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "材料统计 - 东大街宴会大厅 - 某月某家2天方案";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.leftDishesMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numTableCount)).EndInit();
            this.rightDishesMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建NToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开OToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem 保存SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 另存为AToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 打印PToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印预览VToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 退出XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton 新建NToolStripButton;
        private System.Windows.Forms.ToolStripButton 打开OToolStripButton;
        private System.Windows.Forms.ToolStripButton 保存SToolStripButton;
        private System.Windows.Forms.ToolStripButton 打印PToolStripButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ContextMenuStrip leftDishesMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 添加菜品leftDishesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除菜品leftDishesToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveProjectDlg;
        private System.Windows.Forms.SaveFileDialog saveResultDlg;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.ToolStripButton 打印预览PToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem 录入菜品ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 录入食材ToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown numTableCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstLeftDishes;
        private System.Windows.Forms.ListBox lstRightDishes;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.ContextMenuStrip rightDishesMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 添加菜品rightDishesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除菜品rightDishesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上移leftDishesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下移leftDishesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 移到右侧leftDishesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上移rightDishesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下移rightDishesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 移到左侧rightDishesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看所有菜品ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看所有食材ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印时隐藏leftDishesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印时显示leftDishesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印时隐藏rightDishesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印时显示rightDishesToolStripMenuItem;
        private System.Windows.Forms.Button btnCalculate;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ToolStripMenuItem 查看所有食材类别ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看所有食材单位名称ToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}