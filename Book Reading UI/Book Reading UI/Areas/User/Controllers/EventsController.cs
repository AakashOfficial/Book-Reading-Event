using Book_Reading_Event_BL;
using Book_Reading_Event_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Reading_UI.Areas.User.Controllers {

    public class EventsController : Controller {

        private bool result = false;

        private EventOperations evop;

        public EventsController(){
            evop = new EventOperations();
        }

        // GET: User/Events
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Event events){

            result = evop.addEvents(events);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int eventid) {

            if (eventid == null)
            {
                return HttpNotFound();
            }

            return View();
        }
    }
}