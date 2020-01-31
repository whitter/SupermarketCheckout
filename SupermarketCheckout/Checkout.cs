using SupermarketCheckout.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketCheckout
{
    public class Checkout
    {
        private readonly IEnumerable<IOffer> _offers;
        private readonly List<BasketItem> _basketItems = new List<BasketItem>();

        public Checkout(IEnumerable<IOffer> offers)
        {
            _offers = offers;
        }

        public void Scan(BasketItem item)
        {
            var existingItem = _basketItems.FirstOrDefault(x => x.Name == item.Name);

            if(existingItem != null)
            {
                existingItem.Qty += 1;
            }
            else
            {
                _basketItems.Add(item);
            }            
        }

        public int Total()
        {
            List<BasketItem> basketItems = new List<BasketItem>(_basketItems);

            foreach(IOffer offer in _offers)
            {
                offer.Visit(basketItems);
            }

            foreach(BasketItem item in basketItems.Where(x => x.Total == 0))
            {
                item.Total = item.Qty * item.Price;
            }
          
            return basketItems.Sum(x => x.Total);
        }
    }
}
