using Book_Reading_UI.Areas.Common.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Reading_Test.Controllers {

    [TestClass]
    class HomeControllerTest {

        [TestMethod]
        public void Index() {
            // Arrange
            HomeController controller = new HomeController();
            string viewName = "Index";

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual(viewName, result.ViewName);
        }
    }
}