using System;
using System.Collections.Generic;
using System.Text;

namespace GCMidterm_CoffeeShop
{
    public class Cash
    {
        public double AmountGiven { set; get; }

        public Cash(double amountGiven)
        {
            AmountGiven = amountGiven;
        }

        public double GetChange(double grandTotal)
        {
            return Math.Round(AmountGiven - grandTotal,2);
        }
    }
}
