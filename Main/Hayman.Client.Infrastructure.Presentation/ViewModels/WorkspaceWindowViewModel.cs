using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hayman.Client.Infrastructure.Core;
using System.Windows.Media.Imaging;
using System.Windows;
using Hayman.Client.Presentation.Windows.Controls;
using Hayman.Client.Infrastructure.Events;
using Hayman.Client.Infrastructure.Messaging;
using Hayman.Client.Infrastructure.ViewModels;
using System.Windows.Media;

namespace Hayman.Client.Presentation.Windows.ViewModels
{
    /// <summary>
    /// Base viewmodel class for workspace windows
    /// </summary>
    /// <typeparam name="TDataModel">The type of the data model.</typeparam>
    public class WorkspaceWindowViewModel : WindowViewModel, ITrackableWindow
    {
        private Visual thumbnail;
        private DelegateCommand restoreCommand;

        protected WorkspaceWindowViewModel(string displayName)
            : base(displayName)
        {
            //View = View;
        }

        #region ITrackableWindow Members

        /// <summary>
        /// Gets or sets the window thumbnail.
        /// </summary>
        /// <value>The thumbnail.</value>
        public Visual Thumbnail
        {
            get { return thumbnail; }
            set
            {
                if (thumbnail != value)
                {
                    thumbnail = value;
                    RaisePropertyChanged(() => Thumbnail);
                }
            }
        }

        /// <summary>
        /// Gets the restore command.
        /// </summary>
        /// <value>The restore command.</value>
        public DelegateCommand RestoreCommand
        {
            get
            {
                if (this.restoreCommand == null)
                {
                    this.restoreCommand = new DelegateCommand(() => OnRestore());
                }

                return this.restoreCommand;
            }
        }

        #endregion
       
        #region Command Actions

        protected virtual void OnRestore()
        {
            Channel<DesktopElementChangedEvent, DesktopElementChangedEventPayload>
                .Publish(new DesktopElementChangedEventPayload(Id, DesktopElementAction.Restored));
        }

        #endregion
    }
}
