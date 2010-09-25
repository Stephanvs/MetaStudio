using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Presentation.Commands;
using Hayman.Client.Infrastructure.ViewModels;
using Hayman.Client.Infrastructure.Messaging;
using Hayman.Client.Infrastructure.Events;
using System.Windows.Input;

namespace Hayman.Client.Infrastructure.Presentation.ViewModels
{
	public class ClosableViewModel : ViewModelBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ClosableViewModel"/> class.
		/// </summary>
		protected ClosableViewModel()
			: this(String.Empty)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ClosableViewModel"/> class.
		/// </summary>
		/// <param name="displayName"></param>
		protected ClosableViewModel(string displayName) : base(displayName)
		{
			this.Id = Guid.NewGuid();
		}

		private ICommand closeCommand;

		private Guid _id;
		public Guid Id
		{
			get { return _id; }
			set
			{
				if (this._id != value)
				{
					this._id = value;
					this.RaisePropertyChanged(() => Id);
				}
			}
		}

		public ICommand CloseCommand
		{
			get
			{
				if (closeCommand == null)
				{
					closeCommand = new DelegateCommand<object>(
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
