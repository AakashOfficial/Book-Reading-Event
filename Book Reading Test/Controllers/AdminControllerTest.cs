using Book_Reading_UI.Areas.Admin.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using System.Web.Mvc;

namespace Book_Reading_Test.Controllers {

    [TestClass]
    public class AdminControllerTest {

        [TestMethod]
        public void AllUsers()
        {
            // Arrange
            AdminController controller = new AdminController();
            string viewName = "AllUsers";

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual(viewName, result.ViewName);
        }

    }
}