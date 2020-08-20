﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCMidterm_CoffeeShop
{   
    public class RegisterService
    {
        public double SubTotal { get; set; }
        public double GrandTotal { get; set; }

        public double SalesTax { get; set; }

        public double CalculateLineTotal(int quantity, double price)
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
            GrandTotal = Math.Round(SubTotal * 1.06, 2);
        }

        public void CalculateSalesTax()
        {
            SalesTax = Math.Round(GrandTotal - SubTotal, 2);           
        }

        public void PrintReceipt(List<Product> orderItems)
        {
            
        }
        public void PrintMenu(List<Product> productList)
        {
            Console.WriteLine("{0,-3} {1, -30} {2, -30} {3,-150} {4, -10}\n", "ID", "Name", "Category", "Description", "Price");
            foreach (var product in productList)
            {
                Console.WriteLine("{0,-3} {1, -30} {2, -30} {3,-150} {4, -10}", $"{product.ID}", $"{product.Name}", $"{product.Category}", $"{product.Description}", $"${product.Price}");
            }
        }
    }
}
