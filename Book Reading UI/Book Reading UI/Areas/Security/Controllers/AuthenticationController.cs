using Book_Reading_Event_BL;
using Book_Reading_Event_DAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Reading_UI.Areas.Security.Controllers {

    // [AllowAnonymous]
    public class AuthenticationController : Controller {

        private UserOperation uo;

        public AuthenticationController(){
            uo = new UserOperation();
        }

        // GET: Security/Authentication
        public ActionResult Login() {

            return View();
        }

    }
}