﻿using System;

namespace Hayman.Client.Infrastructure.Core
{
	/// <summary>
	/// Structure for the possible drag and/or resize statuses
	/// </summary>
	[Serializable]
	public struct DragOrResizeStatus
	{
		#region · Consts ·

		const byte _TopLeft = 9;
		const byte _TopCenter = 10;
		const byte _TopRight = 12;
		const byte _MiddleLeft = 17;
		const byte _Drag = 18;
		const byte _MiddleRight = 20;
		const byte _BottomLeft = 33;
		const byte _BottomCenter = 34;
		const byte _BottomRight = 36;
		const byte _Left = 1;
		const byte _HMiddle = 2;
		const byte _Right = 4;
		const byte _Top = 8;
		const byte _VCenter = 16;
		const byte _Bottom = 32;

		#endregion

		#region · Static Members ·

		/// <summary>
		/// No resize or drag status
		/// </summary>
		public static readonly DragOrResizeStatus None = new DragOrResizeStatus { value = 0 };
		/// <summary>
		/// Identifies the top/left resize status
		/// </summary>
		public static readonly DragOrResizeStatus TopLeft = new DragOrResizeStatus { value = _TopLeft };
		/// <summary>
		/// Identifies the top/center resize status
		/// </summary>
		public static readonly DragOrResizeStatus TopCenter = new DragOrResizeStatus { value = _TopCenter };
		/// <summary>
		/// /// Identifies the top/right resize status
		/// </summary>
		public static readonly DragOrResizeStatus TopRight = new DragOrResizeStatus { value = _TopRight };
		/// <summary>
		/// /// Identifies the middle/left resize status
		/// </summary>
		public static readonly DragOrResizeStatus MiddleLeft = new DragOrResizeStatus { value = _MiddleLeft };
		/// <summary>
		/// Identifies the dragging status
		/// </summary>
		public static readonly DragOrResizeStatus Drag = new DragOrResizeStatus { value = _Drag };
		/// <summary>
		/// Identifies the middle/right resize status
		/// </summary>
		public static readonly DragOrResizeStatus MiddleRight = new DragOrResizeStatus { value = _MiddleRight };
		/// <summary>
		/// /// Identifies the bottom/left resize status
		/// </summary>
		public static readonly DragOrResizeStatus BottomLeft = new DragOrResizeStatus { value = _BottomLeft };
		/// <summary>
		/// Identifies the bottom/center resize status
		/// </summary>
		public static readonly DragOrResizeStatus BottomCenter = new DragOrResizeStatus { value = _BottomCenter };
		/// <summary>
		/// Identifies the bottom/right resize status
		/// </summary>
		public static readonly DragOrResizeStatus BottomRight = new DragOrResizeStatus { value = _BottomRight };

		#endregion

		#region · Operators ·

		/// <summary>
		/// Implements the operator ==.
		/// </summary>
		/// <param name="x">The x.</param>
		/// <param name="y">The y.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(DragOrResizeStatus x, DragOrResizeStatus y)
		{
			return x.Equals(y);
		}

		/// <summary>
		/// Implements the operator !=.
		/// </summary>
		/// <param name="x">The x.</param>
		/// <param name="y">The y.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(DragOrResizeStatus x, DragOrResizeStatus y)
		{
			return !x.Equals(y);
		}

		#endregion

		#region · Fields ·

		private byte value;

		#endregion

		#region · Properties ·

		/// <summary>
		/// Gets a value the resize status is on left.
		/// </summary>
		public bool IsOnLeft
		{
			get { return (value & _Left) == _Left; }
		}

		/// <summary>
		/// Gets a value the resize status is on horizontal middle.
		/// </summary>
		public bool IsOnHMiddle
		{
			get { return (value & _HMiddle) == _HMiddle; }
		}

		/// <summary>
		/// Gets a value the resize status is on right.
		/// </summary>
		public bool IsOnRight
		{
			get { return (value & _Right) == _Right; }
		}

		/// <summary>
		/// Gets a value the resize status is on top.
		/// </summary>
		public bool IsOnTop
		{
			get { return (value & _Top) == _Top; }
		}

		/// <summary>
		/// Gets a value the resize status is on vertical center.
		/// </summary>
		public bool IsOnVCenter
		{
			get { return (value & _VCenter) == _VCenter; }
		}

		/// <summary>
		/// Gets a value the resize status is on bottom.
		/// </summary>
		public bool IsOnBottom
		{
			get { return (value & _Bottom) == _Bottom; }
		}

		/// <summary>
		/// Gets a value the resize status is on top/left or bottom/right.
		/// </summary>
		public bool IsOnTopLeftOrBottomRight
		{
			get { return value == _TopLeft || value == _BottomRight; }
		}

		/// <summary>
		/// Gets a value the resize status is on top/right or bottom/center.
		/// </summary>
		public bool IsOnTopRightOrBottomLeft
		{
			get { return value == _TopRight || value == _BottomLeft; }
		}

		/// <summary>
		/// Gets a value the resize status is on top/center or bottom/center.
		/// </summary>
		public bool IsOnTopCenterOrBottomCenter
		{
			get { return value == _TopCenter || value == _BottomCenter; }
		}

		/// <summary>
		/// Gets a value the resize status is on middle/left or middle/right.
		/// </summary>
		public bool IsOnMiddleLeftOrMiddleRight
		{
			get { return value == _MiddleLeft || value == _MiddleRight; }
		}

		/// <summary>
		/// Gets a value the status is dragging
		/// </summary>
		public bool IsDragging
		{
			get { return value == _Drag; }
		}

		#endregion

		#region · Methods ·

		/// <summary>
		/// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
		/// <returns>
		/// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
		/// </returns>
		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}

			return ((DragOrResizeStatus)obj).value == value;
		}

		/// <summary>
		/// Returns a hash code for this instance.
		/// </summary>
		/// <returns>
		/// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
		/// </returns>
		public override int GetHashCode()
		{
			return value.GetHashCode();
		}

		#endregion
	}
}
