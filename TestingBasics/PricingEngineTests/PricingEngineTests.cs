using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestingBasics;

namespace EngineTests
{
    [TestClass]
    public class PricingEngineTests
    {
        [TestMethod]
        public void CalculateUnitPrice_BelowMinPrice()
        {
            // arrange
            PricingEngine engine = new PricingEngine(false);

            // act
            decimal unitPrice = engine.CalculateUnitPrice(20, 1.00m);

            // assert
            Assert.AreEqual(1.00m, unitPrice);

        }

        [TestMethod]
        public void CalculateUnitPrice_MinPrice()
        {
            // arrange
            PricingEngine engine = new PricingEngine(false);

            // act
            decimal unitPrice = engine.CalculateUnitPrice(20, 1.01m);

            // assert
            Assert.AreEqual(0.909m, unitPrice);

        }

        [TestMethod]
        public void CalculateUnitPrice_BelowMinQty()
        {
            // arrange
            PricingEngine engine = new PricingEngine(false);

            // act
            decimal unitPrice = engine.CalculateUnitPrice(10, 10.00m);

            // assert
            Assert.AreEqual(10.00m, unitPrice);
        }

        [TestMethod]
        public void CalculateUnitPrice_MinQtyLower()
        {
            // arrange
            PricingEngine engine = new PricingEngine(false);

            // act
            decimal unitPrice = engine.CalculateUnitPrice(11, 10.00m);

            // assert
            Assert.AreEqual(9.00m, unitPrice);
        }

        [TestMethod]
        public void CalculateUnitPrice_MinQtyUpper()
        {
            // arrange
            PricingEngine engine = new PricingEngine(false);

            // act
            decimal unitPrice = engine.CalculateUnitPrice(20, 10.00m);

            // assert
            Assert.AreEqual(9.00m, unitPrice);
        }

        [TestMethod]
        public void CalculateUnitPrice_QtyGT20()
        {
            // arrange
            PricingEngine engine = new PricingEngine(false);

            // act
            decimal unitPrice = engine.CalculateUnitPrice(21, 10.00m);

            // assert
            Assert.AreEqual(8.00m, unitPrice);
        }

        [TestMethod]
        public void CalculateUnitPrice_HolidayBelowMinPrice()
        {
            // arrange
            PricingEngine engine = new PricingEngine(true);

            // act
            decimal unitPrice = engine.CalculateUnitPrice(10, 1.00m);

            // assert
            Assert.AreEqual(1.00m, unitPrice);
        }

        [TestMethod]
        public void CalculateUnitPrice_HolidayBelowMinTotal()
        {
            // arrange
            PricingEngine engine = new PricingEngine(true);

            // act
            decimal unitPrice = engine.CalculateUnitPrice(10, 100.00m);

            // assert
            Assert.AreEqual(100.00m, unitPrice);
        }

        [TestMethod]
        public void CalculateUnitPrice_HolidayBelowMinQty()
        {
            // Test the discount for holiday and quantity = 10 and total
            // discounted amount is above the holiday threshold
            // arrange
            PricingEngine engine = new PricingEngine(true);

            // act
            decimal unitPrice = engine.CalculateUnitPrice(10, 150.00m);

            // assert
            Assert.AreEqual(135.00m, unitPrice);
        }

        [TestMethod]
        public void CalculateUnitPrice_HolidayMinQty()
        {
            // Test the discount for holiday and quantity = 10 and total
            // discounted amount is above the holiday threshold
            // arrange
            PricingEngine engine = new PricingEngine(true);

            // act
            decimal unitPrice = engine.CalculateUnitPrice(11, 150.00m);

            // assert
            Assert.AreEqual(120.00m, unitPrice);
        }
    }
}
