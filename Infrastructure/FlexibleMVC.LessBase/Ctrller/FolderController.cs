using System.Web.Mvc;
using FlexibleMVC.LessBase.Context;

namespace FlexibleMVC.LessBase.Ctrller
{
    public class FolderController : LessBaseController
    {

        public FolderController(LessFlexibleContext flexibleContext) : base(flexibleContext)
        {
        }

        //
        // GET: /Folder/

        public ActionResult Index(string dynamicRoute)
        {
            return View(dynamicRoute);
        }

    }
}
