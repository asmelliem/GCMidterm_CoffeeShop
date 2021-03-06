﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GCMidterm_CoffeeShop
{
    public class Cash
    {
        public double AmountGiven { set; get; }

        public double Change { set; get; }

        public Cash(double amountGiven)
        {
            AmountGiven = amountGiven;
        }

        public void GetChange(double grandTotal)
        {            
            Change = Math.Round(AmountGiven - grandTotal,2);
        }
    }
}
