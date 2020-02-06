using Book_Reading_Event_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Reading_UI.Areas.User.Controllers
{
    public class EventsController : Controller
    {
        // GET: User/Events
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Event events){

            return View();
        }
    }
}