using Book_Reading_UI.Areas.User.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Reading_Test.Controllers {

    [TestClass]
    class EventsControllerTest {

        [TestMethod]
        public void Index() {

            // Arrange
            EventsController controller = new EventsController();
            string viewName = "Index";

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual(viewName, result.ViewName);
        }
    }
}