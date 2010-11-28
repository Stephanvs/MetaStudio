namespace Hayman.Client
{
    partial class RenameMetaItemForm
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
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.metaItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MetaItemIdTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForMetaItemId = new DevExpress.XtraLayout.LayoutControlItem();
            this.MetaItemNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForMetaItemName = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.MetaModelIdTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForMetaModelId = new DevExpress.XtraLayout.LayoutControlItem();
            this.MetaModelTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForMetaModel = new DevExpress.XtraLayout.LayoutControlItem();
            this.cancelButton = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.okButton = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metaItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MetaItemIdTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMetaItemId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MetaItemNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMetaItemName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MetaModelIdTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMetaModelId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MetaModelTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMetaModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.okButton);
            this.dataLayoutControl1.Controls.Add(this.cancelButton);
            this.dataLayoutControl1.Controls.Add(this.MetaItemIdTextEdit);
            this.dataLayoutControl1.Controls.Add(this.MetaItemNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.MetaModelIdTextEdit);
            this.dataLayoutControl1.Controls.Add(this.MetaModelTextEdit);
            this.dataLayoutControl1.DataSource = this.metaItemBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForMetaItemId,
            this.ItemForMetaModelId,
            this.ItemForMetaModel});
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(344, 169);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(344, 169);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // metaItemBindingSource
            // 
            this.metaItemBindingSource.DataSource = typeof(Hayman.Client.HaymanReadModelServiceReference.MetaItem);
            // 
            // MetaItemIdTextEdit
            // 
            this.MetaItemIdTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.metaItemBindingSource, "MetaItemId", true));
            this.MetaItemIdTextEdit.Location = new System.Drawing.Point(0, 0);
            this.MetaItemIdTextEdit.Name = "MetaItemIdTextEdit";
            this.MetaItemIdTextEdit.Size = new System.Drawing.Size(0, 20);
            this.MetaItemIdTextEdit.StyleController = this.dataLayoutControl1;
            this.MetaItemIdTextEdit.TabIndex = 4;
            // 
            // ItemForMetaItemId
            // 
            this.ItemForMetaItemId.Control = this.MetaItemIdTextEdit;
            this.ItemForMetaItemId.CustomizationFormText = "Meta Item Id";
            this.ItemForMetaItemId.Location = new System.Drawing.Point(0, 0);
            this.ItemForMetaItemId.Name = "ItemForMetaItemId";
            this.ItemForMetaItemId.Size = new System.Drawing.Size(0, 0);
            this.ItemForMetaItemId.Text = "Meta Item Id";
            this.ItemForMetaItemId.TextSize = new System.Drawing.Size(50, 20);
            this.ItemForMetaItemId.TextToControlDistance = 5;
            // 
            // MetaItemNameTextEdit
            // 
            this.MetaItemNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.metaItemBindingSource, "MetaItemName", true));
            this.MetaItemNameTextEdit.Location = new System.Drawing.Point(95, 12);
            this.MetaItemNameTextEdit.Name = "MetaItemNameTextEdit";
            this.MetaItemNameTextEdit.Size = new System.Drawing.Size(237, 20);
            this.MetaItemNameTextEdit.StyleController = this.dataLayoutControl1;
            this.MetaItemNameTextEdit.TabIndex = 5;
            // 
            // ItemForMetaItemName
            // 
            this.ItemForMetaItemName.Control = this.MetaItemNameTextEdit;
            this.ItemForMetaItemName.CustomizationFormText = "Meta Item Name";
            this.ItemForMetaItemName.Location = new System.Drawing.Point(0, 0);
            this.ItemForMetaItemName.Name = "ItemForMetaItemName";
            this.ItemForMetaItemName.Size = new System.Drawing.Size(324, 24);
            this.ItemForMetaItemName.Text = "Meta Item Name";
            this.ItemForMetaItemName.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.CustomizationFormText = "autoGeneratedGroup0";
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForMetaItemName,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.emptySpaceItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(324, 149);
            this.layoutControlGroup2.Text = "autoGeneratedGroup0";
            // 
            // MetaModelIdTextEdit
            // 
            this.MetaModelIdTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.metaItemBindingSource, "MetaModelId", true));
            this.MetaModelIdTextEdit.Location = new System.Drawing.Point(0, 0);
            this.MetaModelIdTextEdit.Name = "MetaModelIdTextEdit";
            this.MetaModelIdTextEdit.Size = new System.Drawing.Size(0, 20);
            this.MetaModelIdTextEdit.StyleController = this.dataLayoutControl1;
            this.MetaModelIdTextEdit.TabIndex = 6;
            // 
            // ItemForMetaModelId
            // 
            this.ItemForMetaModelId.Control = this.MetaModelIdTextEdit;
            this.ItemForMetaModelId.CustomizationFormText = "Meta Model Id";
            this.ItemForMetaModelId.Location = new System.Drawing.Point(0, 0);
            this.ItemForMetaModelId.Name = "ItemForMetaModelId";
            this.ItemForMetaModelId.Size = new System.Drawing.Size(0, 0);
            this.ItemForMetaModelId.Text = "Meta Model Id";
            this.ItemForMetaModelId.TextSize = new System.Drawing.Size(50, 20);
            this.ItemForMetaModelId.TextToControlDistance = 5;
            // 
            // MetaModelTextEdit
            // 
            this.MetaModelTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.metaItemBindingSource, "MetaModel", true));
            this.MetaModelTextEdit.Location = new System.Drawing.Point(0, 0);
            this.MetaModelTextEdit.Name = "MetaModelTextEdit";
            this.MetaModelTextEdit.Size = new System.Drawing.Size(0, 20);
            this.MetaModelTextEdit.StyleController = this.dataLayoutControl1;
            this.MetaModelTextEdit.TabIndex = 7;
            // 
            // ItemForMetaModel
            // 
            this.ItemForMetaModel.Control = this.MetaModelTextEdit;
            this.ItemForMetaModel.CustomizationFormText = "Meta Model";
            this.ItemForMetaModel.Location = new System.Drawing.Point(0, 0);
            this.ItemForMetaModel.Name = "ItemForMetaModel";
            this.ItemForMetaModel.Size = new System.Drawing.Size(0, 0);
            this.ItemForMetaModel.Text = "Meta Model";
            this.ItemForMetaModel.TextSize = new System.Drawing.Size(50, 20);
            this.ItemForMetaModel.TextToControlDistance = 5;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(254, 135);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(78, 22);
            this.cancelButton.StyleController = this.dataLayoutControl1;
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.cancelButton;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(242, 123);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(82, 26);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(82, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(82, 26);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(172, 135);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(78, 22);
            this.okButton.StyleController = this.dataLayoutControl1;
            this.okButton.TabIndex = 9;
            this.okButton.Text = "OK";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.okButton;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(160, 123);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(82, 26);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(82, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(82, 26);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 123);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(160, 26);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 24);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(324, 99);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // RenameMetaItemForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(344, 169);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "RenameMetaItemForm";
            this.Text = "Rename MetaItem";
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metaItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MetaItemIdTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMetaItemId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MetaItemNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMetaItemName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MetaModelIdTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMetaModelId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MetaModelTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMetaModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.SimpleButton okButton;
        private DevExpress.XtraEditors.SimpleButton cancelButton;
        private DevExpress.XtraEditors.TextEdit MetaItemIdTextEdit;
        private System.Windows.Forms.BindingSource metaItemBindingSource;
        private DevExpress.XtraEditors.TextEdit MetaItemNameTextEdit;
        private DevExpress.XtraEditors.TextEdit MetaModelIdTextEdit;
        private DevExpress.XtraEditors.TextEdit MetaModelTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForMetaItemId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForMetaModelId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForMetaModel;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForMetaItemName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}