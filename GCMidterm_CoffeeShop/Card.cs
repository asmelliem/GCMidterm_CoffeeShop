using System;
using System.Collections.Generic;
using System.Text;

namespace GCMidterm_CoffeeShop
{
    public class Card
    {
        public string CardNum { set; get; }
        public string ExpDate { set; get; }
        public string CVV { set; get; }
        public Card(string cardNum, string expDate, string cvv)
        {
            CardNum = cardNum;
            ExpDate = expDate;
            CVV = cvv;
        }
    }
}
