using System;
using System.Collections.Generic;
using System.Globalization;
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
            return Math.Round(price * quantity, 2);
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

        public void PrintCashReceipt(List<Product> orderItems, Cash cash)
        {
            foreach (var item in orderItems)
            {
                Console.WriteLine("{0,-30} {1,5}",item.Name,$"${item.Price}");
            }
            Console.WriteLine("{0,-30} {1,5}", "Subtotal:", SubTotal.ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("{0,-30} {1,5}", "Sales Tax:", SalesTax.ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("{0,-30} {1,5}", "Grand Total:", GrandTotal.ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("{0,-30} {1,5}", "Amount Tendered:", cash.AmountGiven.ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("{0,-30} {1,5}", "Change:", cash.Change.ToString("C", CultureInfo.CurrentCulture));
        }

        public void PrintCardReceipt(List<Product> orderItems, Card card)
        {
            foreach (var item in orderItems)
            {
                Console.WriteLine("{0,-30} {1,5}", item.Name, $"${item.Price}");
            }
            Console.WriteLine("{0,-30} {1,5}", "Subtotal:", SubTotal.ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("{0,-30} {1,5}", "Sales Tax:", SalesTax.ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("{0,-30} {1,5}", "Grand Total:", GrandTotal.ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("{0,-30} {1,5}", "Card Payment - Tender Amount:", GrandTotal.ToString("C", CultureInfo.CurrentCulture));
            Console.Write("Card Number: ");
            var cardNum = card.CardNum.ToCharArray();

            for (int i = 0; i <cardNum.Length; i++)
            {
                
                if(i < cardNum.Length - 4)
                {
                    Console.Write("x");
                }
                else
                {
                    Console.Write(cardNum[i]);
                }
            }
            
        }

        public void PrintCheckReceipt(List<Product> orderItems, Check check)
        {
            foreach (var item in orderItems)
            {
                Console.WriteLine("{0,-30} {1,5}", item.Name, $"${item.Price}");
            }
            Console.WriteLine("{0,-30} {1,5}", "Subtotal:", SubTotal.ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("{0,-30} {1,5}", "Sales Tax:", SalesTax.ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("{0,-30} {1,5}", "Grand Total:", GrandTotal.ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("{0,-30} {1,5}", "Check Payment - Tender Amount:", GrandTotal.ToString("C", CultureInfo.CurrentCulture));
            Console.Write("Account Number: ");
            var checkNum = check.CheckNumber.ToCharArray();

            for (int i = 0; i < checkNum.Length; i++)
            {

                if (i < checkNum.Length - 4)
                {
                    Console.Write("x");
                }
                else
                {
                    Console.Write(checkNum[i]);
                }
            }
        }

        public void PrintMenu(List<Product> productList)
        {
            Console.WriteLine("{0,-3} {1, -30} {2, -12} {3,-168} {4, -10}\n", "ID", "Name", "Category", "Description", "Price");
            foreach (var product in productList)
            {
                Console.WriteLine("{0,-3} {1, -30} {2, -12} {3,-168} {4, -10}", $"{product.ID}", $"{product.Name}", $"{product.Category}", $"{product.Description}", $"{product.Price.ToString("C",CultureInfo.CurrentCulture)}");
            }
        }

        public void PrintOrderTotals( List<Product> orderList)
        {
            CalcualateSubtotal(orderList);
            CalculateGrandTotal();
            CalculateSalesTax();
            Console.WriteLine("\n\nTotal");
            Console.WriteLine("{0,-30} {1,5}", "Subtotal:", SubTotal.ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("{0,-30} {1,5}", "Sales Tax:", SalesTax.ToString("C", CultureInfo.CurrentCulture)); ;
            Console.WriteLine("{0,-30} {1,5}", "Grand Total:", GrandTotal.ToString("C", CultureInfo.CurrentCulture));
        }
    }
}
