using System.Web.Mvc;

namespace FlexibleMVC.LessBase.Ctrller
{
    public class FolderController : LessBaseController
    {
        //
        // GET: /Folder/

        public ActionResult Index(string dynamicRoute)
        {
            return View(dynamicRoute);
        }

    }
}
