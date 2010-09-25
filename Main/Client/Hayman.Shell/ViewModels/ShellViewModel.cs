using System;
using Hayman.Client.Infrastructure.ViewModels;
using Hayman.Shell.Views;
using Microsoft.Practices.ServiceLocation;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows;
using Hayman.Client.Infrastructure.Core;
using Hayman.Client.Presentation.Widgets.ViewModels;
using Hayman.Client.Presentation.Windows.ViewModels;

namespace Hayman.Shell.ViewModels
{
	public class ShellViewModel : ViewModelBase
	{
		private IDesktopManager desktopManager = ServiceLocator.Current.GetInstance<IDesktopManager>();
		private string userName = String.Empty;
        private WindowState windowState = WindowState.Maximized;
        private ResizeMode resizeMode;
          
		public ShellViewModel(IShellView view) : base("Hayman")
		{
			View = view;
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="ShellViewModel"></see> class.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        protected ShellViewModel(string displayName)
            : base(displayName)
        {
            
        }
                 
		public IDesktop ActiveDesktop 
        {
			get
			{
				return desktopManager.ActiveDesktop;
			}
		}

		/// <summary>
		/// Gets the active windows.
		/// </summary>
		/// <value>The active windows.</value>
		public static ICollection<ITrackableWindow> ActiveWindows
		{
			get
			{
				if (ServiceLocator.Current.GetInstance<IDesktopManager>().ActiveDesktop != null)
				{
					return ServiceLocator.Current.GetInstance<IDesktopManager>().ActiveWindows;
				}

				return null;
			}
		}

		/// <summary>
		/// Gets the logged in user name
		/// </summary>
		public string Username
		{
			get
			{
				return (!String.IsNullOrEmpty(userName) ? userName : "Anonymous user");
			}
			set
			{
				userName = value;
				RaisePropertyChanged(() => Username);
			}
		}

        /// <summary>
        /// Gets or sets the state of the window.
        /// </summary>
        /// <value>The state of the window.</value>
        public WindowState WindowState
        {
            get { return windowState; }
            set
            {
                if (windowState != value)
                {
                    windowState = value;
                    RaisePropertyChanged(() => WindowState);
                }
            }
        }

        /// <summary>
        /// Gets or sets the resize mode.
        /// </summary>
        /// <value>The resize mode.</value>
        public ResizeMode ResizeMode
        {
            get { return resizeMode; }
            set
            {
                resizeMode = value;
                RaisePropertyChanged(() => ResizeMode);
            }
        }

        #region Commands

        private ICommand maximizeCommand;
        private ICommand minimizeCommand;
        private ICommand shutdownCommand;
        private ICommand showNavigationPanelCommand;
        private ICommand showCalendarCommand;
        private ICommand showClockCommand;

        /// <summary>
        /// Gets the maximize command.
        /// </summary>
        /// <value>The maximize command.</value>
        public ICommand MaximizeCommand
        {
            get
            {
                if (maximizeCommand == null)
                {
                    maximizeCommand = new DelegateCommand(() => OnMaximizeWindow());
                }

                return maximizeCommand;
            }
        }

        /// <summary>
        /// Gets the minimize command.
        /// </summary>
        /// <value>The minimize command.</value>
        public ICommand MinimizeCommand
        {
            get
            {
                if (minimizeCommand == null)
                {
                    minimizeCommand = new DelegateCommand(() => OnMinimizeWindow());
                }

                return minimizeCommand;
            }
        }

        /// <summary>
        /// Gets the shutdown command
        /// </summary>
        public ICommand ShutdownCommand
        {
            get
            {
                if (shutdownCommand == null)
                {
                    shutdownCommand = new DelegateCommand(() => OnShutdown());
                }

                return shutdownCommand;
            }
        }

        /// <summary>
        /// Gets the showNavigationPanelCommand command.
        /// </summary>
        /// <value>The showNavigationPanelCommand command.</value>
        public ICommand ShowNavigationPanelCommand
        {
            get
            {
                if (showNavigationPanelCommand == null)
                {
                    showNavigationPanelCommand = new DelegateCommand(() => OnShowNavigationPanel());
                }

                return showNavigationPanelCommand;
            }
        }

        /// <summary>
        /// Gets the ShowCalendarCommand command.
        /// </summary>
        /// <value>The ShowCalendarCommand command.</value>
        public ICommand ShowCalendarCommand
        {
            get
            {
                if (showCalendarCommand == null)
                {
                    showCalendarCommand = new DelegateCommand(() => OnShowCalendar());
                }

                return showCalendarCommand;
            }
        }

        /// <summary>
        /// Gets the ShowClockCommand command.
        /// </summary>
        /// <value>The ShowClockCommand command.</value>
        public ICommand ShowClockCommand
        {
            get
            {
                if (showClockCommand == null)
                {
                    showClockCommand = new DelegateCommand(() => OnShowClock());
                }

                return showClockCommand;
            }
        }

        #endregion

        #region Command Actions

        /// <summary>
        /// Handles the shutdown command action
        /// </summary>
        private static void OnShutdown()
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Maximizes the window.
        /// </summary>
        private void OnMaximizeWindow()
        {
            if (WindowState == WindowState.Maximized)
            {
                ResizeMode = ResizeMode.CanResize;
                WindowState = WindowState.Normal;
            }
            else
            {
                ResizeMode = ResizeMode.NoResize;
                WindowState = WindowState.Maximized;
            }
        }

        /// <summary>
        /// Handles the minimize window command action
        /// </summary>
        private void OnMinimizeWindow()
        {
            WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Handles the OnShowNavigationPanel command action
        /// </summary>
        private void OnShowNavigationPanel()
        {
            ServiceLocator.Current.GetInstance<IDesktopManager>().Show(new NavigatorWidgetViewModel());   
        }

        /// <summary>
        /// Handles the OnShowCalendar command action
        /// </summary>
        private void OnShowCalendar()
        {
            ServiceLocator.Current.GetInstance<IDesktopManager>().Show(new CalendarWidgetViewModel());
        }

        /// <summary>
        /// Handles the OnShowNavigationPanel command action
        /// </summary>
        private void OnShowClock()
        {
            ServiceLocator.Current.GetInstance<IDesktopManager>().Show(new ClockWidgetViewModel());
        }

        #endregion
	}
}
