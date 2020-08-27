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
            OrderService orderService = new OrderService();
            var productList = fileService.GetProductList();
            fileService.AddProductToProductList(true, 13, "testItem", "testCat", "testDescription", 3.99);
            productList = fileService.GetProductList();

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

                orderList = orderService.GetOrderInfo(proceed, registerService, productList, orderList);
                registerService.PrintOrderTotals(orderList);

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
                        paymentProceed = paymentService.UseCheckPayment(registerService, orderList);
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
