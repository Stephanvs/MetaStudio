﻿namespace Hayman.Client
{
    partial class RenameMetaModelForm
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
            this.okButton = new DevExpress.XtraEditors.SimpleButton();
            this.cancelButton = new DevExpress.XtraEditors.SimpleButton();
            this.MetaModelIdTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.metaModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MetaModelNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.DeletedCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.ItemForMetaModelId = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDeleted = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForMetaModelName = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MetaModelIdTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metaModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MetaModelNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeletedCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMetaModelId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDeleted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMetaModelName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.okButton);
            this.dataLayoutControl1.Controls.Add(this.cancelButton);
            this.dataLayoutControl1.Controls.Add(this.MetaModelIdTextEdit);
            this.dataLayoutControl1.Controls.Add(this.MetaModelNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.DeletedCheckEdit);
            this.dataLayoutControl1.DataSource = this.metaModelBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForMetaModelId,
            this.ItemForDeleted});
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(269, 156);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(97, 122);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(78, 22);
            this.okButton.StyleController = this.dataLayoutControl1;
            this.okButton.TabIndex = 8;
            this.okButton.Text = "OK";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(179, 122);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(78, 22);
            this.cancelButton.StyleController = this.dataLayoutControl1;
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            // 
            // MetaModelIdTextEdit
            // 
            this.MetaModelIdTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.metaModelBindingSource, "MetaModelId", true));
            this.MetaModelIdTextEdit.Location = new System.Drawing.Point(0, 0);
            this.MetaModelIdTextEdit.Name = "MetaModelIdTextEdit";
            this.MetaModelIdTextEdit.Size = new System.Drawing.Size(0, 20);
            this.MetaModelIdTextEdit.StyleController = this.dataLayoutControl1;
            this.MetaModelIdTextEdit.TabIndex = 4;
            // 
            // metaModelBindingSource
            // 
            this.metaModelBindingSource.DataSource = typeof(Hayman.Client.HaymanReadModelServiceReference.MetaModel);
            // 
            // MetaModelNameTextEdit
            // 
            this.MetaModelNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.metaModelBindingSource, "MetaModelName", true));
            this.MetaModelNameTextEdit.Location = new System.Drawing.Point(101, 12);
            this.MetaModelNameTextEdit.Name = "MetaModelNameTextEdit";
            this.MetaModelNameTextEdit.Size = new System.Drawing.Size(156, 20);
            this.MetaModelNameTextEdit.StyleController = this.dataLayoutControl1;
            this.MetaModelNameTextEdit.TabIndex = 5;
            // 
            // DeletedCheckEdit
            // 
            this.DeletedCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.metaModelBindingSource, "Deleted", true));
            this.DeletedCheckEdit.Location = new System.Drawing.Point(0, 0);
            this.DeletedCheckEdit.Name = "DeletedCheckEdit";
            this.DeletedCheckEdit.Properties.Caption = "Deleted";
            this.DeletedCheckEdit.Size = new System.Drawing.Size(0, 18);
            this.DeletedCheckEdit.StyleController = this.dataLayoutControl1;
            this.DeletedCheckEdit.TabIndex = 6;
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
            // ItemForDeleted
            // 
            this.ItemForDeleted.Control = this.DeletedCheckEdit;
            this.ItemForDeleted.CustomizationFormText = "Deleted";
            this.ItemForDeleted.Location = new System.Drawing.Point(0, 0);
            this.ItemForDeleted.Name = "ItemForDeleted";
            this.ItemForDeleted.Size = new System.Drawing.Size(0, 0);
            this.ItemForDeleted.Text = "Deleted";
            this.ItemForDeleted.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForDeleted.TextToControlDistance = 0;
            this.ItemForDeleted.TextVisible = false;
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(269, 156);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.CustomizationFormText = "autoGeneratedGroup0";
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForMetaModelName,
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.emptySpaceItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(249, 136);
            this.layoutControlGroup2.Text = "autoGeneratedGroup0";
            // 
            // ItemForMetaModelName
            // 
            this.ItemForMetaModelName.Control = this.MetaModelNameTextEdit;
            this.ItemForMetaModelName.CustomizationFormText = "Meta Model Name";
            this.ItemForMetaModelName.Location = new System.Drawing.Point(0, 0);
            this.ItemForMetaModelName.Name = "ItemForMetaModelName";
            this.ItemForMetaModelName.Size = new System.Drawing.Size(249, 24);
            this.ItemForMetaModelName.Text = "Meta Model Name";
            this.ItemForMetaModelName.TextSize = new System.Drawing.Size(85, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.okButton;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(85, 110);
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
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.cancelButton;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(167, 110);
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
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 24);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(249, 86);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 110);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(85, 26);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // RenameMetaModelForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(269, 156);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "RenameMetaModelForm";
            this.Text = "Rename MetaModel";
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MetaModelIdTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metaModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MetaModelNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeletedCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMetaModelId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDeleted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMetaModelName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.SimpleButton okButton;
        private DevExpress.XtraEditors.SimpleButton cancelButton;
        private DevExpress.XtraEditors.TextEdit MetaModelIdTextEdit;
        private System.Windows.Forms.BindingSource metaModelBindingSource;
        private DevExpress.XtraEditors.TextEdit MetaModelNameTextEdit;
        private DevExpress.XtraEditors.CheckEdit DeletedCheckEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForMetaModelId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDeleted;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForMetaModelName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}