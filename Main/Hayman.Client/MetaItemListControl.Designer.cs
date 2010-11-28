namespace Hayman.Client
{
    partial class MetaItemListControl
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
            this.addMetaItemButton = new DevExpress.XtraBars.BarButtonItem();
            this.renameMetaItemButton = new DevExpress.XtraBars.BarButtonItem();
            this.removeMetaItemButton = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.metaItemGrid = new DevExpress.XtraGrid.GridControl();
            this.metaItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.metaItemGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMetaItemId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMetaItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metaItemGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metaItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metaItemGridView)).BeginInit();
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
            this.addMetaItemButton,
            this.removeMetaItemButton,
            this.renameMetaItemButton});
            this.barManager.MaxItemId = 3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.addMetaItemButton),
            new DevExpress.XtraBars.LinkPersistInfo(this.renameMetaItemButton),
            new DevExpress.XtraBars.LinkPersistInfo(this.removeMetaItemButton)});
            this.bar1.Text = "Tools";
            // 
            // addMetaItemButton
            // 
            this.addMetaItemButton.Caption = "Add MetaItem";
            this.addMetaItemButton.Id = 0;
            this.addMetaItemButton.Name = "addMetaItemButton";
            this.addMetaItemButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.addMetaItemButton_ItemClick);
            // 
            // renameMetaItemButton
            // 
            this.renameMetaItemButton.Caption = "Rename MetaItem";
            this.renameMetaItemButton.Id = 2;
            this.renameMetaItemButton.Name = "renameMetaItemButton";
            this.renameMetaItemButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.renameMetaItemButton_ItemClick);
            // 
            // removeMetaItemButton
            // 
            this.removeMetaItemButton.Caption = "Remove MetaItem";
            this.removeMetaItemButton.Id = 1;
            this.removeMetaItemButton.Name = "removeMetaItemButton";
            this.removeMetaItemButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.removeMetaItemButton_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(779, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 611);
            this.barDockControlBottom.Size = new System.Drawing.Size(779, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 587);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(779, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 587);
            // 
            // metaItemGrid
            // 
            this.metaItemGrid.DataSource = this.metaItemBindingSource;
            this.metaItemGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metaItemGrid.Location = new System.Drawing.Point(0, 24);
            this.metaItemGrid.MainView = this.metaItemGridView;
            this.metaItemGrid.MenuManager = this.barManager;
            this.metaItemGrid.Name = "metaItemGrid";
            this.metaItemGrid.Size = new System.Drawing.Size(779, 587);
            this.metaItemGrid.TabIndex = 5;
            this.metaItemGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.metaItemGridView});
            // 
            // metaItemBindingSource
            // 
            this.metaItemBindingSource.DataSource = typeof(Hayman.Client.HaymanReadModelServiceReference.MetaItem);
            this.metaItemBindingSource.CurrentChanged += new System.EventHandler(this.metaItemBindingSource_CurrentChanged);
            // 
            // metaItemGridView
            // 
            this.metaItemGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMetaItemId,
            this.colMetaItemName});
            this.metaItemGridView.GridControl = this.metaItemGrid;
            this.metaItemGridView.Name = "metaItemGridView";
            this.metaItemGridView.OptionsBehavior.Editable = false;
            this.metaItemGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            // 
            // colMetaItemId
            // 
            this.colMetaItemId.Caption = "Id";
            this.colMetaItemId.FieldName = "MetaItemId";
            this.colMetaItemId.Name = "colMetaItemId";
            this.colMetaItemId.Visible = true;
            this.colMetaItemId.VisibleIndex = 0;
            // 
            // colMetaItemName
            // 
            this.colMetaItemName.Caption = "Name";
            this.colMetaItemName.FieldName = "MetaItemName";
            this.colMetaItemName.Name = "colMetaItemName";
            this.colMetaItemName.Visible = true;
            this.colMetaItemName.VisibleIndex = 1;
            // 
            // MetaItemListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metaItemGrid);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "MetaItemListControl";
            this.Size = new System.Drawing.Size(779, 611);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metaItemGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metaItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metaItemGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl metaItemGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView metaItemGridView;
        private DevExpress.XtraBars.BarButtonItem addMetaItemButton;
        private DevExpress.XtraBars.BarButtonItem removeMetaItemButton;
        private DevExpress.XtraBars.BarButtonItem renameMetaItemButton;
        private DevExpress.XtraGrid.Columns.GridColumn colMetaItemId;
        private DevExpress.XtraGrid.Columns.GridColumn colMetaItemName;
        private System.Windows.Forms.BindingSource metaItemBindingSource;
    }
}
