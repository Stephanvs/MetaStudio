using System;

namespace Hayman.Client.Infrastructure.Core
{
	/// <summary>
	/// Allows an object to provide information about whether it is active or not.
	/// </summary>
	public interface IActiveAware
	{
		/// <summary>
		/// Gets or sets a value indicating whether the element is active.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is active; otherwise, <c>false</c>.
		/// </value>
		bool IsActive { get; }

		/// <summary>
		/// Activates the element
		/// </summary>
		void Activate();

		/// <summary>
		/// Deactivates the element
		/// </summary>
		void Deactivate();
	}
}
// todo: see possibility to merge with IActiveAware of Prism framework