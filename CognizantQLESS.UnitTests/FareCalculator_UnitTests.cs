using CognizantQLESS.Core.Calculator;
using CognizantQLESS.Core.Models;
using CognizantQLESS.Core.Models.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CognizantQLESS.UnitTests
{
    [TestClass]
    public class FareCalculator_UnitTests
    {
        public FareCalculator fareCalculator = new FareCalculator();

        [TestMethod]
        public void GetDiscount_DiscountedBookingsToday0_AreEqual()
        {
            bool isDiscountType = true;
            int bookingsToday = 0;

            float discount = fareCalculator.GetDiscount(isDiscountType, bookingsToday);
            Assert.AreEqual(discount, 0.2f);
        }

        [TestMethod]
        public void GetDiscount_DiscountedBookingsToday4_AreEqual()
        {
            bool isDiscountType = true;
            int bookingsToday = 4;

            float discount = fareCalculator.GetDiscount(isDiscountType, bookingsToday);
            Assert.AreEqual(discount, 0.32f);
        }

        [TestMethod]
        public void GetDiscount_DiscountedBookingsToday5_AreEqual()
        {
            bool isDiscountType = true;
            int bookingsToday = 5;

            float discount = fareCalculator.GetDiscount(isDiscountType, bookingsToday);
            Assert.AreEqual(discount, 0.2f);
        }

        [TestMethod]
        public void GetDiscount_RegularBookingsToday0_AreEqual()
        {
            bool isDiscountType = false;
            int bookingsToday = 0;

            float discount = fareCalculator.GetDiscount(isDiscountType, bookingsToday);
            Assert.AreEqual(discount, 0f);
        }

        [TestMethod]
        public void GetDiscount_RegularBookingsToday4_AreEqual()
        {
            bool isDiscountType = false;
            int bookingsToday = 4;

            float discount = fareCalculator.GetDiscount(isDiscountType, bookingsToday);
            Assert.AreEqual(discount, 0.12f);
        }

        [TestMethod]
        public void GetDiscount_RegularBookingsToday5_AreEqual()
        {
            bool isDiscountType = false;
            int bookingsToday = 5;

            float discount = fareCalculator.GetDiscount(isDiscountType, bookingsToday);
            Assert.AreEqual(discount, 0f);
        }
    }


}
