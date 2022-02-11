using CognizantQLESS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CognizantQLESS.Core.Interface
{
    public interface IFareCalculator
    {
        public float GetRate(bool isDiscountType, int bookingsToday, float rate);
        public float GetDiscount(bool isDiscountType, int bookingsToday);
    }
}
