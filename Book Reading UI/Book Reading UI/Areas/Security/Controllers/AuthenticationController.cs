using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Reading_UI.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {
        // GET: Security/Authentication
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register() {

            return View();
        }
    }
}