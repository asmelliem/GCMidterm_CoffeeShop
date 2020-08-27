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
            MenuService menuService = new MenuService();
            var productList = fileService.GetProductList();            

            int CASH = 1;
            int CARD = 2;
            int CHECK = 3;

            do
            {
                var orderList = new List<Product>();
                RegisterService registerService = new RegisterService();
                Console.WriteLine("Welcome to Grand Circus Coffee Shop!!");
                Console.WriteLine("What would you like to do?:");
                Console.WriteLine("   1. Add items to the menu");
                Console.WriteLine("   2. Place an order");
                var userInput = Console.ReadLine();
                if(userInput == "1")
                {
                    var productID = productList.Count()+1;
                    var newProduct = menuService.ModifyMenu(productID);
                    fileService.AddProductToProductList(true, newProduct.ID, newProduct.Name, newProduct.Category, newProduct.Description, newProduct.Price, productList);
                    productList = fileService.GetProductList();
                }
                else if (userInput == "2")
                {
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
                }
                else
                {
                    Console.WriteLine("You did not enter a valid option.");
                }
                Console.WriteLine("\nEnter 'Y' to place a new order/update menu or 'N' to end program");
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
