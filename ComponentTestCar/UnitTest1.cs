using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ClassDemoRestService.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestLibrary;

namespace ComponentTestCar
{
    [TestClass]
    public class UnitTest1
    {
        private CarsController controller = new CarsController();

        [TestMethod]
        public void TestifNotNull()
        {
            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void TestgetAll()
        {
            IEnumerable<Car> cars = controller.Get();
            Assert.IsNotNull(cars);
            Assert.AreEqual(5, cars.Count());
        }

        [TestMethod]
        public void TestgetOne()
        {
            Car car = controller.Get(12);
            Assert.AreEqual(car.Color, "Sort");
            
        }

        [TestMethod]
        public void testSearch()
        {

        }
    }
}
