namespace Hayman.Client
{
    partial class MetaAssociationListControl
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
            this.createMetaAssociationButton = new DevExpress.XtraBars.BarButtonItem();
            this.deleteMetaAssociationButton = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.renameMetaAssociationButton = new DevExpress.XtraBars.BarButtonItem();
            this.metaAssociationGrid = new DevExpress.XtraGrid.GridControl();
            this.metaAssociationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.metaAssociationGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMetaAssociationId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMetaItemSourceId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.metaItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.repositoryItemGridLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.metaModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.repositoryItemGridLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMetaItemId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMetaItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMetaModelId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMetaItemTargetId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeleted = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metaAssociationGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metaAssociationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metaAssociationGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metaItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metaModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
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
            this.createMetaAssociationButton,
            this.deleteMetaAssociationButton,
            this.renameMetaAssociationButton});
            this.barManager.MaxItemId = 3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.createMetaAssociationButton),
            new DevExpress.XtraBars.LinkPersistInfo(this.deleteMetaAssociationButton)});
            this.bar1.Text = "Tools";
            // 
            // createMetaAssociationButton
            // 
            this.createMetaAssociationButton.Caption = "Create MetaAssociation";
            this.createMetaAssociationButton.Id = 0;
            this.createMetaAssociationButton.Name = "createMetaAssociationButton";
            this.createMetaAssociationButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.createMetaAssociationButton_ItemClick);
            // 
            // deleteMetaAssociationButton
            // 
            this.deleteMetaAssociationButton.Caption = "Delete MetaAssociation";
            this.deleteMetaAssociationButton.Id = 1;
            this.deleteMetaAssociationButton.Name = "deleteMetaAssociationButton";
            this.deleteMetaAssociationButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.deleteMetaAssociationButton_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(873, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 600);
            this.barDockControlBottom.Size = new System.Drawing.Size(873, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 576);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(873, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 576);
            // 
            // renameMetaAssociationButton
            // 
            this.renameMetaAssociationButton.Caption = "Rename MetaAssociation";
            this.renameMetaAssociationButton.Id = 2;
            this.renameMetaAssociationButton.Name = "renameMetaAssociationButton";
            // 
            // metaAssociationGrid
            // 
            this.metaAssociationGrid.DataSource = this.metaAssociationBindingSource;
            this.metaAssociationGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metaAssociationGrid.Location = new System.Drawing.Point(0, 24);
            this.metaAssociationGrid.MainView = this.metaAssociationGridView;
            this.metaAssociationGrid.MenuManager = this.barManager;
            this.metaAssociationGrid.Name = "metaAssociationGrid";
            this.metaAssociationGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemGridLookUpEdit1});
            this.metaAssociationGrid.Size = new System.Drawing.Size(873, 576);
            this.metaAssociationGrid.TabIndex = 5;
            this.metaAssociationGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.metaAssociationGridView});
            // 
            // metaAssociationBindingSource
            // 
            this.metaAssociationBindingSource.DataSource = typeof(Hayman.Client.HaymanReadModelServiceReference.MetaAssociation);
            this.metaAssociationBindingSource.CurrentChanged += new System.EventHandler(this.metaAssociationBindingSource_CurrentChanged);
            // 
            // metaAssociationGridView
            // 
            this.metaAssociationGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMetaAssociationId,
            this.colMetaItemSourceId,
            this.colMetaItemTargetId,
            this.colDeleted});
            this.metaAssociationGridView.GridControl = this.metaAssociationGrid;
            this.metaAssociationGridView.Name = "metaAssociationGridView";
            this.metaAssociationGridView.OptionsBehavior.Editable = false;
            this.metaAssociationGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            // 
            // colMetaAssociationId
            // 
            this.colMetaAssociationId.Caption = "Id";
            this.colMetaAssociationId.FieldName = "MetaAssociationId";
            this.colMetaAssociationId.Name = "colMetaAssociationId";
            this.colMetaAssociationId.Visible = true;
            this.colMetaAssociationId.VisibleIndex = 0;
            // 
            // colMetaItemSourceId
            // 
            this.colMetaItemSourceId.Caption = "Source";
            this.colMetaItemSourceId.ColumnEdit = this.repositoryItemGridLookUpEdit1;
            this.colMetaItemSourceId.FieldName = "MetaItemSourceId";
            this.colMetaItemSourceId.Name = "colMetaItemSourceId";
            this.colMetaItemSourceId.Visible = true;
            this.colMetaItemSourceId.VisibleIndex = 1;
            // 
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit1.DataSource = this.metaItemBindingSource;
            this.repositoryItemGridLookUpEdit1.DisplayMember = "MetaItemName";
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemGridLookUpEdit2});
            this.repositoryItemGridLookUpEdit1.ValueMember = "MetaItemId";
            this.repositoryItemGridLookUpEdit1.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // metaItemBindingSource
            // 
            this.metaItemBindingSource.DataSource = typeof(Hayman.Client.HaymanReadModelServiceReference.MetaItem);
            // 
            // repositoryItemGridLookUpEdit2
            // 
            this.repositoryItemGridLookUpEdit2.AutoHeight = false;
            this.repositoryItemGridLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit2.DataSource = this.metaModelBindingSource;
            this.repositoryItemGridLookUpEdit2.DisplayMember = "MetaModelName";
            this.repositoryItemGridLookUpEdit2.Name = "repositoryItemGridLookUpEdit2";
            this.repositoryItemGridLookUpEdit2.ValueMember = "MetaModelId";
            this.repositoryItemGridLookUpEdit2.View = this.repositoryItemGridLookUpEdit2View;
            // 
            // metaModelBindingSource
            // 
            this.metaModelBindingSource.DataSource = typeof(Hayman.Client.HaymanReadModelServiceReference.MetaModel);
            // 
            // repositoryItemGridLookUpEdit2View
            // 
            this.repositoryItemGridLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit2View.Name = "repositoryItemGridLookUpEdit2View";
            this.repositoryItemGridLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMetaItemId,
            this.colMetaItemName,
            this.colMetaModelId});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colMetaItemId
            // 
            this.colMetaItemId.FieldName = "MetaItemId";
            this.colMetaItemId.Name = "colMetaItemId";
            this.colMetaItemId.Visible = true;
            this.colMetaItemId.VisibleIndex = 0;
            // 
            // colMetaItemName
            // 
            this.colMetaItemName.FieldName = "MetaItemName";
            this.colMetaItemName.Name = "colMetaItemName";
            this.colMetaItemName.Visible = true;
            this.colMetaItemName.VisibleIndex = 1;
            // 
            // colMetaModelId
            // 
            this.colMetaModelId.ColumnEdit = this.repositoryItemGridLookUpEdit2;
            this.colMetaModelId.FieldName = "MetaModelId";
            this.colMetaModelId.Name = "colMetaModelId";
            this.colMetaModelId.Visible = true;
            this.colMetaModelId.VisibleIndex = 2;
            // 
            // colMetaItemTargetId
            // 
            this.colMetaItemTargetId.Caption = "Target";
            this.colMetaItemTargetId.ColumnEdit = this.repositoryItemGridLookUpEdit1;
            this.colMetaItemTargetId.FieldName = "MetaItemTargetId";
            this.colMetaItemTargetId.Name = "colMetaItemTargetId";
            this.colMetaItemTargetId.Visible = true;
            this.colMetaItemTargetId.VisibleIndex = 2;
            // 
            // colDeleted
            // 
            this.colDeleted.Caption = "Deleted";
            this.colDeleted.FieldName = "Deleted";
            this.colDeleted.Name = "colDeleted";
            this.colDeleted.Visible = true;
            this.colDeleted.VisibleIndex = 3;
            // 
            // MetaAssociationListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metaAssociationGrid);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "MetaAssociationListControl";
            this.Size = new System.Drawing.Size(873, 600);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metaAssociationGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metaAssociationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metaAssociationGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metaItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metaModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl metaAssociationGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView metaAssociationGridView;
        private DevExpress.XtraBars.BarButtonItem createMetaAssociationButton;
        private DevExpress.XtraBars.BarButtonItem deleteMetaAssociationButton;
        private DevExpress.XtraBars.BarButtonItem renameMetaAssociationButton;
        private System.Windows.Forms.BindingSource metaAssociationBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colMetaAssociationId;
        private DevExpress.XtraGrid.Columns.GridColumn colMetaItemSourceId;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private System.Windows.Forms.BindingSource metaItemBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit2;
        private System.Windows.Forms.BindingSource metaModelBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit2View;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colMetaItemId;
        private DevExpress.XtraGrid.Columns.GridColumn colMetaItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colMetaModelId;
        private DevExpress.XtraGrid.Columns.GridColumn colMetaItemTargetId;
        private DevExpress.XtraGrid.Columns.GridColumn colDeleted;

    }
}
