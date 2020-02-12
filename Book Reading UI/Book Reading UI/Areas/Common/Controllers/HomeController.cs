using Book_Reading_Event_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Reading_UI.Areas.Common.Controllers {

    public class HomeController : Controller {

        private EventOperations eventOperations;

        public HomeController() {
            eventOperations = new EventOperations();
        }

        // GET: Common/Home
        public ActionResult Index() {
            Session["userId"] = 0;
            var output = eventOperations.getPublicEvent();

            return View(output);
        }
    }
}