using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.ServiceLocation;

namespace Hayman.Client.Infrastructure.Presentation.ViewModels
{
	public class InternalShortcutViewModel : ShortcutViewModelBase
	{
		static readonly string DefaultIconStyle = "WindowIconStyle";
		private string iconStyle;
		private string target;

		/// <summary>
		/// Gets or sets the icon style.
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
		public string Target
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
			Console.WriteLine("OnOpen called on '{0}'", target);
			//ServiceLocator.GetService<INavigationService>().NavigateTo(this.Target);
		}
	}
}
