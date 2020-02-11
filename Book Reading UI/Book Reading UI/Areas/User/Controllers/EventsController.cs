using Book_Reading_Event_BL;
using Book_Reading_Event_DAO;
using Book_Reading_UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Reading_UI.Areas.User.Controllers {

    public class EventsController : Controller {

        private bool result = false;

        private EventOperations evop;
        private CreatedFunction cf;

        public EventsController(){
            evop = new EventOperations();
            cf = new CreatedFunction();
        }

        // GET: User/Events
        public ActionResult Index() {
            var test = cf.CheckLoginUser();
            if (!test) {
                return Redirect("/Security/Authentication/Login");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Create(Event events){
            var test = cf.CheckLoginUser();
            if (!test) {
                return Redirect("/Security/Authentication/Login");
            }

            events.UserId = cf.LoggedUserId();

            result = evop.addEvents(events);

            return RedirectToAction("Index");
        }

        // Function To View Edit Form of Event
        public ActionResult Edit(int id) {

            if (id == 0) {
                return HttpNotFound();
            }
            var output = evop.getEventDetails(id);
            return View(output);
        }

        // Function To Edit the Event
        public ActionResult UpdateEvent(Event ev) {

            return View();
        }

        // Function To Invite Registered User
        public ActionResult InviteUser(int id) {
            string userName = Request.Form["txtUserName"];
            string password = Request.Form["txtPassword"];

            return View();
        }

        // Function To Event Created By User
        public ActionResult ViewMyEvent() {
            var test = cf.CheckLoginUser();
            if (!test) {
                return Redirect("/Security/Authentication/Login");
            }

            var output = evop.getCreatedEvent(cf.LoggedUserId());

            return View(output);
        }

        public ActionResult PublicEvents() {
            var output = evop.getPublicEvent();
            return View(output);
        }

        public ActionResult ViewPublicDetail(int id) {

            var output = evop.getEventDetails(id);
            return View(output);
        }

        // public ActionResult
    }
}