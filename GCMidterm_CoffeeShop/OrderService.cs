using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace GCMidterm_CoffeeShop
{
    public class OrderService
    {
        Validator validator = new Validator();
        
        public List<Product> GetOrderInfo(bool proceed, RegisterService registerService, List<Product> productList, List<Product> orderList)
        {
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

            return orderList;
        }       
    }
}
