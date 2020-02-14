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
        private InvitationOperations invitationOperations;
        private UserOperation userOperation;

        public EventsController(){
            evop = new EventOperations();
            cf = new CreatedFunction();
            invitationOperations = new InvitationOperations();
            userOperation = new UserOperation();
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

        // Function TO View Invitation Form
        public ActionResult Invite(int id) {
            var test = cf.CheckLoginUser();
            if (!test) {
                return Redirect("/Security/Authentication/Login");
            }
            var output = evop.getEventDetails(id);
            ViewBag.eventId = id;
            ViewBag.userlist = userOperation.UserIds(cf.LoggedUserId());
            return View(output);
        }

        // Function To Invite Registered User
        public ActionResult InviteUser() {
            string userId = Request.Form["userId"];
            string eventId = Request.Form["eventId"];
            char[] spearator = { ',', ' ' };
            string[] userIds = userId.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
            System.Diagnostics.Debug.WriteLine(userId.Length);
            System.Diagnostics.Debug.WriteLine(userId);

            invitationOperations.inviteUser(Int32.Parse(eventId), Array.ConvertAll(userIds, int.Parse));
            return Redirect("/User/Events/ViewMyEvent");
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
            var output = evop.getPublicEvent();
            return View(output);
        }

        // Function To View Past Event
        public ActionResult PastEvents() {
            var output = evop.getPublicEvent();
            return View(output);
        }

        // Function to Show Delete Form of an Event
        public ActionResult Delete(int id) {
            var test = cf.CheckLoginUser();
            if (!test) {
                return Redirect("/Security/Authentication/Login");
            }
            
            var output = evop.getEventDetails(id);
            ViewBag.eventid = id;
            return View();
        }

        // Function To Delete An Event
        public ActionResult DeleteEvent(int id) {
            bool result = evop.deleteEvent(id);
            return Redirect("/User/Events/ViewMyEvent");            
        }

        public ActionResult Invitations() {
            var test = cf.CheckLoginUser();
            if (!test) {
                return Redirect("/Security/Authentication/Login");
            }
            // System.Diagnostics.Debug.WriteLine(cf.LoggedUserId());
            var userInvitations = invitationOperations.getInvitation(cf.LoggedUserId());
            List<Event> getEvent = new List<Event>();
            foreach (var output in userInvitations) {
                // System.Diagnostics.Debug.WriteLine(output.EventId);
                getEvent.Add(evop.getEventDetails(output.EventId));
            }
            return View(getEvent);
        }
    }
}