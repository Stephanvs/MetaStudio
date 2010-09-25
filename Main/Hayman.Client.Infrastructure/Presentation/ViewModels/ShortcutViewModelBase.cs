using System;
using System.Windows.Input;
using Hayman.Client.Infrastructure.Events;
using Hayman.Client.Infrastructure.Messaging;
using Microsoft.Practices.Composite.Presentation.Commands;

namespace Hayman.Client.Infrastructure.Presentation.ViewModels
{
	public abstract class ShortcutViewModelBase : ClosableViewModel
	{
		private ICommand openCommand;

		public ICommand OpenCommand
		{
			get
			{
				if (this.openCommand == null)
				{
					this.openCommand = new DelegateCommand<object>(o => OnOpen());
				}

				return this.openCommand;
			}
		}

		public abstract string IconStyle { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ShortcutViewModelBase"/> class.
		/// </summary>
		protected ShortcutViewModelBase()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ShortcutViewModelBase"/> class.
		/// </summary>
		protected ShortcutViewModelBase(string displayName)
			: base(displayName)
		{
		}

		/// <summary>
		/// Called when the <see cref="OpenCommand"/>  is executed.
		/// </summary>
		protected abstract void OnOpen();

		/// <summary>
		/// Called when the related view is being closed.
		/// </summary>
		protected override void OnCloseView()
		{
			//IShowMessageViewService showMessageService = ViewServiceLocator.GetViewService<IShowMessageViewService>();

			//var md = new MessageDialogViewModel()
			//{
			//	Title = Resources.MessageDialog_Title_DeleteShortcut,
			//	Text = String.Format(Resources.MessageDialog_Text_DeleteShortcut, Environment.NewLine, this.DisplayName)
			//};

			//if (showMessageService.ShowDialog(md).DialogResult.GetValueOrDefault())
			//{
				Channel<DesktopElementChangedEvent, DesktopElementChangedEventPayload>
					.Publish(new DesktopElementChangedEventPayload(Id, DesktopElementAction.Closed));
			//}
		}
	}
}
