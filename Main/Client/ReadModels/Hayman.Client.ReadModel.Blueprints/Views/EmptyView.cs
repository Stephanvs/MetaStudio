namespace Hayman.MetaStudio.Core.Views
{
	public sealed class EmptyView : IView
	{
		public EmptyView()
		{
			Name = "Empty";
		}

		public string Name { get; set; }
	}
}
