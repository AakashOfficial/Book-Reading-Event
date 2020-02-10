﻿using Book_Reading_Event_BL;
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
        public ActionResult Index()
        {
            
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
        public ActionResult Edit(int eventid) {

            if (eventid == null) {
                return HttpNotFound();
            }

            return View();
        }

        // Function To Edit the Event
        public ActionResult UpdateEvent(Event ev) {

            return View();
        }

        
    }
}