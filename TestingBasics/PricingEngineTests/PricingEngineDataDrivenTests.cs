using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TestingBasics;

namespace EngineTests
{
    [TestClass]
    public class PricingEngineDataDrivenTests
    {
        // https://docs.microsoft.com/en-us/dotnet/csharp/misc/cs0182
        // https://stackoverflow.com/questions/43787007/using-decimal-values-in-datarowattribute

        [TestMethod]
        [DataRow(false, 20, "1.00", "1.00")]        // BelowMinPrice
        [DataRow(false, 20, "1.01", "0.909")]       // MinPrice
        [DataRow(false, 10, "10.00", "10.00")]      // BelowMinQty
        [DataRow(false, 11, "10.00", "9.00")]       // MinQtyLower
        [DataRow(false, 20, "10.00", "9.00")]       // MinQtyUpper
        [DataRow(false, 21, "10.00", "8.00")]       // QtyGT20
        [DataRow(true, 10, "1.00", "1.00")]         // HolidayBelowMinPrice
        [DataRow(true, 10, "100.00", "100.00")]     // HolidayBelowMinTotal
        [DataRow(true, 10, "150.00", "135.00")]     // HolidayBelowMinQty
        [DataRow(true, 11, "150.00", "120.00")]     // HolidayMinQty
        public void CalculateUnitPrice(bool holiday, int quantity, string retailPriceStr, string expectedUnitPriceStr)
        {
            // arrange
            PricingEngine engine = new PricingEngine(holiday);
            decimal retailPrice = decimal.Parse(retailPriceStr);
            decimal expectedUnitPrice = decimal.Parse(expectedUnitPriceStr);

            // act
            decimal unitPrice = engine.CalculateUnitPrice(quantity, retailPrice);

            // assert
            Assert.AreEqual(expectedUnitPrice, unitPrice);

        }
    }
}
