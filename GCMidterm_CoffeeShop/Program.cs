using System;
using System.Linq;

namespace GCMidterm_CoffeeShop
{
    class Program
    {
        static void Main(string[] args)
        {
            FileService fileService = new FileService();
            var productList = fileService.GetProductList();
            
            Console.WriteLine("Welcome to Grand Circus Coffee Shop!!");
            Console.WriteLine("Menu Items");
            RegisterService registerService = new RegisterService();

            registerService.PrintMenu(productList);
            Console.WriteLine("Please choose the number of the item you want");
            var productChoice = int.Parse(Console.ReadLine());
            var product = productList.Where(x => x.ID == productChoice).FirstOrDefault();
            Console.WriteLine("How many would you like to order: ");
            var productQuantity = int.Parse(Console.ReadLine());
            var lineTotal = registerService.CalculateLineTotal(productQuantity, product.Price);
            Console.WriteLine($"Here is your line total: ${lineTotal}");
            
            Console.WriteLine("Is your order complete or would you like to add more items?");
            Console.WriteLine("Subtotel:");
            Console.WriteLine("Sales Tax:");
            Console.WriteLine("Grand Total:");
            Console.WriteLine("How will you be paying? Cash, Credit, or Check");
            //add line item to ask for props of payment type. Ex cash => amount given.
            Console.WriteLine("Below is your receipt.  Thank you for your business. Please come again");
            //include items ordered and quantity, subtotal, grand total, and payment info.

            //return menu for a new order.
            





        }
    }
}
