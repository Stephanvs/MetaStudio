using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

namespace Hayman.Client.Infrastructure.Presentation.Windows.Controls
{
	public class ShortcutElement : DesktopElement
	{
		static ShortcutElement()
		{
			// set the key to reference the style for this control
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(
				typeof(ShortcutElement), new FrameworkPropertyMetadata(typeof(ShortcutElement)));

			FocusManager.IsFocusScopeProperty.OverrideMetadata(
				typeof(ShortcutElement), new FrameworkPropertyMetadata(true));

			Control.IsTabStopProperty.OverrideMetadata(typeof(ShortcutElement),
				new FrameworkPropertyMetadata(false));

			KeyboardNavigation.DirectionalNavigationProperty.OverrideMetadata(
				typeof(ShortcutElement), new FrameworkPropertyMetadata(KeyboardNavigationMode.None));

			KeyboardNavigation.TabNavigationProperty.OverrideMetadata(
				typeof(ShortcutElement), new FrameworkPropertyMetadata(KeyboardNavigationMode.None));

			KeyboardNavigation.ControlTabNavigationProperty.OverrideMetadata(
				typeof(ShortcutElement), new FrameworkPropertyMetadata(KeyboardNavigationMode.None));

		}
	}
}
