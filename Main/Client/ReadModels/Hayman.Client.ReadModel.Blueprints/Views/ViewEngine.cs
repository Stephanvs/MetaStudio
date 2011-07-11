namespace Hayman.MetaStudio.Core.Views
{
	public class ViewEngine : IViewEngine<IView>
	{
		public IView View()
		{
			return new EmptyView();
		}
	}
}