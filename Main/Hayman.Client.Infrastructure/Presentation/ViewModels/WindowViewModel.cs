using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hayman.Client.Infrastructure.Presentation.ViewModels
{
	public class WindowViewModel : ClosableViewModel
	{
		public string Title 
		{
			get { return "Test"; }
		}
	}
}
