using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GCMidterm_CoffeeShop
{
    public class PaymentService
    {
        Validator validator = new Validator();


        public bool UseCashPayment(RegisterService registerService, List<Product> orderList)
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

        public bool UseCardPayment(RegisterService registerService, List<Product> orderList)
        {
            bool isValidCard = false;
            bool isValidExpiryDate = false;
            bool isValidCVV = false;
            string cardNum = string.Empty;
            string expDate = string.Empty;
            var cvv = string.Empty;

            //Checks to make sure the card number is valid
            while (!isValidCard)
            {
                Console.Write("\nEnter your card number: ");
                cardNum = Console.ReadLine();
                isValidCard = validator.ValidateCardNumber(cardNum);
                if (!isValidCard)
                {
                    Console.WriteLine("Please enter 16 digits Card Number");
                }
            }
            //checks to make sure the card expiration date is valid
            while (!isValidExpiryDate)
            {
                Console.Write("\nEnter the expiration date(MM/YYYY): ");
                expDate = Console.ReadLine();
                isValidExpiryDate = validator.ValidateExperationDate(expDate);
                if (!isValidExpiryDate)
                {
                    Console.WriteLine("\nPlease enter a valid date (MM/YYYY)");
                }
            }
            //checks to make sure the cvv number is valid
            while (!isValidCVV)
            {
                Console.Write("\nEnter the CVV number: ");
                cvv = Console.ReadLine();
                isValidCVV = validator.ValidateCVV(cvv);
                if (!isValidCVV)
                {
                    Console.WriteLine("Please enter a 3 digit CVV number");
                }
            }

            Card card = new Card(cardNum, expDate, cvv);
            Console.WriteLine("\nHere is your receipt");
            registerService.PrintCardReceipt(orderList, card);
            return true;
        }
        public bool UseCheckPayment(RegisterService registerService, List<Product> orderList)
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
            return true;
        }
    }
}
