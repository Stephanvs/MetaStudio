using System;
using DevExpress.XtraEditors;

namespace Hayman.Client
{
    public partial class MainForm : XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
            metaModelListControl.MetaModelChanged += metaModelListControl_MetaModelChanged;
        }

        void metaModelListControl_MetaModelChanged(HaymanReadModelServiceReference.MetaModel metaModel)
        {
            metaItemListControl.DataSource = metaModel;
        }
    }
}