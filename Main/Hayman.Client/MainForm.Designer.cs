namespace Hayman.Client
{
    partial class MainForm
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
            this.defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.metaModelListControl = new Hayman.Client.MetaModelListControl();
            this.metaItemListControl = new Hayman.Client.MetaItemListControl();
            this.metaAssociationListControl = new Hayman.Client.MetaAssociationListControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel
            // 
            this.defaultLookAndFeel.LookAndFeel.SkinName = "Black";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.metaAssociationListControl);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(926, 658);
            this.splitContainerControl1.SplitterPosition = 444;
            this.splitContainerControl1.TabIndex = 5;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.metaModelListControl);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.metaItemListControl);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(444, 658);
            this.splitContainerControl2.SplitterPosition = 336;
            this.splitContainerControl2.TabIndex = 1;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // metaModelListControl
            // 
            this.metaModelListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metaModelListControl.Location = new System.Drawing.Point(0, 0);
            this.metaModelListControl.Name = "metaModelListControl";
            this.metaModelListControl.Size = new System.Drawing.Size(444, 336);
            this.metaModelListControl.TabIndex = 0;
            // 
            // metaItemListControl
            // 
            this.metaItemListControl.DataSource = null;
            this.metaItemListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metaItemListControl.Location = new System.Drawing.Point(0, 0);
            this.metaItemListControl.Name = "metaItemListControl";
            this.metaItemListControl.Size = new System.Drawing.Size(444, 316);
            this.metaItemListControl.TabIndex = 0;
            // 
            // metaAssociationListControl
            // 
            this.metaAssociationListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metaAssociationListControl.Location = new System.Drawing.Point(0, 0);
            this.metaAssociationListControl.Name = "metaAssociationListControl";
            this.metaAssociationListControl.Size = new System.Drawing.Size(476, 658);
            this.metaAssociationListControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 658);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "MainForm";
            this.Text = "Hayman";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private MetaModelListControl metaModelListControl;
        private MetaItemListControl metaItemListControl;
        private MetaAssociationListControl metaAssociationListControl;
    }
}