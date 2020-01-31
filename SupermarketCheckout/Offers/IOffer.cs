using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketCheckout.Offers
{
    public interface IOffer
    {
        void Visit(List<BasketItem> items);
    }
}
