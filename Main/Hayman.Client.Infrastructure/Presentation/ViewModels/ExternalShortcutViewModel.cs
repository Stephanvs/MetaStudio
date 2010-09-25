using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Hayman.Client.Infrastructure.Events;
using Hayman.Client.Infrastructure.Messaging;

namespace Hayman.Client.Infrastructure.Presentation.ViewModels
{
	public class ExternalShortcutViewModel : ShortcutViewModelBase
	{
		static readonly string DefaultIconStyle = "ArrowRight01IconStyle";
		private string iconStyle;
		private Uri target;

		public ExternalShortcutViewModel(string displayName, Uri target)
		{
			this.DisplayName = displayName;
			this.target = target;
		}

		/// <summary>
		/// Gets or sets the shortcut icon style.
		/// </summary>
		/// <value>The icon style.</value>
		public override string IconStyle
		{
			get
			{
				if (String.IsNullOrEmpty(iconStyle))
				{
					return DefaultIconStyle;
				}

				return iconStyle;
			}
			set
			{
				if (iconStyle != value)
				{
					iconStyle = value;
					RaisePropertyChanged(() => IconStyle);
				}
			}
		}

		/// <summary>
		/// Gets or sets the shortcut target.
		/// </summary>
		/// <value>The shortcut target.</value>
		public Uri Target
		{
			get { return target; }
			set
			{
				if (target != value)
				{
					target = value;
					RaisePropertyChanged(() => Target);
				}
			}
		}

		/// <summary>
		/// Called when the <see cref="OpenCommand"/>  is executed.
		/// </summary>
		protected override void OnOpen()
		{
			Task task = Task.Factory.StartNew(() =>
			{
				using (Process process = new Process())
				{
					process.StartInfo.FileName = this.Target.ToString();
					process.StartInfo.UseShellExecute = true;
					process.StartInfo.LoadUserProfile = true;
					process.Start();
				}
			})
			.ContinueWith((t) =>
			{
				Debug.WriteLine("I have observed a {0}", t.Exception.InnerException.GetType().Name);

				//IShowMessageViewService showMessageService = ViewServiceLocator.GetViewService<IShowMessageViewService>();

				//showMessageService.ButtonSetup = DialogButton.Ok;
				//showMessageService.Caption = "Problem with Shortcut";
				//showMessageService.Text =
				//    String.Format(
				//        "An error has occurred while runninng the shortcut '{0}'",
				//            this.DisplayName);

				//if (showMessageService.ShowMessage() == DialogResult.Yes)
				//{
					Channel<DesktopElementChangedEvent, DesktopElementChangedEventPayload>
						.Publish(new DesktopElementChangedEventPayload(Id, DesktopElementAction.Closed));
				//}
			}, TaskContinuationOptions.OnlyOnFaulted);
		}

		protected override bool CanCloseView()
		{
			return true;
		}

		protected override void OnCloseView()
		{
			base.OnCloseView();
		}
	}
}
