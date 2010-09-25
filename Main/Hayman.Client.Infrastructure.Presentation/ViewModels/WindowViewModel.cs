using System;

namespace Hayman.Client.Presentation.Windows.ViewModels
{
	public class WindowViewModel : ClosableViewModel
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowViewModel"></see> class.
        /// </summary>
        /// <param name="displayName"></param>
        protected WindowViewModel(string displayName)
            : base(displayName)
        {
            
        }

		public string Title 
		{
			get { return "Test"; }
		}
	}
}
