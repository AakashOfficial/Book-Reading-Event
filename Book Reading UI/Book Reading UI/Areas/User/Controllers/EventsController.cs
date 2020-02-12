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
            var test = cf.CheckLoginUser();
            if (!test) {
                return Redirect("/Security/Authentication/Login");
            }

            if (id == 0) {
                return HttpNotFound();
            }
            var output = evop.getEventDetails(id);
            return View(output);
        }

        // Function To Edit the Event
        public ActionResult UpdateEvent(Event ev) {
            var test = cf.CheckLoginUser();
            if (!test) {
                return Redirect("/Security/Authentication/Login");
            }

            evop.editEvents(ev, cf.LoggedUserId());

            return Redirect("/User/Events/Index");
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

        // Function To View Public Event
        public ActionResult PublicEvents() {
            var output = evop.getPublicEvent();
            return View(output);
        }

        // Function To View Event Detail
        public ActionResult ViewPublicDetail(int id) {
            var output = evop.getEventDetails(id);
            return View(output);
        }

        // Function To View Upcoming Event
        public ActionResult UpcomingEvents() {

            return View();
        }

        // Function To View Past Event
        public ActionResult PastEvents() {

            return View();
        }

        // Function to Delete an Event
        public ActionResult Delete(int id) {
            var test = cf.CheckLoginUser();
            if (!test) {
                return Redirect("/Security/Authentication/Login");
            }

            var output = evop.getEventDetails(id);
            return View();
        }
    }
}