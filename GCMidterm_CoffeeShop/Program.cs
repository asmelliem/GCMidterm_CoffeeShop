using System;

namespace GCMidterm_CoffeeShop
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Welcome to Grand Circus Coffee Shop!!");
            Console.WriteLine("Menu Items");
            Console.WriteLine("Please choose the number of the item you want");
            Console.WriteLine("You chose One Latte is this correct");
            Console.WriteLine("Would you like to add more lattes");
            Console.WriteLine("Subtotel:");
            Console.WriteLine("Sales Tax:");
            Console.WriteLine("Grand Total:");
            Console.WriteLine("How will you be paying? Cash, Credit, or Check");
            //add line item to ask for props of payment type. Ex cash => amount given.
            Console.WriteLine("Below is your receipt.  Thank you for your business. Please come again");
            //include items ordered and quantity, subtotal, grand total, and payment info.

            //return menu for a new order.
            */

            FileService fileService = new FileService();

            var productList = fileService.GetProductList();

            foreach(var product in productList)
            {
                Console.WriteLine($"ID: {product.ID}, Name: {product.Name}");
            }

        }
    }
}
