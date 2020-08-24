using System;
namespace GCMidterm_CoffeeShop
{
    public class Validator
    {
        public bool ValidateExperationDate(DateTime expDate)
        {
            if(expDate >= DateTime.Now.Date)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateCardNumber(string cardNumber)
        {
            if (cardNumber.Length == 16)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidateCheckNumber(string checkNum)
        {
            if (checkNum.Length == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidateCVV(string cvv)
        {
            if(cvv.Length == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateAmountGiven(double amountGiven, double grandTotal)

        {
            if(amountGiven>=grandTotal)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
