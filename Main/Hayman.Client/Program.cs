using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Hayman.Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.Skins.SkinManager.EnableFormSkins();
            Application.Run(new MainForm());
        }
    }
}
