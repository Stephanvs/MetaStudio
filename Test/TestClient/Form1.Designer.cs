namespace TestClient
{
	partial class Form1
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
			this.button1 = new System.Windows.Forms.Button();
			this.tbName = new System.Windows.Forms.TextBox();
			this.listMetaItems = new System.Windows.Forms.ListBox();
			this.lblMetaItems = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.miSource = new System.Windows.Forms.ComboBox();
			this.listMetaAssociations = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.miTarget = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.listOfMetaItemsForItems = new System.Windows.Forms.ComboBox();
			this.listOfItems = new System.Windows.Forms.ListBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btnCreateItem = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.cbMetaItems = new System.Windows.Forms.ComboBox();
			this.tbNewItemName = new System.Windows.Forms.TextBox();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.listAssociations = new System.Windows.Forms.ListBox();
			this.button4 = new System.Windows.Forms.Button();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.ddlTargetItem = new System.Windows.Forms.ComboBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.ddlTargetMetaItem = new System.Windows.Forms.ComboBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.ddlSourceItem = new System.Windows.Forms.ComboBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.ddlSourceMetaItem = new System.Windows.Forms.ComboBox();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.listMetaItemsForView = new System.Windows.Forms.ListBox();
			this.btnCreateView = new System.Windows.Forms.Button();
			this.label15 = new System.Windows.Forms.Label();
			this.tbViewName = new System.Windows.Forms.TextBox();
			this.cbModels = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.tbNewModelName = new System.Windows.Forms.TextBox();
			this.btnCreateModel = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.btnCreateMetaItemCommand = new System.Windows.Forms.Button();
			this.btnRenameModelCommand = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.miFile = new System.Windows.Forms.ToolStripMenuItem();
			this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBox1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(9, 58);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(134, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "New MetaItem";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.btnCreateNewMetaItem_Click);
			// 
			// tbName
			// 
			this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbName.Location = new System.Drawing.Point(9, 32);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(1062, 20);
			this.tbName.TabIndex = 1;
			// 
			// listMetaItems
			// 
			this.listMetaItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listMetaItems.FormattingEnabled = true;
			this.listMetaItems.Location = new System.Drawing.Point(15, 127);
			this.listMetaItems.Name = "listMetaItems";
			this.listMetaItems.Size = new System.Drawing.Size(210, 433);
			this.listMetaItems.TabIndex = 2;
			// 
			// lblMetaItems
			// 
			this.lblMetaItems.AutoSize = true;
			this.lblMetaItems.Location = new System.Drawing.Point(12, 111);
			this.lblMetaItems.Name = "lblMetaItems";
			this.lblMetaItems.Size = new System.Drawing.Size(56, 13);
			this.lblMetaItems.TabIndex = 3;
			this.lblMetaItems.Text = "MetaItems";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(9, 99);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(230, 23);
			this.button2.TabIndex = 4;
			this.button2.Text = "Create MetaAssociation";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.btnAddMetaAssociation_Click);
			// 
			// miSource
			// 
			this.miSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.miSource.FormattingEnabled = true;
			this.miSource.Location = new System.Drawing.Point(9, 32);
			this.miSource.Name = "miSource";
			this.miSource.Size = new System.Drawing.Size(230, 21);
			this.miSource.TabIndex = 5;
			// 
			// listMetaAssociations
			// 
			this.listMetaAssociations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listMetaAssociations.FormattingEnabled = true;
			this.listMetaAssociations.Location = new System.Drawing.Point(245, 32);
			this.listMetaAssociations.Name = "listMetaAssociations";
			this.listMetaAssociations.Size = new System.Drawing.Size(529, 381);
			this.listMetaAssociations.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(242, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Associations";
			// 
			// miTarget
			// 
			this.miTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.miTarget.FormattingEnabled = true;
			this.miTarget.Location = new System.Drawing.Point(9, 72);
			this.miTarget.Name = "miTarget";
			this.miTarget.Size = new System.Drawing.Size(230, 21);
			this.miTarget.TabIndex = 8;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Source";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(38, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Target";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Controls.Add(this.miSource);
			this.groupBox1.Controls.Add(this.miTarget);
			this.groupBox1.Controls.Add(this.listMetaAssociations);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(6, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(784, 455);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "MetaAssociations";
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabPage5);
			this.tabControl1.Location = new System.Drawing.Point(12, 60);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1097, 609);
			this.tabControl1.TabIndex = 12;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Controls.Add(this.lblMetaItems);
			this.tabPage1.Controls.Add(this.listMetaItems);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1089, 583);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "MetaItems";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Controls.Add(this.tbName);
			this.groupBox2.Location = new System.Drawing.Point(6, 6);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(1077, 88);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Create MetaItem";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(108, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "Create new MetaItem";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.groupBox1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(1089, 583);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "MetaAssociations";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.groupBox4);
			this.tabPage3.Controls.Add(this.groupBox3);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(1089, 583);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Items";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.label8);
			this.groupBox4.Controls.Add(this.label7);
			this.groupBox4.Controls.Add(this.listOfMetaItemsForItems);
			this.groupBox4.Controls.Add(this.listOfItems);
			this.groupBox4.Location = new System.Drawing.Point(6, 126);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(784, 297);
			this.groupBox4.TabIndex = 4;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "View Items";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(6, 77);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(137, 13);
			this.label8.TabIndex = 6;
			this.label8.Text = "Items for selected MetaItem";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 22);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(93, 13);
			this.label7.TabIndex = 5;
			this.label7.Text = "Select a MetaItem";
			// 
			// listOfMetaItemsForItems
			// 
			this.listOfMetaItemsForItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listOfMetaItemsForItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.listOfMetaItemsForItems.FormattingEnabled = true;
			this.listOfMetaItemsForItems.Location = new System.Drawing.Point(6, 38);
			this.listOfMetaItemsForItems.Name = "listOfMetaItemsForItems";
			this.listOfMetaItemsForItems.Size = new System.Drawing.Size(691, 21);
			this.listOfMetaItemsForItems.TabIndex = 4;
			this.listOfMetaItemsForItems.SelectedIndexChanged += new System.EventHandler(this.listOfMetaItemsForItems_SelectedIndexChanged);
			// 
			// listOfItems
			// 
			this.listOfItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listOfItems.FormattingEnabled = true;
			this.listOfItems.Location = new System.Drawing.Point(6, 93);
			this.listOfItems.Name = "listOfItems";
			this.listOfItems.Size = new System.Drawing.Size(383, 186);
			this.listOfItems.TabIndex = 3;
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.btnCreateItem);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.cbMetaItems);
			this.groupBox3.Controls.Add(this.tbNewItemName);
			this.groupBox3.Location = new System.Drawing.Point(6, 6);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(784, 114);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Create New Item";
			// 
			// btnCreateItem
			// 
			this.btnCreateItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCreateItem.Location = new System.Drawing.Point(703, 81);
			this.btnCreateItem.Name = "btnCreateItem";
			this.btnCreateItem.Size = new System.Drawing.Size(75, 23);
			this.btnCreateItem.TabIndex = 2;
			this.btnCreateItem.Text = "Create";
			this.btnCreateItem.UseVisualStyleBackColor = true;
			this.btnCreateItem.Click += new System.EventHandler(this.btnCreateItem_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 27);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(93, 13);
			this.label5.TabIndex = 1;
			this.label5.Text = "Select a MetaItem";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 67);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(58, 13);
			this.label6.TabIndex = 1;
			this.label6.Text = "Item Name";
			// 
			// cbMetaItems
			// 
			this.cbMetaItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbMetaItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMetaItems.FormattingEnabled = true;
			this.cbMetaItems.Location = new System.Drawing.Point(6, 43);
			this.cbMetaItems.Name = "cbMetaItems";
			this.cbMetaItems.Size = new System.Drawing.Size(691, 21);
			this.cbMetaItems.TabIndex = 0;
			// 
			// tbNewItemName
			// 
			this.tbNewItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbNewItemName.Location = new System.Drawing.Point(6, 83);
			this.tbNewItemName.Name = "tbNewItemName";
			this.tbNewItemName.Size = new System.Drawing.Size(691, 20);
			this.tbNewItemName.TabIndex = 0;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.listAssociations);
			this.tabPage4.Controls.Add(this.button4);
			this.tabPage4.Controls.Add(this.groupBox6);
			this.tabPage4.Controls.Add(this.groupBox5);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(1089, 583);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Associations";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// listAssociations
			// 
			this.listAssociations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listAssociations.FormattingEnabled = true;
			this.listAssociations.Location = new System.Drawing.Point(12, 171);
			this.listAssociations.Name = "listAssociations";
			this.listAssociations.Size = new System.Drawing.Size(784, 251);
			this.listAssociations.TabIndex = 3;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(288, 132);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(201, 33);
			this.button4.TabIndex = 2;
			this.button4.Text = "Create Association";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.btnCreateItemAssociation_Click);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.ddlTargetItem);
			this.groupBox6.Controls.Add(this.label14);
			this.groupBox6.Controls.Add(this.label12);
			this.groupBox6.Controls.Add(this.ddlTargetMetaItem);
			this.groupBox6.Location = new System.Drawing.Point(399, 6);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(391, 120);
			this.groupBox6.TabIndex = 1;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Target";
			// 
			// ddlTargetItem
			// 
			this.ddlTargetItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ddlTargetItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlTargetItem.FormattingEnabled = true;
			this.ddlTargetItem.Location = new System.Drawing.Point(6, 78);
			this.ddlTargetItem.Name = "ddlTargetItem";
			this.ddlTargetItem.Size = new System.Drawing.Size(379, 21);
			this.ddlTargetItem.TabIndex = 4;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(6, 62);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(94, 13);
			this.label14.TabIndex = 3;
			this.label14.Text = "Select Target Item";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(6, 22);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(118, 13);
			this.label12.TabIndex = 1;
			this.label12.Text = "Select Target MetaItem";
			// 
			// ddlTargetMetaItem
			// 
			this.ddlTargetMetaItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ddlTargetMetaItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlTargetMetaItem.FormattingEnabled = true;
			this.ddlTargetMetaItem.Location = new System.Drawing.Point(6, 38);
			this.ddlTargetMetaItem.Name = "ddlTargetMetaItem";
			this.ddlTargetMetaItem.Size = new System.Drawing.Size(379, 21);
			this.ddlTargetMetaItem.TabIndex = 0;
			this.ddlTargetMetaItem.SelectedIndexChanged += new System.EventHandler(this.ddlTargetMetaItem_SelectedIndexChanged);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.ddlSourceItem);
			this.groupBox5.Controls.Add(this.label13);
			this.groupBox5.Controls.Add(this.label11);
			this.groupBox5.Controls.Add(this.ddlSourceMetaItem);
			this.groupBox5.Location = new System.Drawing.Point(6, 6);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(371, 120);
			this.groupBox5.TabIndex = 0;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Source";
			// 
			// ddlSourceItem
			// 
			this.ddlSourceItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ddlSourceItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlSourceItem.FormattingEnabled = true;
			this.ddlSourceItem.Location = new System.Drawing.Point(6, 78);
			this.ddlSourceItem.Name = "ddlSourceItem";
			this.ddlSourceItem.Size = new System.Drawing.Size(359, 21);
			this.ddlSourceItem.TabIndex = 3;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(6, 62);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(97, 13);
			this.label13.TabIndex = 2;
			this.label13.Text = "Select Source Item";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(6, 22);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(121, 13);
			this.label11.TabIndex = 1;
			this.label11.Text = "Select Source MetaItem";
			// 
			// ddlSourceMetaItem
			// 
			this.ddlSourceMetaItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ddlSourceMetaItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlSourceMetaItem.FormattingEnabled = true;
			this.ddlSourceMetaItem.Location = new System.Drawing.Point(6, 38);
			this.ddlSourceMetaItem.Name = "ddlSourceMetaItem";
			this.ddlSourceMetaItem.Size = new System.Drawing.Size(359, 21);
			this.ddlSourceMetaItem.TabIndex = 0;
			this.ddlSourceMetaItem.SelectedIndexChanged += new System.EventHandler(this.ddlSourceMetaItem_SelectedIndexChanged);
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.groupBox7);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage5.Size = new System.Drawing.Size(1089, 583);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "View(s)";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// groupBox7
			// 
			this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox7.Controls.Add(this.listMetaItemsForView);
			this.groupBox7.Controls.Add(this.btnCreateView);
			this.groupBox7.Controls.Add(this.label15);
			this.groupBox7.Controls.Add(this.tbViewName);
			this.groupBox7.Location = new System.Drawing.Point(6, 6);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(279, 417);
			this.groupBox7.TabIndex = 3;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Create view";
			// 
			// listMetaItemsForView
			// 
			this.listMetaItemsForView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listMetaItemsForView.FormattingEnabled = true;
			this.listMetaItemsForView.Location = new System.Drawing.Point(6, 58);
			this.listMetaItemsForView.Name = "listMetaItemsForView";
			this.listMetaItemsForView.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.listMetaItemsForView.Size = new System.Drawing.Size(264, 316);
			this.listMetaItemsForView.TabIndex = 3;
			// 
			// btnCreateView
			// 
			this.btnCreateView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCreateView.Location = new System.Drawing.Point(6, 388);
			this.btnCreateView.Name = "btnCreateView";
			this.btnCreateView.Size = new System.Drawing.Size(75, 23);
			this.btnCreateView.TabIndex = 0;
			this.btnCreateView.Text = "Create View";
			this.btnCreateView.UseVisualStyleBackColor = true;
			this.btnCreateView.Click += new System.EventHandler(this.btnCreateView_Click);
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(6, 16);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(59, 13);
			this.label15.TabIndex = 1;
			this.label15.Text = "View name";
			// 
			// tbViewName
			// 
			this.tbViewName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbViewName.Location = new System.Drawing.Point(6, 32);
			this.tbViewName.Name = "tbViewName";
			this.tbViewName.Size = new System.Drawing.Size(264, 20);
			this.tbViewName.TabIndex = 2;
			// 
			// cbModels
			// 
			this.cbModels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbModels.FormattingEnabled = true;
			this.cbModels.Location = new System.Drawing.Point(137, 33);
			this.cbModels.Name = "cbModels";
			this.cbModels.Size = new System.Drawing.Size(238, 21);
			this.cbModels.TabIndex = 13;
			this.cbModels.SelectedIndexChanged += new System.EventHandler(this.cbModels_SelectedIndexChanged);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(9, 36);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(122, 13);
			this.label9.TabIndex = 14;
			this.label9.Text = "Select Model to activate";
			// 
			// tbNewModelName
			// 
			this.tbNewModelName.Location = new System.Drawing.Point(454, 33);
			this.tbNewModelName.Name = "tbNewModelName";
			this.tbNewModelName.Size = new System.Drawing.Size(148, 20);
			this.tbNewModelName.TabIndex = 15;
			this.tbNewModelName.Text = "Default";
			// 
			// btnCreateModel
			// 
			this.btnCreateModel.Location = new System.Drawing.Point(608, 31);
			this.btnCreateModel.Name = "btnCreateModel";
			this.btnCreateModel.Size = new System.Drawing.Size(96, 23);
			this.btnCreateModel.TabIndex = 16;
			this.btnCreateModel.Text = "Create Model";
			this.btnCreateModel.UseVisualStyleBackColor = true;
			this.btnCreateModel.Click += new System.EventHandler(this.btnCreateNewModel_Click);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(381, 36);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(67, 13);
			this.label10.TabIndex = 17;
			this.label10.Text = "Model Name";
			// 
			// btnCreateMetaItemCommand
			// 
			this.btnCreateMetaItemCommand.Location = new System.Drawing.Point(710, 31);
			this.btnCreateMetaItemCommand.Name = "btnCreateMetaItemCommand";
			this.btnCreateMetaItemCommand.Size = new System.Drawing.Size(132, 23);
			this.btnCreateMetaItemCommand.TabIndex = 3;
			this.btnCreateMetaItemCommand.Text = "Create Model Command";
			this.btnCreateMetaItemCommand.UseVisualStyleBackColor = true;
			this.btnCreateMetaItemCommand.Click += new System.EventHandler(this.btnCreateModelCommand_Click);
			// 
			// btnRenameModelCommand
			// 
			this.btnRenameModelCommand.Location = new System.Drawing.Point(848, 31);
			this.btnRenameModelCommand.Name = "btnRenameModelCommand";
			this.btnRenameModelCommand.Size = new System.Drawing.Size(138, 23);
			this.btnRenameModelCommand.TabIndex = 20;
			this.btnRenameModelCommand.Text = "Rename Model Command";
			this.btnRenameModelCommand.UseVisualStyleBackColor = true;
			this.btnRenameModelCommand.Click += new System.EventHandler(this.btnRenameModelCommand_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1121, 24);
			this.menuStrip1.TabIndex = 21;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// miFile
			// 
			this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem});
			this.miFile.Name = "miFile";
			this.miFile.Size = new System.Drawing.Size(37, 20);
			this.miFile.Text = "&File";
			// 
			// importToolStripMenuItem
			// 
			this.importToolStripMenuItem.Name = "importToolStripMenuItem";
			this.importToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
			this.importToolStripMenuItem.Text = "Import";
			this.importToolStripMenuItem.Click += new System.EventHandler(this.importOption_Click);
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
			this.exportToolStripMenuItem.Text = "Export";
			this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportOption_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1121, 681);
			this.Controls.Add(this.btnRenameModelCommand);
			this.Controls.Add(this.btnCreateMetaItemCommand);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.btnCreateModel);
			this.Controls.Add(this.tbNewModelName);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.cbModels);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "MetaStudio Test Application";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.tabPage4.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.tabPage5.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox tbName;
		private System.Windows.Forms.ListBox listMetaItems;
		private System.Windows.Forms.Label lblMetaItems;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ComboBox miSource;
		private System.Windows.Forms.ListBox listMetaAssociations;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox miTarget;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cbMetaItems;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btnCreateItem;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbNewItemName;
		private System.Windows.Forms.ListBox listOfItems;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox listOfMetaItemsForItems;
		private System.Windows.Forms.ComboBox cbModels;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox tbNewModelName;
		private System.Windows.Forms.Button btnCreateModel;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox ddlTargetMetaItem;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox ddlSourceMetaItem;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ComboBox ddlTargetItem;
		private System.Windows.Forms.ComboBox ddlSourceItem;
		private System.Windows.Forms.ListBox listAssociations;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ListBox listMetaItemsForView;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbViewName;
        private System.Windows.Forms.Button btnCreateView;
		private System.Windows.Forms.Button btnCreateMetaItemCommand;
		private System.Windows.Forms.Button btnRenameModelCommand;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem miFile;
		private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
	}
}

