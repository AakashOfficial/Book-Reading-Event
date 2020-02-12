using Book_Reading_Event_BL;
using Book_Reading_Event_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Reading_UI.Areas.Admin.Controllers {

    public class AdminController : Controller {

        private UserOperation userOperation;
        private EventOperations eventOperations;

        public AdminController() {
            userOperation = new UserOperation();
            eventOperations = new EventOperations();
        }

        // GET: Admin/Admin
        public ActionResult Index() {
            return View();
        }

        public ActionResult AllUsers() {
            var output = userOperation.getUserData();
            return View(output);
        }

        public ActionResult AllEvents() {
            var output = eventOperations.getEvents();
            return View();
        }
    }
}