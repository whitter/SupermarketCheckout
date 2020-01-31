using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketCheckout
{
    public class BasketItem
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Qty { get; set; }
        public int Total { get; set; }

        public BasketItem(string name, int price)
        {
            Name = name;
            Price = price;
            Qty = 1;
        }
    }
}
