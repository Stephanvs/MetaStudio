using System;
using System.Windows.Input;
using Hayman.Client.Infrastructure.Events;
using Hayman.Client.Infrastructure.Messaging;
using Hayman.Client.Infrastructure.ViewModels;
using Hayman.Client.Infrastructure.Core;

namespace Hayman.Client.Presentation.Windows.ViewModels
{
    public abstract class ShortcutViewModelBase : ClosableViewModel, IShortcutViewModel
	{
		private ICommand openCommand;

		public ICommand OpenCommand
		{
			get
			{
				if (openCommand == null)
				{
					openCommand = new DelegateCommand(o => OnOpen());
				}

				return openCommand;
			}
		}

		public abstract string IconStyle { get; set; }

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
