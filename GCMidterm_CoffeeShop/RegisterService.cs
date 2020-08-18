using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCMidterm_CoffeeShop
{   
    public class RegisterService
    {
        public double SubTotal { get; set; }
        public double GrandTotal { get; set; }

        public static double CalculateLineTotal(int quantity, double price)
        {
            return price * quantity;
        }

        public void CalcualateSubtotal(List<Product> orderItems)
        {
            foreach(var item in orderItems)
            {
                SubTotal += item.Price;
            }

            SubTotal = Math.Round(SubTotal, 2);
        }

        public void CalculateGrandTotal()
        {
            GrandTotal = Math.Round(SubTotal * 0.06, 2);
        }
    }
}
