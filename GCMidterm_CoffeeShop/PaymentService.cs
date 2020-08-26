using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GCMidterm_CoffeeShop
{
    public class PaymentService
    {
        Validator validator = new Validator();


        public bool UseCashPayment(bool paymentProceed, RegisterService registerService, List<Product> orderList)
        {
            bool isAmountValid = false;
            double amountGiven = 0;
            while (!isAmountValid)
            {
                Console.WriteLine("\nEnter total cash amount: ");
                try
                {
                    amountGiven = double.Parse(Console.ReadLine());
                    isAmountValid = validator.ValidateAmountGiven(amountGiven, registerService.GrandTotal);
                    if (!isAmountValid)
                    {
                        Console.WriteLine("Invalid cash amount. Don't be cheap!");
                    }
                }
                catch (Exception)
                {
                    isAmountValid = false;
                    Console.WriteLine("Please only input a number.");
                }
            }

            Cash cash = new Cash(amountGiven);
            cash.GetChange(registerService.GrandTotal);
            Console.WriteLine("{0,-30} {1,5}", "Your change is:", cash.Change.ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("\nHere is your receipt");
            registerService.PrintCashReceipt(orderList, cash);
            return true;
        }


    }
}
