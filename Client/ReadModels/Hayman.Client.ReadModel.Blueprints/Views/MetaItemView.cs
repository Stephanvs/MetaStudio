namespace Hayman.MetaStudio.Core.Views
{
	using System;
	using System.Collections.Generic;
	using Hayman.MetaStudio.Core.Domain;

	public class ViewResult : IView
	{
		public ViewResult()
		{
			Objects = new List<MetaItem>();
		}

		public List<MetaItem> Objects { get; set; }

		public string Name { get; set; }
	}
}
