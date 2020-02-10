using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Reading_UI.Areas.Common.Controllers
{
    public class HomeController : Controller
    {
        // GET: Common/Home
        public ActionResult Index() {
            Session["userId"] = 0;
            System.Diagnostics.Debug.WriteLine((int)Session["userId"]);
            return View();
        }
    }
}