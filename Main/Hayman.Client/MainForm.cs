using System;
using DevExpress.XtraEditors;
using Hayman.ReadModel;

namespace Hayman.Client
{
    public partial class MainForm : XtraForm
    {
        HaymanReadModelEntities db;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            db = new HaymanReadModelEntities();
           
        }
    }
}