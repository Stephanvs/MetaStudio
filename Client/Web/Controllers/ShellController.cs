using System.Web.Mvc;

namespace Hayman.Client.Web.Controllers
{
	public class ShellController : Controller
	{
		public ActionResult Home()
		{
			return View();
		}

		public ActionResult Dashboard()
		{
			if (!Request.IsAjaxRequest()) return new EmptyResult();

			return PartialView("~/Views/Dashboard/Dashboard.cshtml");
		}

		public ActionResult MetaModelling()
		{
			if (!Request.IsAjaxRequest()) return new EmptyResult();

			return PartialView("~/Views/MetaModelling/MetaModelling.cshtml");
		}

		public ActionResult Debug()
		{
			if (!Request.IsAjaxRequest()) return new EmptyResult();

			return PartialView("~/Views/Shared/Partial/temp.cshtml");
		}
	}
}