using System;
using System.Windows;

namespace Hayman.Shell
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
        public App()
        {
            InitializeComponent();
        }

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			Bootstrapper bootstrapper = new Bootstrapper();
			bootstrapper.Run();
		}
	}
}
