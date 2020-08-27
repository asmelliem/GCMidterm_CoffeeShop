using System;
using System.Collections.Generic;
using System.Text;

namespace GCMidterm_CoffeeShop
{
    public class MenuService
    {
        public static void ModifyMenu()
        {
            Console.WriteLine("What is the product name? :");
            var productName = Console.ReadLine();

            Console.WriteLine("Enter the price of the product:");
            var price = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What is the description of the product? :");
            var productDescription = Console.ReadLine();

            Console.WriteLine("What is the category of the product? :");
            var productCategory = Console.ReadLine();
        }
    } 
}











