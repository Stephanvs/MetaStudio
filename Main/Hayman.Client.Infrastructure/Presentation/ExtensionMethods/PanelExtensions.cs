using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace Hayman.Client.Infrastructure.Presentation.ExtensionMethods
{
	public static class PanelExtensions
	{
		/// <summary>
		/// Brings the element to the front of the z-order.
		/// </summary>
		/// <param name="panel">The canvas.</param>
		/// <param name="element">The element.</param>
		public static void BringToFront(this Panel panel, UIElement element)
		{
			int index = Panel.GetZIndex(element);
			Panel.SetZIndex(element, panel.Children.Count + 1);

			#region · Define ZIndex Order ·

			UIElement[] sortAux = new UIElement[panel.Children.Count];

			panel.Children.CopyTo(sortAux, 0);

			Array.Sort<UIElement>(sortAux, new Comparison<UIElement>(delegate(UIElement a, UIElement b)
			{
				int aIndex = Canvas.GetZIndex(a);
				int bIndex = Canvas.GetZIndex(b);

				if (aIndex > bIndex)
				{
					return 1;
				}
				else if (aIndex == bIndex)
				{
					return 0;
				}
				else
				{
					return -1;
				}
			}));

			#endregion

			for (int i = 0; i < sortAux.Length; i++)
			{
				Panel.SetZIndex(sortAux[i], i);
			}
		}

		/// <summary>
		/// Brings the element to the bottom of the z-order.
		/// </summary>
		/// <param name="panel">The panel.</param>
		/// <param name="element">The element.</param>
		public static void BringToBottom(this Panel panel, UIElement element)
		{
			int index = Panel.GetZIndex(element);
			Panel.SetZIndex(element, -1);

			#region · Define ZIndex Order ·

			UIElement[] sortAux = new UIElement[panel.Children.Count];

			panel.Children.CopyTo(sortAux, 0);

			Array.Sort<UIElement>(sortAux, new Comparison<UIElement>(delegate(UIElement a, UIElement b)
			{
				int aIndex = Canvas.GetZIndex(a);
				int bIndex = Canvas.GetZIndex(b);

				if (aIndex > bIndex)
				{
					return 1;
				}
				else if (aIndex == bIndex)
				{
					return 0;
				}
				else
				{
					return -1;
				}
			}));

			#endregion

			for (int i = 0; i < sortAux.Length; i++)
			{
				Panel.SetZIndex(sortAux[i], i);
			}
		}
	}
}
