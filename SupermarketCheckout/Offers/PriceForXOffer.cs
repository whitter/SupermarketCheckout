using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketCheckout.Offers
{
    public class PriceForXOffer : IOffer
    {
        private readonly string _name;
        private readonly int _qty;
        private readonly int _price;

        public PriceForXOffer(string name, int qty, int price)
        {
            _name = name;
            _qty = qty;
            _price = price;
        }

        public void Visit(List<BasketItem> items)
        {
            BasketItem item = items.FirstOrDefault(x => x.Name == _name);

            if(item != null)
            {
                int offerCount = item.Qty / _qty;

                item.Total = (_price * offerCount) + ((item.Qty % _qty) * item.Price);
            }            
        }
    }
}
