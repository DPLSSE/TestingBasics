using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestingBasics;

namespace EngineTests
{
    [TestClass]
    public class PricingEngineTests
    {
        [TestMethod]
        public void CalculateUnitPrice_Qty10()
        {
            // Test the discount for quantity = 10
            // arrange
            PricingEngine engine = new PricingEngine(false);

            // act
            decimal unitPrice = engine.CalculateUnitPrice(10, 25.00m);

            // assert
            Assert.AreEqual(22.50m, unitPrice);
        }

        [TestMethod]
        public void CalculateUnitPrice_Qty20()
        {
            // Test the discount for quantity = 20
            // arrange
            PricingEngine engine = new PricingEngine(false);

            // act
            decimal unitPrice = engine.CalculateUnitPrice(20, 25.00m);

            // assert
            Assert.AreEqual(20.00m, unitPrice);
        }

        [TestMethod]
        public void CalculateUnitPrice_HolidayNoDiscount()
        {
            // Test the discount for holiday and quantity = 10 but total
            // discounted amount is below the holiday threshold
            // arrange
            PricingEngine engine = new PricingEngine(true);

            // act
            decimal unitPrice = engine.CalculateUnitPrice(10, 125.00m);

            // assert
            Assert.AreEqual(100.00m, unitPrice);
        }

        [TestMethod]
        public void CalculateUnitPrice_HolidayDiscount()
        {
            // Test the discount for holiday and quantity = 10 and total
            // discounted amount is above the holiday threshold
            // arrange
            PricingEngine engine = new PricingEngine(true);

            // act
            decimal unitPrice = engine.CalculateUnitPrice(10, 150.00m);

            // assert
            Assert.AreEqual(120.00m, unitPrice);
        }

        [TestMethod]
        public void CalculateUnitPrice_NoDiscount()
        {
            // Test the discount for quantity = 10
            // arrange
            PricingEngine engine = new PricingEngine(false);

            // act
            decimal unitPrice = engine.CalculateUnitPrice(10, 1.00m);

            // assert
            Assert.AreEqual(1.00m, unitPrice);

        }
    }
}
