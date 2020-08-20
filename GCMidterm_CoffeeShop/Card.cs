using System;
using System.Collections.Generic;
using System.Text;

namespace GCMidterm_CoffeeShop
{
    public class Card
    {
        public int CardNum { set; get; }
        public string ExpDate { set; get; }
        public int CVV { set; get; }
        public Card(int cardNum, string expDate, int cvv)
        {
            CardNum = cardNum;
            ExpDate = expDate;
            CVV = cvv;
        }
    }
}
