using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace GCMidterm_CoffeeShop
{
    public class Program
    {
        static void Main(string[] args)
        {
            FileService fileService = new FileService();
            var productList = fileService.GetProductList();
            var orderList = new List<Product>();
            RegisterService registerService = new RegisterService();

            Console.WriteLine("Welcome to Grand Circus Coffee Shop!!");
            Console.WriteLine("Menu Items");                       
            
            do
            {
                registerService.PrintMenu(productList);
                Console.WriteLine("Please choose the number of the item you want");
                var productChoice = int.Parse(Console.ReadLine());
                var product = productList.Where(x => x.ID == productChoice).FirstOrDefault();

                Console.WriteLine("How many would you like to order: ");
                var productQuantity = int.Parse(Console.ReadLine());
                var lineTotal = registerService.CalculateLineTotal(productQuantity, product.Price);

                Console.WriteLine($"Here is your line total: ${lineTotal}");

                for (int i = 1; i <= productQuantity; i++)
                {
                    orderList.Add(product);
                }

                Console.WriteLine("Is your order complete or would you like to add more items?"); 

            } while (UserContinue());

            registerService.CalcualateSubtotal(orderList);
            registerService.CalculateGrandTotal();
            registerService.CalculateSalesTax();

            Console.WriteLine($"Subtotal: ${registerService.SubTotal}");            
            Console.WriteLine($"Sales Tax: ${registerService.SalesTax}");            
            Console.WriteLine($"Grand Total: ${registerService.GrandTotal}");

            Console.WriteLine("How will you be paying? 1. Cash, 2. Credit, or 3. Check");
            var paymentChoice = int.Parse(Console.ReadLine());
            if(paymentChoice == 1)
            {
                Console.WriteLine("Enter total cash amount:");
                double amountGiven = double.Parse(Console.ReadLine());
                Cash cash = new Cash(amountGiven);
                cash.GetChange(registerService.GrandTotal);
                Console.WriteLine($"Your change is:{cash.Change}");
                Console.WriteLine("Here is your receipt");
                registerService.PrintCashReceipt(orderList,cash);
            }
            else if(paymentChoice == 2)
            {
                Console.WriteLine("Enter your card number:");
                int cardNum = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the expiration date(MM/YYYY):");
                string expDate = Console.ReadLine();
                Console.WriteLine("Enter the CVV number:");
                int cvv = int.Parse(Console.ReadLine());
                Card card = new Card(cardNum, expDate, cvv);
                Console.WriteLine("Here is your receipt");
                registerService.PrintCardReceipt(orderList, card);
            }
            else
            {
                Console.WriteLine("Enter check number:");
                int checkNumber = int.Parse(Console.ReadLine());
                Check check = new Check(checkNumber);
            }

            //return menu for a new order.
        }

        public static bool UserContinue()
        {
            while(true)
            {
                Console.WriteLine("Press Y to add more items or N for total ");
                var input = Console.ReadLine().ToUpper();
                if (input == "Y")
                {
                    return true;
                }
                else if (input == "N")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("You did not enter  'Y' or 'N' ");                        
                }
            }
        }
    }
}
