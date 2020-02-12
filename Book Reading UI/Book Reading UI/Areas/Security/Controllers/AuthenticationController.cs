using Book_Reading_Event_BL;
using Book_Reading_Event_DAO;
using Book_Reading_UI.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Reading_UI.Areas.Security.Controllers {

    public class AuthenticationController : Controller {

        private UserOperation uo;
        private CreatedFunction cf;

        public AuthenticationController(){
            uo = new UserOperation();
            cf = new CreatedFunction();
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
            Session["userId"] = 0;
            return View();
        }

        
        public ActionResult Home() {
            var test = cf.CheckLoginUser();
            if (!test) {
                return Redirect("/Security/Authentication/Login");
            }

            return View();
        }

        public ActionResult Logout() {

            Session["userId"] = 0;
            return Redirect("/Security/Authentication/Login");
        }
    }
}