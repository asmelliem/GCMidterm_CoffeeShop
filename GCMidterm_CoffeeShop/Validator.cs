using System;
using System.Text.RegularExpressions;

namespace GCMidterm_CoffeeShop
{
    public class Validator
    {
        string regex = @"^\d+$";
        string regexDate = "(0[1-9]|10|11|12)/20[0-9]{2}$";

        public bool ValidateExperationDate(string expDate)
        {
            if(Regex.IsMatch(expDate,regexDate))
            {
                var convertedDate = Convert.ToDateTime(expDate);
                if (convertedDate >= DateTime.Now.Date)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            
        }

        public bool ValidateCardNumber(string cardNumber)
        {
            if (cardNumber.Length == 16 && Regex.IsMatch(cardNumber, regex))
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
            if (checkNum.Length == 10 && Regex.IsMatch(checkNum, regex))
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
            if(cvv.Length == 3 && Regex.IsMatch(cvv, regex))
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
