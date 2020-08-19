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

        public void PrintReceipt(List<Product> orderItems)
        {
            
        }
        public void PrintMenu(List<Product> productList)
        {
            Console.WriteLine("#. Name, Category, Description, Price");
            foreach (var product in productList)
            {
                Console.WriteLine($"{product.ID}. {product.Name}, {product.Category}, {product.Description}, {product.Price}");
            }
        }


    }
}
