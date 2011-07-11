namespace Hayman.MetaStudio.Core.Views
{
	public interface IViewEngine<out TView> 
		where TView : IView
	{
		TView View();
	}
}
