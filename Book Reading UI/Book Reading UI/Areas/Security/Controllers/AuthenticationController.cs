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
            // System.Diagnostics.Debug.WriteLine("Aa Rhi");
            return View();
        }

        public ActionResult Validate() {

            string useremail = Request.Form["UserEmail"];
            string password = Request.Form["UserPassword"];

            System.Diagnostics.Debug.WriteLine(useremail);
            System.Diagnostics.Debug.WriteLine(password);

            if (useremail != null && useremail != "" && password != null && password != "") {

                int userId = uo.checkUser(useremail, password);
                if (userId != 0) {
                    Session["userId"] = userId;
                    System.Diagnostics.Debug.WriteLine((int)Session["userId"]);
                    return RedirectToAction("Home");
                } else {
                    return RedirectToAction("Login");
                }                
            } else {
                return RedirectToAction("Login");
            }            
        }

        public ActionResult Register() {

            return View();
        }

        public ActionResult Registeration(Book_Reading_Event_DAO.User usr) {

            bool result = uo.addUser(usr);
            
            return RedirectToAction("Login");
        }

        public ActionResult Home() {

            return View();
        }

        public ActionResult Logout() {

            Session["userId"] = 0;
            return RedirectToAction("Login");
        }
    }
}