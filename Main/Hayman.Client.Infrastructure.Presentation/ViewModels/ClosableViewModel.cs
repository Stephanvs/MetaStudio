using System;
using Microsoft.Practices.Composite.Presentation.Commands;
using Hayman.Client.Infrastructure.ViewModels;
using Hayman.Client.Infrastructure.Messaging;
using Hayman.Client.Infrastructure.Events;
using System.Windows.Input;
using Hayman.Client.Infrastructure.Core;

namespace Hayman.Client.Presentation.Windows.ViewModels
{
    public class ClosableViewModel : ViewModelBase, IClosableViewModel
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ClosableViewModel"/> class.
		/// </summary>
		/// <param name="displayName"></param>
		protected ClosableViewModel(string displayName) : base(displayName)
		{
			Id = Guid.NewGuid();
		}

		private ICommand closeCommand;

		private Guid id;
		public Guid Id
		{
			get { return id; }
			set
			{
				if (id != value)
				{
					id = value;
					RaisePropertyChanged(() => Id);
				}
			}
		}

		public ICommand CloseCommand
		{
			get
			{
				if (closeCommand == null)
				{
                    closeCommand = new DelegateCommand(
						o => OnCloseView(),
						o => CanCloseView());
				}

				return closeCommand;
			}
		}

		/// <summary>
		/// Determines whether the view related to this view model can be closed.
		/// </summary>
		/// <returns>
		/// 	<c>true</c> if the related view can be closed; otherwise, <c>false</c>.
		/// </returns>
		protected virtual bool CanCloseView()
		{
			return true;
		}

		/// <summary>
		/// Called when the related view is being closed.
		/// </summary>
		protected virtual void OnCloseView()
		{
			Channel<DesktopElementChangedEvent, DesktopElementChangedEventPayload>
				.Publish(new DesktopElementChangedEventPayload(Id, DesktopElementAction.Closed));
		}
	}
}
