namespace Hayman.Client
{
    partial class MetaModelListControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.createMetaModelButton = new DevExpress.XtraBars.BarButtonItem();
            this.renameMetaModelButton = new DevExpress.XtraBars.BarButtonItem();
            this.deleteMetaModelButton = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.metaModelGrid = new DevExpress.XtraGrid.GridControl();
            this.metaModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.metaModelGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMetaModelId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMetaModelName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeleted = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metaModelGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metaModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metaModelGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.createMetaModelButton,
            this.deleteMetaModelButton,
            this.renameMetaModelButton});
            this.barManager.MaxItemId = 3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.createMetaModelButton),
            new DevExpress.XtraBars.LinkPersistInfo(this.renameMetaModelButton),
            new DevExpress.XtraBars.LinkPersistInfo(this.deleteMetaModelButton)});
            this.bar1.Text = "Tools";
            // 
            // createMetaModelButton
            // 
            this.createMetaModelButton.Caption = "Create MetaModel";
            this.createMetaModelButton.Id = 0;
            this.createMetaModelButton.Name = "createMetaModelButton";
            this.createMetaModelButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.createMetaModelButton_ItemClick);
            // 
            // renameMetaModelButton
            // 
            this.renameMetaModelButton.Caption = "RenameMetaModel";
            this.renameMetaModelButton.Id = 2;
            this.renameMetaModelButton.Name = "renameMetaModelButton";
            this.renameMetaModelButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.renameMetaModelButton_ItemClick);
            // 
            // deleteMetaModelButton
            // 
            this.deleteMetaModelButton.Caption = "Delete MetaModel";
            this.deleteMetaModelButton.Id = 1;
            this.deleteMetaModelButton.Name = "deleteMetaModelButton";
            this.deleteMetaModelButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.deleteMetaModelButton_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(716, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 445);
            this.barDockControlBottom.Size = new System.Drawing.Size(716, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 421);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(716, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 421);
            // 
            // metaModelGrid
            // 
            this.metaModelGrid.DataSource = this.metaModelBindingSource;
            this.metaModelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metaModelGrid.Location = new System.Drawing.Point(0, 24);
            this.metaModelGrid.MainView = this.metaModelGridView;
            this.metaModelGrid.MenuManager = this.barManager;
            this.metaModelGrid.Name = "metaModelGrid";
            this.metaModelGrid.Size = new System.Drawing.Size(716, 421);
            this.metaModelGrid.TabIndex = 9;
            this.metaModelGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.metaModelGridView});
            // 
            // metaModelBindingSource
            // 
            this.metaModelBindingSource.AllowNew = true;
            this.metaModelBindingSource.DataSource = typeof(Hayman.Client.HaymanReadModelServiceReference.MetaModel);
            // 
            // metaModelGridView
            // 
            this.metaModelGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMetaModelId,
            this.colMetaModelName,
            this.colDeleted});
            this.metaModelGridView.GridControl = this.metaModelGrid;
            this.metaModelGridView.Name = "metaModelGridView";
            this.metaModelGridView.OptionsBehavior.Editable = false;
            this.metaModelGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            // 
            // colMetaModelId
            // 
            this.colMetaModelId.Caption = "Id";
            this.colMetaModelId.FieldName = "MetaModelId";
            this.colMetaModelId.Name = "colMetaModelId";
            this.colMetaModelId.Visible = true;
            this.colMetaModelId.VisibleIndex = 0;
            // 
            // colMetaModelName
            // 
            this.colMetaModelName.Caption = "Name";
            this.colMetaModelName.FieldName = "MetaModelName";
            this.colMetaModelName.Name = "colMetaModelName";
            this.colMetaModelName.Visible = true;
            this.colMetaModelName.VisibleIndex = 1;
            // 
            // colDeleted
            // 
            this.colDeleted.Caption = "Deleted";
            this.colDeleted.FieldName = "Deleted";
            this.colDeleted.Name = "colDeleted";
            this.colDeleted.Visible = true;
            this.colDeleted.VisibleIndex = 2;
            // 
            // MetaModelListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metaModelGrid);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "MetaModelListControl";
            this.Size = new System.Drawing.Size(716, 445);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metaModelGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metaModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metaModelGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem createMetaModelButton;
        private DevExpress.XtraBars.BarButtonItem deleteMetaModelButton;
        private DevExpress.XtraBars.BarButtonItem renameMetaModelButton;
        private DevExpress.XtraGrid.GridControl metaModelGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView metaModelGridView;
        private DevExpress.XtraGrid.Columns.GridColumn colMetaModelId;
        private DevExpress.XtraGrid.Columns.GridColumn colMetaModelName;
        private DevExpress.XtraGrid.Columns.GridColumn colDeleted;
        private System.Windows.Forms.BindingSource metaModelBindingSource;
    }
}
