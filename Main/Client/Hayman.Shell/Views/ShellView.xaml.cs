using System;
using System.Windows;
using Hayman.Shell.ViewModels;
using System.Windows.Interop;
using Microsoft.Practices.ServiceLocation;
using Hayman.Client.Infrastructure.Core;
using Hayman.Client.Presentation.Widgets.ViewModels;

namespace Hayman.Shell.Views
{
	/// <summary>
	/// Interaction logic for ShellView.xaml
	/// </summary>
	public partial class ShellView :
		Window, 
		IShellView
	{


		public ShellView()
		{
			InitializeComponent();
		}

		public void ShowView()
		{
			Show();
		}

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            // http://blogs.msdn.com/b/llobo/archive/2006/08/01/maximizing-window-_2800_with-windowstyle_3d00_none_2900_-considering-taskbar.aspx
            IntPtr handle = (new WindowInteropHelper(this)).Handle;
            HwndSource.FromHwnd(handle).AddHook(new HwndSourceHook(Win32Interop.WindowProc));

            ShellViewModel vm = new ShellViewModel(this);
            this.DataContext = vm;

            vm.WindowState = System.Windows.WindowState.Maximized;
        }
	}
}
