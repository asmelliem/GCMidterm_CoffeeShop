using System;
using System.Collections.Generic;
using System.Text;

namespace GCMidterm_CoffeeShop
{
    public class Card
    {
        public uint CardNum { set; get; }
        public string ExpDate { set; get; }
        public int CVV { set; get; }
        public Card(uint cardNum, string expDate, int cvv)
        {
            CardNum = cardNum;
            ExpDate = expDate;
            CVV = cvv;
        }
    }
}
