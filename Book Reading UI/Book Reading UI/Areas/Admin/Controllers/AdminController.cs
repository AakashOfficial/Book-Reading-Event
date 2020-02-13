using Book_Reading_Event_BL;
using Book_Reading_Event_DAO;
using Book_Reading_UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Reading_UI.Areas.Admin.Controllers {

    public class AdminController : Controller {

        private UserOperation userOperation;
        private EventOperations eventOperations;
        private CreatedFunction cf;

        public AdminController() {
            userOperation = new UserOperation();
            eventOperations = new EventOperations();
            cf = new CreatedFunction();
        }

        public ActionResult AllUsers() {
            var test = cf.CheckLoginUser();
            if (!test) {
                return Redirect("/Security/Authentication/Login");
            }
            string userRole = cf.GetUserRole(cf.LoggedUserId());

            if (userRole == "A") {
                var output = userOperation.getUserData();
                return View(output);
            } else {
                return Redirect("/Security/Authentication/Home");
            }
        }

        public ActionResult AllEvents() {
            var test = cf.CheckLoginUser();
            if (!test) {
                return Redirect("/Security/Authentication/Login");
            }

            string userRole = cf.GetUserRole(cf.LoggedUserId());

            if (userRole == "A") {
                var output = eventOperations.getEvents();
                return View(output);
            } else {
                return Redirect("/Security/Authentication/Home");
            }
        }
    }
}