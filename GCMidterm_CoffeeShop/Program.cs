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
            PaymentService paymentService = new PaymentService();
            Validator validator = new Validator();
            var productList = fileService.GetProductList();

            int CASH = 1;
            int CARD = 2;
            int CHECK = 3;

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
                    if (!int.TryParse(productChoiceInput, out var productChoice))
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

                    var askForMoreItems = false;
                    do
                    {
                        Console.WriteLine("Press Y to add more items or N for total");
                        var addMoreItems = Console.ReadLine();
                        if (addMoreItems.ToUpper() == "Y")
                        {
                            askForMoreItems = true;
                            proceed = false;
                        }
                        else if (addMoreItems.ToUpper() == "N")
                        {
                            askForMoreItems = true;
                            proceed = true;
                        }
                        else
                        {
                            askForMoreItems = false;
                        }
                    } while (askForMoreItems == false);
                    
                } while (proceed == false);

                registerService.CalcualateSubtotal(orderList);
                registerService.CalculateGrandTotal();
                registerService.CalculateSalesTax();
                Console.WriteLine("\n\nTotal");
                Console.WriteLine("{0,-30} {1,5}", "Subtotal:", registerService.SubTotal.ToString("C", CultureInfo.CurrentCulture));
                Console.WriteLine("{0,-30} {1,5}", "Sales Tax:", registerService.SalesTax.ToString("C", CultureInfo.CurrentCulture)); ;
                Console.WriteLine("{0,-30} {1,5}", "Grand Total:", registerService.GrandTotal.ToString("C", CultureInfo.CurrentCulture));

                bool paymentProceed = false;
                do
                {

                    Console.WriteLine("\n\nPayment Options:");
                    Console.WriteLine("   1. Cash");
                    Console.WriteLine("   2. Credit");
                    Console.WriteLine("   3. Check");
                    Console.Write("\nHow will you be paying? ");
                    var paymentChoiceInput = Console.ReadLine();

                    if (!int.TryParse(paymentChoiceInput, out var paymentChoice))
                    {
                        Console.WriteLine("Please choose a valid payment option");
                        continue;
                    }

                    if (paymentChoice == CASH)
                    {
                        paymentProceed = paymentService.UseCashPayment(registerService, orderList);

                    }
                    else if (paymentChoice == CARD)
                    {
                        paymentProceed = paymentService.UseCardPayment(registerService, orderList);
                    }
                    else if (paymentChoice == CHECK)
                    {
                        var checkNumber = string.Empty;
                        bool isVaildCheckNumber = false;
                        while (!isVaildCheckNumber)
                        {
                            Console.Write("\nEnter check number: ");
                            checkNumber = Console.ReadLine();
                            isVaildCheckNumber = validator.ValidateCheckNumber(checkNumber);
                            if (!isVaildCheckNumber)
                            {
                                Console.WriteLine("Please enter a 10 digit check number");
                            }
                        }
                        Check check = new Check(checkNumber);
                        Console.WriteLine("\nHere is your receipt");
                        registerService.PrintCheckReceipt(orderList, check);
                        paymentProceed = true;
                    }
                    else
                    {
                        Console.WriteLine("Please choose a valid payment option");
                        continue;
                    }

                } while (paymentProceed == false);
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
                    Console.Clear();
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
