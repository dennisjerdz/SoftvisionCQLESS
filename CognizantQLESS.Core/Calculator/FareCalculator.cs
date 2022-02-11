using CognizantQLESS.Core.Interface;
using CognizantQLESS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CognizantQLESS.Core.Calculator
{
    public class FareCalculator : IFareCalculator
    {
        public float GetRate(bool isDiscountType, int travelsToday, float rate)
        {
            float discount = GetDiscount(isDiscountType, travelsToday);

            float finalRate = rate - (rate * discount);
            return finalRate;
        }

        public float GetDiscount(bool isDiscountType, int travelsToday)
        {
            float discount = 0;
            if (isDiscountType)
            {
                discount += 0.2f;
            }

            if (travelsToday > 0 && travelsToday <= 4)
            {
                discount += (travelsToday * 0.03f);
            }

            return discount;
        }
    }
}
