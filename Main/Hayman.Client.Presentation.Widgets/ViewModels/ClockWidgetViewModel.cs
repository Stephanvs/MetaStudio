using System;
using Hayman.Client.Presentation.Windows.ViewModels;
using System.Windows.Input;
using Hayman.Client.Infrastructure.Core;
using Microsoft.Practices.ServiceLocation;

namespace Hayman.Client.Presentation.Widgets.ViewModels
{
    public class ClockWidgetViewModel : WidgetViewModel
    {   
        private ICommand createWidgetCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="CalendarWidgetViewModel"></see> class.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        public ClockWidgetViewModel()
            : base("Clock")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CalendarWidgetViewModel"></see> class.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        protected ClockWidgetViewModel(string displayName)
            : base(displayName)
        {
            
        }
         
        /// <summary>
        /// Gets the create widget command.
        /// </summary>
        /// <value>The create widget command.</value>
        public ICommand CreateWidgetCommand
        {
            get
            {
                if (createWidgetCommand == null)
                {
                    createWidgetCommand = new DelegateCommand(() => OnCreateWidget());
                }

                return createWidgetCommand;
            }
        }

        /// <summary>
        /// Gets the widget description
        /// </summary>
        public override string Description
        {
            get { return "Clock"; }
            set { }
        }

        /// <summary>
        /// Handles the create widget command.
        /// </summary>
        private static void OnCreateWidget()
        {
            ServiceLocator.Current.GetInstance<IDesktopManager>().Show(new ClockWidgetViewModel());
        }
    }
}
