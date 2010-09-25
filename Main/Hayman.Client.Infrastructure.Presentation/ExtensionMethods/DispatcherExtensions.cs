using System;
using System.Windows.Threading;

namespace Hayman.Client.Presentation.Windows.ExtensionMethods
{
/// <summary>
	/// Provides a set of commonly used Dispatcher extension methods
	/// </summary>
	public static class DispatcherExtensions
	{
		#region DispatcherObject Extension Methods

		/// <summary>
		/// Executes the specified <see cref="Action "/> at the <see cref="DispatcherPriority.ApplicationIdle"/> priority 
		/// on the thread on which the DispatcherObject is associated with. 
		/// </summary>
		/// <param name="dispatcherObject">The dispatcher object.</param>
		/// <param name="action">The action.</param>
		public static void InvokeAsynchronously(this DispatcherObject dispatcherObject, Action action)
		{
			dispatcherObject.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);
		}
		/// <summary>
		/// Executes the specified <see cref="Action "/> at the <see cref="DispatcherPriority.ApplicationIdle"/> priority 
		/// on the thread on which the DispatcherObject is associated with. 
		/// </summary>
		/// <param name="dispatcherObject">The dispatcher object.</param>
		/// <param name="action">The action.</param>
		public static void InvokeAsynchronouslyInBackground(this DispatcherObject dispatcherObject, Action action)
		{
			dispatcherObject.Dispatcher.BeginInvoke(DispatcherPriority.Background, action);
		}

		/// <summary>
		/// Executes the specified <see cref="Action "/> at the <see cref="DispatcherPriority.ApplicationIdle"/> priority 
		/// on the thread on which the DispatcherObject is associated with. 
		/// </summary>
		/// <param name="dispatcherObject">The dispatcher object.</param>
		/// <param name="action">The action.</param>
		public static void Invoke(this DispatcherObject dispatcherObject, Action action)
		{
			dispatcherObject.Dispatcher.Invoke(action);
		}

		#endregion
	}
}
