using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GCMidterm_CoffeeShop
{
    public class FileService
    {
        List<Product> productList = new List<Product>();
        public List <Product> GetProductList()
        {
            using (StreamReader reader = new StreamReader("CoffeeShop_ProductList.txt"))
            {
               
                 while(!reader.EndOfStream)
                {
                    List<string> lines = new List<string>() { reader.ReadLine()};
                    foreach (var line in lines)
                    {
                        
                        string[] productInfo = line.Split(';');
                        var id = Convert.ToInt32(productInfo[0]);
                        var price = Convert.ToDouble(productInfo[4]);    
                        Product product = new Product(id, productInfo[1], productInfo[2], productInfo[3], price);
                        productList.Add(product);
                    }
                }
                return productList;
            }
        }
        public List<Product> AddProductToProductList(bool canAppend, int ID, string name, string category, string description, double price)
        {
            using(StreamWriter writer = new StreamWriter("CoffeeShop_ProductList.txt", canAppend))
            {
              writer.WriteLine($"\n{ID};{name};{category};{description};{price}");
            }
            return productList;
        }
    }
}
