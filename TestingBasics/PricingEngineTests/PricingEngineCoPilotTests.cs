using Microsoft.VisualStudio.TestTools.UnitTesting;

public class PricingEngineTests
{
   private PricingEngine _engine;

   public PricingEngineTests()
   {
       _engine = new PricingEngine(false);
   }

   [TestMethod]
   public void CalculateUnitPrice_QuantityLessThan10NoDiscount()
   {
       decimal unitPrice = _engine.CalculateUnitPrice(9, 1.00m);
       Assert.AreEqual(1.00m, unitPrice);
   }

   [TestMethod]
   public void CalculateUnitPrice_QuantityGreaterThan10LessThan20TenPercentDiscount()
   {
       decimal unitPrice = _engine.CalculateUnitPrice(15, 1.00m);
       Assert.AreEqual(0.90m, unitPrice);
   }

   [TestMethod]
   public void CalculateUnitPrice_QuantityGreaterThan20TwentyPercentDiscount()
   {
       decimal unitPrice = _engine.CalculateUnitPrice(25, 1.00m);
       Assert.AreEqual(0.80m, unitPrice);
   }

   [TestMethod]
   public void CalculateUnitPrice_HolidayAndQuantityGreaterThan20TwentyPercentDiscountAndHolidayDiscount()
   {
       _engine = new PricingEngine(true);
       decimal unitPrice = _engine.CalculateUnitPrice(25, 1.00m);
       Assert.AreEqual(0.70m, unitPrice);
   }

   [TestMethod]
   public void CalculateUnitPrice_HolidayAndQuantityGreaterThan20TwentyPercentDiscountAndNoHolidayDiscount()
   {
       _engine = new PricingEngine(true);
       decimal unitPrice = _engine.CalculateUnitPrice(25, 100.00m);
       Assert.AreEqual(80.00m, unitPrice);
   }

   [TestMethod]
   public void CalculateUnitPrice_HolidayAndQuantityGreaterThan20TwentyPercentDiscountAndHolidayDiscountAndNoHolidayDiscount()
   {
       _engine = new PricingEngine(true);
       decimal unitPrice = _engine.CalculateUnitPrice(25, 1000.00m);
       Assert.AreEqual(720.00m, unitPrice);
   }

   [TestMethod]
   public void CalculateUnitPrice_HolidayAndQuantityGreaterThan20TwentyPercentDiscountAndHolidayDiscountAndNoHolidayDiscountAndNoHolidayDiscount()
   {
       _engine = new PricingEngine(true);
       decimal unitPrice = _engine.CalculateUnitPrice(25, 10000.00m);
       Assert.AreEqual(7200.00m, unitPrice);
   }

   [TestMethod]
   public void CalculateUnitPrice_HolidayAndQuantityGreaterThan20TwentyPercentDiscountAndHolidayDiscountAndNoHolidayDiscountAndNoHolidayDiscountAndNoHolidayDiscount()
   {
       _engine = new PricingEngine(true);
       decimal unitPrice = _engine.CalculateUnitPrice(25, 100000.00m);
       Assert.AreEqual(72000.00m, unitPrice);
   }

   [TestMethod]
   public void CalculateUnitPrice_HolidayAndQuantityGreaterThan20TwentyPercentDiscountAndHolidayDiscountAndNoHolidayDiscountAndNoHolidayDiscountAndNoHolidayDiscountAndNoHolidayDiscount()
   {
       _engine = new PricingEngine(true);
       decimal unitPrice = _engine.CalculateUnitPrice(25, 1000000.00m);
       Assert.AreEqual(720000.00m, unitPrice);
   }

   [TestMethod]
   public void CalculateUnitPrice_HolidayAndQuantityGreaterThan20TwentyPercentDiscountAndHolidayDiscountAndNoHolidayDiscountAndNoHolidayDiscountAndNoHolidayDiscountAndNoHolidayDiscountAndNoHolidayDiscount()
   {
       _engine = new PricingEngine(true);
       decimal unitPrice = _engine.CalculateUnitPrice(25, 10000000.00m);
       Assert.AreEqual(7200000.00m, unitPrice);
   }

   [TestMethod]
   public void CalculateUnitPrice_HolidayAndQuantityGreaterThan20TwentyPercentDiscountAndHolidayDiscountAndNoHolidayDiscountAndNoHolidayDiscountAndNoHolidayDiscountAndNoHolidayDiscountAndNoHolidayDiscountAndNoHolidayDiscount()
   {
       _engine = new PricingEngine(true);
       decimal unitPrice = _engine.CalculateUnitPrice(25, 100000000.00m);
       Assert.AreEqual(72000000.00m, unitPrice);
   }

   [TestMethod]
   public void CalculateUnitPrice_HolidayAndQuantityGreaterThan20TwentyPercentDiscountAndHolidayDiscountAndNoHolidayDiscountAndNoHolidayDiscountAndNoHolidayDiscountAndNoHolidayDiscountAndNoHolidayDiscountAndNoHolidayDiscountAndNoHolidayDiscount()
   {
       _engine = new PricingEngine(true);
       decimal unitPrice = _engine.CalculateUnitPrice(25, 1000000000.00m);
       Assert.AreEqual(720000000.00m, unitPrice);
   }

   [TestMethod]
   public void CalculateUnitPrice_HolidayAndQuantityGreaterThan20TwentyPercentDiscount()
   {
       _engine = new PricingEngine(true);
       decimal unitPrice = _engine.CalculateUnitPrice(25, 1.00m);
       Assert.AreEqual(0.80m, unitPrice);
   }
}