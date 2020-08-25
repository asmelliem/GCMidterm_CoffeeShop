using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;

namespace GCMidterm_CoffeeShop
{
    public class Program
    {
        static void Main(string[] args)
        {
            FileService fileService = new FileService();
            Validator validator = new Validator();
            var productList = fileService.GetProductList();

            int CASH = 1;
            int CARD = 2;
            //int CHECK = 3;

            do
            {
                var orderList = new List<Product>();
                RegisterService registerService = new RegisterService();
                Console.WriteLine("Welcome to Grand Circus Coffee Shop!!");
                Console.WriteLine("Menu");
                bool proceed = false;

                do
                {
                    Console.WriteLine("");
                    registerService.PrintMenu(productList);
                    Console.WriteLine("\n\nPlease choose the number of the item you want");
                    var productChoiceInput = Console.ReadLine();

                    //Checks to make sure you are entering a number
                    if(!int.TryParse(productChoiceInput, out var productChoice))
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter valid number");
                        continue;
                    }
                    var product = productList.FirstOrDefault(x => x.ID == productChoice);

                    //Checks to make sure you are entering a valid item
                    if (product == null)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter valid item from the menu");
                        continue;
                    }

                    Console.WriteLine("How many would you like to order: ");
                    var productQuantityInput = Console.ReadLine();

                    //Checks to make sure you are entering a number
                    if (!int.TryParse(productQuantityInput, out var productQuantity))
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter valid number");
                        continue;
                    }

                    //Checks to make sure the quantity is greater than 0
                    if (productQuantity <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter quantity greater than zero");
                        continue;
                    }
                    var lineTotal = registerService.CalculateLineTotal(productQuantity, product.Price);

                    Console.WriteLine($"Here is your line total: {lineTotal.ToString("C", CultureInfo.CurrentCulture)}\n");

                    for (int i = 1; i <= productQuantity; i++)
                    {
                        orderList.Add(product);
                    }

                    Console.WriteLine("Press Y to add more items or N for total");
                    var addMoreItems = Console.ReadLine();
                    if(addMoreItems.ToUpper() == "Y")
                    {
                        proceed = false;
                    }
                    else 
                    {
                        proceed = true;
                    }
                } while (proceed == false);

                registerService.CalcualateSubtotal(orderList);
                registerService.CalculateGrandTotal();
                registerService.CalculateSalesTax();
                Console.WriteLine("\n\nTotal");
                Console.WriteLine("{0,-30} {1,5}", "Subtotal:", $"${String.Format("{0:0.00}", registerService.SubTotal)}");
                Console.WriteLine("{0,-30} {1,5}", "Sales Tax:", $"${String.Format("{0:0.00}", registerService.SalesTax)}");
                Console.WriteLine("{0,-30} {1,5}", "Grand Total:", $"${String.Format("{0:0.00}", registerService.GrandTotal)}");

                Console.WriteLine("\nHow will you be paying? 1. Cash, 2. Credit, or 3. Check");
                var paymentChoice = int.Parse(Console.ReadLine());

                if (paymentChoice == CASH)
                {
                    Console.WriteLine("\nEnter total cash amount:");
                    double amountGiven = double.Parse(Console.ReadLine());
                    Cash cash = new Cash(amountGiven);
                    cash.GetChange(registerService.GrandTotal);
                    Console.WriteLine("{0,-30} {1,5}", "Your change is:", $"${String.Format("{0:0.00}",cash.Change)}");
                    Console.WriteLine("\nHere is your receipt");
                    registerService.PrintCashReceipt(orderList, cash);
                }
                else if (paymentChoice == CARD)
                {
                    Console.WriteLine("\nEnter your card number:");
                    var cardNum = Console.ReadLine();
                    Console.WriteLine("\nEnter the expiration date(MM/YYYY):");
                    string expDate = Console.ReadLine();
                    Console.WriteLine("\nEnter the CVV number:");
                    var cvv = Console.ReadLine();
                    Card card = new Card(cardNum, expDate, cvv);
                    Console.WriteLine("\nHere is your receipt");
                    registerService.PrintCardReceipt(orderList, card);
                }
                else
                {
                    Console.WriteLine("\nEnter check number:");
                    var checkNumber = Console.ReadLine();
                    Check check = new Check(checkNumber);
                    Console.WriteLine("\nHere is your receipt");
                    registerService.PrintCheckReceipt(orderList, check);
                }
                Console.WriteLine("\nEnter 'Y' to place a new order or 'N' if you're done with your shift.");

            } while (UserContinue());           
        }

        public static bool UserContinue()
        {
            while(true)
            {                
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
