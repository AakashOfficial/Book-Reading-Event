using System;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Reading_UI.Controllers {

    public class CreatedFunction :Controller {

        public bool CheckLoginUser() {
            int userId = (int)System.Web.HttpContext.Current.Session["userId"];
            
            if (userId > 0) {
                return true;
            } else {
                return false;
            }
        }

        public void CheckLogged() {
            bool loggedUserId = CheckLoginUser();
            // System.Diagnostics.Debug.WriteLine(loggedUserId + " Aa Rhi");
            if (loggedUserId) {
                // System.Diagnostics.Debug.WriteLine(loggedUserId + " Aa Rhi");
            } else {
                // System.Diagnostics.Debug.WriteLine(loggedUserId + " Redirect Ho rha");
                redirectLogin();
            }
        }

    }
}