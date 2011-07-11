namespace Hayman.MetaStudio.Core.Views
{
	using System;

	public class MetaItemViewEngine : IViewEngine<ViewResult>
	{
		private readonly IView _view;

		public MetaItemViewEngine(IView view)
		{
			_view = view;
		}

		public ViewResult View()
		{
			throw new NotImplementedException();
			//var x = from mi in ((Model)_view).MetaItems
			//        where 

			//return new ViewResult() { 
			//    Name = _view.Name,
			//    Objects = x
			//};
		}
	}
}
