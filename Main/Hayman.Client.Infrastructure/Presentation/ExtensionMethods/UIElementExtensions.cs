using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Hayman.Client.Infrastructure.Presentation.ExtensionMethods
{
	public static class UIElementExtensions
	{
		/// <summary>
		/// Moves the specified element to the given position.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="position">The position.</param>
		public static void Move(this UIElement element, Point position)
		{
			element.Move(position.X, position.Y);
		}

		/// <summary>
		/// Moves the specified element to the given position.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="left">The left.</param>
		/// <param name="top">The top.</param>
		public static void Move(this UIElement element, double left, double top)
		{
			element.MoveLeft(left);
			element.MoveTop(top);
		}

		/// <summary>
		/// Moves the specified element to the given left position.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="left">The left.</param>
		public static void MoveLeft(this UIElement element, double left)
		{
			Canvas.SetLeft(element, left);
		}

		/// <summary>
		/// Moves the specified element to the given top position.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="top">The top.</param>
		public static void MoveTop(this UIElement element, double top)
		{
			Canvas.SetTop(element, top);
		}

		/// <summary>
		/// Sets the value of the ZIndex attached property for a given object. 
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="zindex">The zindex.</param>
		public static void SetZIndex(this UIElement element, int zindex)
		{
			Canvas.SetZIndex(element, zindex);
		}

		/// <summary>
		/// Gets the parent.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="element">The element.</param>
		/// <returns></returns>
		public static T GetParent<T>(this UIElement element) where T : UIElement
		{
			// Walk the VisualTree to obtain the DesktopItem of the DragThumb
			DependencyObject parent = VisualTreeHelper.GetParent(element);

			while (parent != null && !(parent is T))
			{
				parent = VisualTreeHelper.GetParent(parent);
			}

			return parent as T;
		}

		/// <summary>
		/// Gets the canvas left position.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <returns></returns>
		public static Point GetCanvasLeftPosition(this UIElement element)
		{
			return new Point(Canvas.GetLeft(element), Canvas.GetTop(element));
		}
	}
}
