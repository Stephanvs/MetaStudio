using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hayman.Client.Infrastructure.Presentation.Windows.Controls;
using Hayman.Client.Infrastructure.Events;
using Hayman.Client.Infrastructure.Messaging;

namespace Hayman.Client.Infrastructure.Presentation.ViewModels
{
	public class CustomShortcutViewModel : ShortcutViewModelBase
	{
		static readonly string DefaultIconStyle = "ArrowRight01IconStyle";
		private string iconStyle;
		private Action action;

		public Action Action
		{
			get { return action; }
			set 
			{
				if (action != value)
				{
					action = value;
					RaisePropertyChanged(() => Action);
				}
			}
		}

		/// <summary>
		/// Gets or sets the shortcut icon style.
		/// </summary>
		/// <value>The icon style.</value>
		public override string IconStyle
		{
			get
			{
				if (iconStyle == null)
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

		protected override void OnOpen()
		{
			Action.Invoke();

			Channel<DesktopWindowChangedEvent, DesktopWindowChangedEventPayload>
				.Publish(new DesktopWindowChangedEventPayload(DesktopWindowState.Opened));
		}
	}
}
