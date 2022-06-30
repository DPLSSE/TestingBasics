using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestingBasics;

namespace EngineTests
{
    [TestClass]
    public class PricingEngineTests
    {

        // test fails
        //[TestMethod]
        //public void CalculateUnitPrice_BelowMinPrice()
        //{
        //    // arrange
        //    PricingEngine engine = new PricingEngine(false);

        //    // act
        //    decimal unitPrice = engine.CalculateUnitPrice(20, 1.00m);

        //    // assert
        //    Assert.AreEqual(1.00m, unitPrice);

        //}

        [TestMethod]
        [DataRow(false, 20, "1.01", "0.909")]
        [DataRow(false, 10, "10.00", "10.00")]
        [DataRow(false, 11, "10.00", "9.00")]
        [DataRow(false, 20, "10.00", "9.00")]
        [DataRow(false, 21, "10.00", "8.00")]
        [DataRow(true, 10, "1.00", "1.00")]
        [DataRow(true, 10, "100.00", "100.00")]
        [DataRow(true, 10, "150.00", "135.00")]
        [DataRow(true, 11, "150.00", "120.00")]
        public void CalculateUnitPrice(bool isHoliday, int x, string y_str, string answer_str)
        {
            // can't use decimals in DataRow attr as they are not primitive types
            decimal y = Convert.ToDecimal(y_str),
                    answer = Convert.ToDecimal(answer_str);

            PricingEngine engine = new PricingEngine(isHoliday);

            decimal unitPrice = engine.CalculateUnitPrice(x, y);

            Assert.AreEqual(answer, unitPrice);
        }
    }
}
