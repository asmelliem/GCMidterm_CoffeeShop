using System;
using System.Collections.Generic;
using System.Text;

namespace GCMidterm_CoffeeShop
{
    public class MenuService
    {      
        //Asking user for new menu item information
        public Product ModifyMenu(int id)
        {
            Console.WriteLine("Enter the product name: ");
            var productName = Console.ReadLine();                    

            Console.WriteLine("Enter the description of the product: ");
            var productDescription = Console.ReadLine();

            Console.WriteLine("Enter the category of the product: ");
            var productCategory = Console.ReadLine();

            var isDouble = false;
            var price = 0.00;
            do
            {
                Console.WriteLine("Enter the price of the product: ");
                var priceInput = Console.ReadLine();
                isDouble = double.TryParse(priceInput, out price);
                if (isDouble == false)
                {
                    Console.WriteLine("Please put in a valid price\n");
                }
            } while (isDouble == false);

            Product product = new Product(id, productName, productCategory, productDescription, price);
            return product;
        }
    } 
}











