using Microsoft.VisualStudio.TestTools.UnitTesting;
using REST_ObligatoriskOpgave.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REST_ObligatoriskOpgave.Models;

namespace REST_ObligatoriskOpgave.Controllers.Tests
{
    [TestClass()]
    public class CarsControllerTests
    {
        private Car car1;
        private Car car2;
        private Car car3;
        [TestInitialize]
        public void init()
        {
            car1 = new Car();
            car1.Model = "Volvo";
            car1.Price = 100000;
            car1.LicensePlate = "AY456";
            car2 = new Car();
            car2.Model = "Fiat";
            car2.Price = 89000;
            car2.LicensePlate = "BN890";
            car3 = new Car();
            car3.Model = "Skoda";
            car3.Price = 120000;
            car3.LicensePlate = "QR678";

        }


        [TestMethod()]
        public void GetListByMaxPriceTest()
        {
            
        }
        
    }
}